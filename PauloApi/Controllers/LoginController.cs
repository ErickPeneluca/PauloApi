using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PauloApi.Models;
using PauloApi.Repository.Interfaces;
using PauloApi.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PauloApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserRepository _iUserRepository;

        public LoginController(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                User userfounded = _iUserRepository.Login(login.Username, login.Password);

                if (userfounded == null)
                {
                    return Unauthorized("Username or Password invalid");
                }

                var minhasClaims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Name, userfounded.Username),
                new Claim(JwtRegisteredClaimNames.Jti, userfounded.Password.ToString()),
                new Claim(ClaimTypes.Role, userfounded.Type.ToString())
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("key-auth"));

                var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var myToken = new JwtSecurityToken(
                    issuer: "PauloApi",
                    audience: "PauloApi",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credencials
                );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(myToken),

                    }
                );
            }
            catch (Exception e)
            {

                throw new Exception();
            }
        }
    }
}
