using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaimCommand;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Application.Features.UserOperationClaims.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
            return Created("", result);
        }


        [HttpGet("getlist")]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new GetListOperationClaimQuery { PageRequest = pageRequest };
            OperationClaimListModel operationClaimListModel = await Mediator.Send(getListOperationClaimQuery);
            return Ok(operationClaimListModel);
        }


        [HttpGet("getbyid/{Id}")]
        public async Task<IActionResult> GetByIdOperationClaim([FromRoute] GetByIdOperationClaimQuery getByIdOperationClaimQuery)
        {
            OperationClaimGetByIdDto OperationClaimGetByIdDto = await Mediator.Send(getByIdOperationClaimQuery);
            return Ok(OperationClaimGetByIdDto);
        }

        //[HttpDelete("delete/{Id}")]
        //public async Task<IActionResult> DeleteOperationClaim([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        //{
        //    DeletedOperationClaimDto deletedOperationClaim = await Mediator.Send(deleteOperationClaimCommand);
        //    return Ok(deletedOperationClaim);
        //}

        //[HttpPut("update/{Id}")]
        //public async Task<IActionResult> UpdateOperationClaim([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        //{
        //    UpdatedOperationClaimDto? updatedOperationClaim = await Mediator.Send(updateOperationClaimCommand);
        //    return Ok(updatedOperationClaim);
        //}
    }
}
