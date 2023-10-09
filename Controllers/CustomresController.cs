using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomresController : ControllerBase
    {

        private readonly MyContext context;
        public CustomresController(MyContext _context)
        {
            context = _context;

        }
        [HttpPost]
        [Route("Addcustomer")]
        [Authorize]
        public IActionResult Addcustomer(Ourcustomers_success customer)
        {
            if (customer.Image != null)
            {
                context.ourcustomers_Successess.Add(customer);
                context.SaveChanges();
            }
            return Ok(customer);
        }
        [HttpGet]
        [Route("GetAllCustomer")]
        [Authorize]
        public IActionResult GetAllCustomer()
        {
            List<Ourcustomers_success> customers = context.ourcustomers_Successess.ToList();

            return Ok(customers);
        }
        [HttpPut]
        [Route("updateCustomer")]
        [Authorize]
        public IActionResult updateCustomer(int id, Ourcustomers_success customer)
        {
            Ourcustomers_success cus = context.ourcustomers_Successess.FirstOrDefault(a => a.Id == id);
            if (cus != null)
            {
                cus.Image = customer.Image;
                context.SaveChanges();
                return Ok("update save");
            }
            return NotFound("the id not found");
        }
        [HttpDelete]
        [Route("DeleteCustomer")]
        [Authorize]
        public IActionResult DeleteCustomer(int id)
        {
            Ourcustomers_success customer = context.ourcustomers_Successess.FirstOrDefault(a => a.Id == id);
            context.ourcustomers_Successess.Remove(customer);
            context.SaveChanges();

            return Ok();
        }

    }
}
