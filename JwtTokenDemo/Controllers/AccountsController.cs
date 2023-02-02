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
    }
}
