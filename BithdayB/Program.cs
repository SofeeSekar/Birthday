using System.Configuration;
using BithdayB.Pages;
using BithdayB.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin=>true);
    });
});
builder.Services.AddSingleton<IWeaverService, WeaverService>();

builder.Services.AddHttpClient<IWeaverService, WeaverService>(client=>
{
    client.BaseAddress = new Uri("https://sandbox.weavr.io/");
    client.DefaultRequestHeaders.Add("api-key", "JRsXx4zY2ikBgKhX7awBCw==");
});

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var config = builder.Configuration;
builder.Services.AddDbContext<CustomerDbContext>(options =>
                options.UseNpgsql(
                    config.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("default");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Map controllers
});
app.UseAuthorization();



app.MapRazorPages();

app.Run();

