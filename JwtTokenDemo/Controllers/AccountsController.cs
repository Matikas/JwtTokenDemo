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
        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
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
            var loginSuccess = _accountsService.Login(request.UserName, request.Password);

            if (!loginSuccess)
            {
                return BadRequest("Invalid username or password");
            }
            else
            {
                // TODO: generate JWT
                return Ok();
            }
        }
    }
}
