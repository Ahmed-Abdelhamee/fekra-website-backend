using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurworksController : ControllerBase
    {
        private readonly MyContext context;
        public OurworksController(MyContext _context)
        {
            context = _context;

        }
        [HttpPost]
        [Route("AddWork")]
        [Authorize]
        public IActionResult AddWork(Ourworks works)
        {
            if (works.Image != null)
            {
                context.Ourworkss.Add(works);
                context.SaveChanges();
            }
            return Ok(works);
        }
        [HttpGet]
        [Route("GetAllworks")]
        [Authorize]
        public IActionResult GetAllworks()
        {
            List<Ourworks> works = context.Ourworkss.ToList();

            return Ok(works);
        }
        [HttpPut]
        [Route("updatework")]
        [Authorize]
        public IActionResult updatework(int id, Ourworks work)
        {
            Ourworks wor = context.Ourworkss.FirstOrDefault(a => a.Id == id);
            if (wor != null)
            {
                wor.Image = work.Image;
                context.SaveChanges();
                return Ok("update save");
            }
            return NotFound("the id not found");
        }
        [HttpDelete]
        [Route("Deleteworker")]
        [Authorize]
        public IActionResult Deleteworker(int id)
        {
            Ourworks worker = context.Ourworkss.FirstOrDefault(a => a.Id == id);
            context.Ourworkss.Remove(worker);
            context.SaveChanges();

            return Ok();
        }


    }
}
