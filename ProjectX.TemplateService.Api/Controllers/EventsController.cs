using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Template.Application.Features.Events.Commands.CreateEvent;
using ProjectX.Template.Application.Features.Events.Commands.DeleteEvent;
using ProjectX.Template.Application.Features.Events.Commands.UpdateEvent;
using ProjectX.Template.Application.Features.Events.Queries.GetEventDetail;
using ProjectX.Template.Application.Features.Events.Queries.GetEventsList;

namespace ProjectX.Template.Api.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : Controller {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator) {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListVm>>> GetAllEvents() {
            var dtos = await _mediator.Send(new GetEventsListQuery());
            return Ok(dtos);
        }

        //[Authorize]
        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventDetailVm>> GetEventById(Guid id) {
            var getEventDetailQuery = new GetEventDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        //[Authorize]
        [HttpPost(Name = "AddEvent")]
        public async Task<ActionResult<CreateEventCommandResponse>> AddEvent([FromBody] CreateEventCommand createEventCommand) {
            var response = await _mediator.Send(createEventCommand);
            return Ok(response);
        }

        //[Authorize]
        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand updateEventCommand) {
            await _mediator.Send(updateEventCommand);
            return NoContent();
        }

        //[Authorize]
        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id) {
            var deleteEventCommand = new DeleteEventCommand() { EventId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}