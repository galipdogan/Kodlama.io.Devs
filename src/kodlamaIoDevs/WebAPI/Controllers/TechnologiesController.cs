using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetByIdTechnology;
using Application.Features.Technologies.Queries.GetListByDynamicTechnology;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery result = new() { PageRequest = pageRequest };
            TechnologyListModel request = await Mediator.Send(result);
            return Ok(request);
        }

        [HttpPost("getList/byDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListByDynamicTechnologyQuery getListTechnologyByDynamicQuery = new GetListByDynamicTechnologyQuery 
            { PageRequest = pageRequest, Dynamic = dynamic };
            TechnologyListModel result = await Mediator.Send(getListTechnologyByDynamicQuery);
            return Ok(result);
        }

        [HttpGet("getbyid/{Id}")]
        public async Task<IActionResult> GetByIdTechnology([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {

            TechnologyGetByIdDto technologyGetByIdDto = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(technologyGetByIdDto);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteTechnology([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto deletedTechnology = await Mediator.Send(deleteTechnologyCommand);
            return Ok(deletedTechnology);
        }

        [HttpPut("update/{Id}")]
        public async Task<IActionResult> UpdateTechnology([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            //GetListTechnologyQuery result = new() { PageRequest = pageRequest };
            UpdatedTechnologyDto? updatedTechnology = await Mediator.Send(updateTechnologyCommand);
            return Ok(updatedTechnology);

        }
    }
}