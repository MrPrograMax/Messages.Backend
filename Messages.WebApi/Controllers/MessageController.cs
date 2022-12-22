using Messages.Application.Messages.Queries.GetMessageList;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using System;
using Messages.Application.Messages.Queries.GetMessageText;
using Messages.WebApi.Models;
using AutoMapper;
using Messages.Application.Messages.Commands.CreateMessage;
using Messages.Application.Messages.Commands.UpdateMessage;
using Messages.Application.Messages.Commands.DeleteMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Messages.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class MessageController : BaseController
    {
        private readonly IMapper _mapper;
        public MessageController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageListVm>> GetAll()
        {
            var query = new GetMessageListQuery
            {
                UserId = UserId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MessageListVm>> Get(Guid id)
        {
            var query = new GetMessageTextQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            if (vm.DeleteAfterUpload == true)
            {
                await Delete(vm.Id);
            }

            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMessageDto createMessageDto)
        {
            var command = _mapper.Map<CreateMessageCommand>(createMessageDto);
            command.UserId = UserId;
            var messageId = await Mediator.Send(command);
            return Ok(messageId);
        }

        /*[HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateMessageDto updateMessageDto)
        {
            var command = _mapper.Map<UpdateMessageCommand>(updateMessageDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }*/

        [HttpDelete("{id}")]
        [Authorize] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        private async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMessageCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
