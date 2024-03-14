using BithdayB;
using Microsoft.EntityFrameworkCore;

public class CustomerDbContext : DbContext
{
    /// <summary>
    /// Creating a constructor for DB context injection
    /// </summary>
    /// <param name="options"></param>
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

    
    protected readonly IConfiguration Configuration;

    /// <summary>
    /// Empty Constructor
    /// </summary>
    public CustomerDbContext()
    {
    }

  /// <summary>
  /// Creating the DBset for create a table in PgAdmin
  /// </summary>
    public DbSet<CustomerModel> BirthdayDetails { get; set; }
}