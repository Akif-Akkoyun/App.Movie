﻿using App.Movie.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using App.Movie.Application.Features.MediatorDesignPattern.Queries.TagQyeries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Movie.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var value =await _mediator.Send(new GetTagQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme İşlemi Başarılı.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme İşlemi Başarılı.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));
            return Ok("Silme İşlemi Başarılı.");
        }
        [HttpGet("GetTagById/{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var value = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(value);
        }
    }
}
