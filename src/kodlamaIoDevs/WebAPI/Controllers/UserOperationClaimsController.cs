using Application.Features.SocialMedias.Models;
using Application.Features.SocialMedias.Queris.GetListSocailMedia;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Queries.GetByIdTechnology;
using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries;
using Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;
using Application.Features.UserOperationClaims.Queries.GetUserOperationClaimByUserId;
using Core.Application.Requests;
using Core.Security.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }

        [HttpGet("getlist")]
        public async Task<ActionResult> GetList([FromQuery] GetListUserOperationClaimQuery getListUserOperationClaimQuery)
        {
            UserOperationClaimListModel userOperationClaimListModel = await Mediator.Send(getListUserOperationClaimQuery);
            return Ok(userOperationClaimListModel);
           
        }

        [HttpGet("getbyuserid/{UserId}")]
        public async Task<IActionResult> GetByIdUser([FromRoute] GetUserOperationClaimsByUserIdQuery getUserOperationClaimsByUserIdQuery)
        {
            UserOperationClaimListModel userOperationClaimsGetByUserIdDto = await Mediator.Send(getUserOperationClaimsByUserIdQuery);
            return Ok(userOperationClaimsGetByUserIdDto);
        }

    }
}
