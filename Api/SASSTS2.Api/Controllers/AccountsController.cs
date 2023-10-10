using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.TokenDtos;
using SASSTS2.Application.Models.RequestModels.AccountsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Wrapper;

namespace SASSTS2.Api.Controllers
{
    [Route("account")]
    [ApiController]
    //[Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<int>>> Register(RegisterVM createUserVM)
        {
            var result = await _accountService.Register(createUserVM);
            return Ok(result);
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<TokenDto>>> Login(LoginVM loginVM)
        {
            var result = await _accountService.Login(loginVM);
            return Ok(result);
        }

        [HttpPut("update/{id:int?}")]
        public async Task<ActionResult<Result<int>>> UpdateUser(int? id, UpdateUserVM updateUserVM)
        {
            if (id != updateUserVM.Id)
            {
                return BadRequest();
            }
            var result = await _accountService.UpdateUser(updateUserVM);
            return Ok(result);
        }
    }
}
