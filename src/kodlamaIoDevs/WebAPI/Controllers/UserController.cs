using Application.Features.Auths.Commands.LoginUser;
using Application.Features.Users.Commands.CreateUsers;
using Core.Security.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand createUserCommand)
        {
            UserForRegisterDto result = await Mediator.Send(createUserCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] LoginUserCommand loginUserCommand)
        {
            UserForLoginDto result = await Mediator.Send(loginUserCommand);
            return Ok(result);
        }
    }
}
