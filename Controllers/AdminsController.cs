using MarkitingAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarkitingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly MyContext context;
        private readonly IConfiguration _cofiguration;
        public AdminsController(MyContext _context, IConfiguration configuration)
        {
            context = _context;
            _cofiguration = configuration;

        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string name, string password)
        {
          Admin admin=  context.admins.FirstOrDefault(a=>a.Name==name&&a.Password==password);
            if(admin != null)
            {
                return Ok("username and password is correct");
            }
            return NotFound("user name and password not found");
        }

        [HttpGet("Token")]
        public IActionResult GenerateToken(string name,string password)
        {
            Admin admin = context.admins.FirstOrDefault(a => a.Name == name && a.Password == password);
            if (admin != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_cofiguration.GetSection("SecretKey").Value);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, "test"),
                        new Claim(ClaimTypes.Role, "Admin"),
                    }),
                    Expires = DateTime.UtcNow.AddDays(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                return Ok(tokenHandler.WriteToken(token));
            }
            return NotFound("user name and password not found");
        }
    }
}
