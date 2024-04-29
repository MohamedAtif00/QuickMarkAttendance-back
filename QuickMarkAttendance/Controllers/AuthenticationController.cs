//using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Application.DTOs.Authentication.request;
using QuickMarkAttendance.Application.DTOs.Authentication.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickMarkAttendance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // POST api/<AuthenticationController>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authenticationService.Register(request.username, request.email, request.password, "Student",request.ip);

            return Ok(result);
        }

        [HttpPost("Login")] 
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authenticationService.Login(request.username, request.password, "Student");

            return Ok(result);
        }

        // POST api/<AuthenticationController>
        [HttpPost("DoctorRegister")]
        public async Task<IActionResult> DoctorRegister([FromBody] DoctorRegisterRequest request)
        {
            var result = await _authenticationService.Register(request.username, request.email, request.password, "Doctor",null);

            return Ok(result);
        }

        [HttpPost("DoctorLogin")]
        public async Task<IActionResult> DoctorLogin([FromBody] LoginRequest request)
        {
            var result = await _authenticationService.Login(request.username, request.password, "Doctor");

            return Ok(result);
        }


        [HttpPost("LoginAdmin")]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginRequest request)
        {
            var result = await _authenticationService.Login(request.username, request.password, "Admin");

            return Ok(result);
        }
        // PUT api/<AuthenticationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthenticationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("AllowAccess")]
        public async Task<IActionResult> AllowAccess(AllowAccessRequest request)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(request.token) as JwtSecurityToken;

            var claims = jsonToken.Claims;

            var claimIdenity = new ClaimsIdentity(jsonToken.Claims);
            var principle = new ClaimsPrincipal(claimIdenity);
            string userid =   claims.FirstOrDefault(x => x.Type == "userid").Value;
            string username = claims.FirstOrDefault(x => x.Type == "username").Value;
            string email = claims.FirstOrDefault(x => x.Type == "email").Value;
            string role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            var response = new AllowAccessResponse(userid, username, role, email, request.token);

            return  Ok(response);
        }

        [HttpGet("CheckUsername/{username}")]
        public async Task<IActionResult> CheckUsername(string username)
        {
            var result = _userManager.FindByNameAsync(username).Result;

            return Ok(result != null ? true : false);
        }

    }
}
