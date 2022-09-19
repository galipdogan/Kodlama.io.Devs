using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageCommand;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery result = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel request = await Mediator.Send(result);
            return Ok(request);
        }

        //[HttpGet("getbyid/{Id}")]
        //public async Task<IActionResult> GetByIdProgrammingLanguage([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        //{
        //    ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
        //    return Ok(programmingLanguageGetByIdDto);
        //}

        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> DeleteProgrammingLanguage([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            //GetListProgrammingLanguageQuery result = new() { PageRequest = pageRequest };
            DeletedProgrammingLanguageDto deletedProgrammingLanguage = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(deletedProgrammingLanguage);
        }

        //[HttpPut("update/{Id}")]
        //public async Task<IActionResult> UpdateProgrammingLanguage([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        //{
        //    //GetListProgrammingLanguageQuery result = new() { PageRequest = pageRequest };
        //    UpdatedProgrammingLanguageDto? updatedProgrammingLanguage = await Mediator.Send(updateProgrammingLanguageCommand);
        //    return Ok(updatedProgrammingLanguage);
        //}
    }
}
