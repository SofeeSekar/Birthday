using System;
using System.Text;
using System.Xml;
using BithdayB.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using BithdayB.CommonUtils;
namespace BithdayB
{

    [EnableCors("default")]
    [ApiController]
    [Route("api/[controller]")]
    
    public class WeaverController : ControllerBase
    {
        /// <summary>
        /// Controller for handling all weaver api
        /// </summary>
        private readonly CustomerDbContext _context;
        public readonly IWeaverService _client;
        public WeaverController(CustomerDbContext context, IWeaverService _service)
        {
            _context = context;
            _client = _service;
        }
        [EnableCors("default")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _context.BirthdayDetails.ToList();
           
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string name)
        {
            var res = _context.BirthdayDetails.Where(x=>x.Name==name);

            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerModel value)
        {
            try
            {
                //create the customer and store in db

                _context.BirthdayDetails.Add(new CustomerModel { Name =value.Name,Address=value.Address, Date =value.Date.ToUniversalTime() });
                  
                _context.SaveChanges();
               
                
                var v = new List<Password>
                {
                    new Password() { value = value.Address }
                };

                LoginModel s = new LoginModel()
                {
                    email = value.Name,
                    password = v
                };

                var content =BdayUtils.GetSerializedData(s);
                var response = _client.PostLoginService(content);
                return CreatedAtAction(nameof(Get), new { id = 1 }, response.Result);

            }
            catch (Exception ex)
            {

            }
            return null;
            // Process the posted data
        }

        [HttpDelete("{id}")]
        public  IActionResult DeleteDetails(int id)
        {
            var data =  _context.BirthdayDetails.Find(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.BirthdayDetails.Remove(data);
             _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{name}")]
        public  IActionResult UpdateDetails(int id, CustomerModel myEntity)
        {
            if (id != myEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(myEntity).State = EntityState.Modified;

            try
            {
                 _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.BirthdayDetails.Any(e => e.Id == id);
        }
        // Implement other HTTP methods (PUT, DELETE, etc.) as needed
    }
}
