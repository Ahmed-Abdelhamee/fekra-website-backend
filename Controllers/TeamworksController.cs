using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamworksController : ControllerBase
    {
        private readonly MyContext context;
        public TeamworksController(MyContext _context)
        {
            context = _context;

        }
        [HttpPost]
        [Route("AddFactor")]
        [Authorize]
        public IActionResult AddFactor(workteam factor)
        {
            if (factor.Image != null&&factor.Name!=null)
            {
                context.workteams.Add(factor);
                context.SaveChanges();
            }
            return Ok(factor);
        }
        [HttpGet]
        [Route("GetAllTeam")]
        [Authorize]
        public IActionResult GetAllTeam()
        {
            List<workteam> teams = context.workteams.ToList();

            return Ok(teams);
        }
        [HttpPut]
        [Route("updateteam")]
        [Authorize]
        public IActionResult updateupdateteam(int id,workteam  team)
        {
            workteam tem = context.workteams.FirstOrDefault(a => a.Id == id);
            if (tem != null)
            {
                tem.Name = team.Name;
                tem.Image = team.Image;
                context.SaveChanges();
                return Ok("update save");
            }
            return NotFound("the id not found");
        }
        [HttpDelete]
        [Route("DeleteTeammember")]
        [Authorize]
        public IActionResult DeleteTeammember(int id)
        {
            workteam members = context.workteams.FirstOrDefault(a => a.Id == id);
            context.workteams.Remove(members);
            context.SaveChanges();

            return Ok();
        }
    }
}
