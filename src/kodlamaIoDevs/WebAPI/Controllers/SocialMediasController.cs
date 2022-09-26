using Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Application.Features.SocialMedias.Commands.DeleteSocialMedia;
using Application.Features.SocialMedias.Commands.UpdateSocialMedia;
using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Models;
using Application.Features.SocialMedias.Queris.GetByIdSocailMedia;
using Application.Features.SocialMedias.Queris.GetListByDynamicSocialMedia;
using Application.Features.SocialMedias.Queris.GetListSocailMedia;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaCommand createSocialMediaCommand)
        {
            CreatedSocialMediaDto result = await Mediator.Send(createSocialMediaCommand);
            return Created("", result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialMediaQuery result = new() { PageRequest = pageRequest };
            SocialMediaListModel request = await Mediator.Send(result);
            return Ok(request);
        }

        [HttpPost("getList/byDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListByDynamicSocialMediaQuery getListSocialMediaByDynamicQuery = new GetListByDynamicSocialMediaQuery
            { PageRequest = pageRequest, Dynamic = dynamic };
            SocialMediaListModel result = await Mediator.Send(getListSocialMediaByDynamicQuery);
            return Ok(result);
        }

        [HttpGet("getbyid/{Id}")]
        public async Task<IActionResult> GetByIdSocialMedia([FromRoute] GetByIdSocialMediaQuery getByIdSocialMediaQuery)
        {
            SocialMediaGetByIdDto socialMediaGetByIdDto = await Mediator.Send(getByIdSocialMediaQuery);
            return Ok(socialMediaGetByIdDto);
        }

        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult> DeleteSocialMedia([FromRoute] DeleteSocialMediaCommand deleteSocialMediaCommand)
        {
            DeletedSocialMediaDto deletedSocialMedia = await Mediator.Send(deleteSocialMediaCommand);
            return Ok(deletedSocialMedia);
        }

        [HttpPut("update/{Id}")]
        public async Task<IActionResult> UpdateSocialMedia([FromBody] UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            //GetListSocialMediaQuery result = new() { PageRequest = pageRequest };
            UpdatedSocialMediaDto? updatedSocialMedia = await Mediator.Send(updateSocialMediaCommand);
            return Ok(updatedSocialMedia);

        }
    }
}
