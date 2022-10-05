using Application.Features.Auth.Commands.AuthLogin;
using Application.Features.Auth.Commands.AuthRegister;
using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
       
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterAuthCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(registerCommand);
            SetRefreshTokenCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        private void SetRefreshTokenCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginAuthCommand loginAuthCommand)
        {
            AccessToken login = await Mediator.Send(loginAuthCommand);
            return Ok(login);
        }
    }
}
