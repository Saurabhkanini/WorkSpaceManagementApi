using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly WsDbContext uDbC;
        public AuthController(WsDbContext udb, IConfiguration ic)
        {
            this.uDbC = udb;
            this.configuration = ic;

        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(AdminRegister ud)
        {

            var existingUserCheck = uDbC.adminRegisters.FirstOrDefault(x => x.Email == ud.Email);
            if (existingUserCheck == null)
            {
                string hashpassword = BCrypt.Net.BCrypt.HashPassword(ud.Password);


                var user = new AdminRegister()
                {
                    Name = ud.Name,
                    Email = ud.Email,
                    Password = hashpassword,
                

                };
                uDbC.adminRegisters.Add(user);
                uDbC.SaveChanges();
                return Ok(user);

            }
            return BadRequest("UserEmail Already Exists");

        }
        [HttpPost("Login")]
        public async Task<ActionResult> SignIn(AdminLogin ud)
        {
            string email = ud.Email;
            string pass = ud.Password;
            var user = uDbC.adminRegisters.FirstOrDefault(x => x.Email == email);
            //user.Password == ud.Password
            if (user!= null && BCrypt.Net.BCrypt.Verify(pass, user.Password))
            {
                var token = CreatToken(user);
                return Ok(new { token, user });
            }
            else
            {
                return BadRequest("user not found");
            }
        }

        private string CreatToken(AdminRegister ud)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, ud.Email),
                new Claim(ClaimTypes.Role,"admin")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSetting:Token").Value!));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        [HttpGet("getAdminByEmail")]
        public async Task<ActionResult> GetUserByEmail(string email)
        {
            var user=uDbC.adminRegisters.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return NotFound($"User Not Found With {email}");
            }
            return Ok(user);
        }
        [HttpGet]

        public async Task<ActionResult> GetAllAdmin()
        {
            var admins = uDbC.adminRegisters.ToList();
            return Ok(admins);

        }
    }
}
