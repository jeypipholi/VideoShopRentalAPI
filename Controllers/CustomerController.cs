using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoShopRentalAPI.Data;
using VideoShopRentalAPI.Models;

namespace VideoShopRentalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext dbCOntext;

        public CustomerController(ApplicationDbContext dbCOntext)
        {
            this.dbCOntext = dbCOntext;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var allCustomer = dbCOntext.Customers.ToList();

            return Ok(allCustomer);
        }

        [HttpGet]
        [Route("id")]
        public IActionResult GetCustomerById(int id)
        {
           var customer= dbCOntext.Customers.Find(id);

            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomers(AddCustomerDto addCustomerDto)
        {

            var customerEntity = new Customer()
            {
                Name = addCustomerDto.Name,
                Email = addCustomerDto.Email,
            };

            dbCOntext.Customers.Add(customerEntity);
            dbCOntext.SaveChanges();
            return Ok(customerEntity);
        }

        [HttpPut]
        [Route("id")]
        public IActionResult UpdateCustomer(int id, UpdateCustomerDto updateCustomerDto)
        {
            var customer = dbCOntext.Customers.Find(id);

            if (customer is null)
            {
                return NotFound();
            }

            customer.Name = updateCustomerDto.Name;
            customer.Email = updateCustomerDto.Email;

            dbCOntext.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete]
        [Route("id")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = dbCOntext.Customers.Find(id);
            if ( customer is null)
            {
                return NotFound();
            }

            dbCOntext.Customers.Remove(customer);
            dbCOntext.SaveChanges();
           
            return Ok(customer);
        }
    }
}
