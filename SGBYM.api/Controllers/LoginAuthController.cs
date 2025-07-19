using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SGBYM.Application.DTOs.LoginDTO;
using SGBYM.Application.Interfaces;
using SGBYM.Application.Services;

namespace SGBYM.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly ILoginService _loginService;
        

        public LoginAuthController(JwtService jwtService, ILoginService loginService)
        {
            _jwtService = jwtService;
            _loginService = loginService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            try
            {
                var user = await _loginService.LoginAsync(loginRequest.Correo, loginRequest.Password);
                return Ok(new { token = user.Token });
            }
            catch (UnauthorizedAccessException) {
                return Unauthorized();
            }
            
           
        }
    }
}
