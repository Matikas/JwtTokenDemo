using JwtTokenDemo.BL;
using JwtTokenDemo.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtTokenDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly IJwtService _jwtService;

        public AccountsController(IAccountsService accountsService, IJwtService jwtService)
        {
            _accountsService = accountsService;
            _jwtService = jwtService;
        }

        [HttpPost("SignUp")]
        public ActionResult Signup(AuthRequestDto request)
        {
            _accountsService.SignupNewAccount(request.UserName, request.Password);
            return Ok();
        }

        [HttpPost("Login")]
        public ActionResult Login(AuthRequestDto request)
        {
            var (loginSuccess, account) = _accountsService.Login(request.UserName, request.Password);

            if (!loginSuccess)
            {
                return BadRequest("Invalid username or password");
            }
            else
            {
                var jwt = _jwtService.GetJwtToken(account.Username, account.Id);
                return Ok(jwt);
            }
        }
    }
}
