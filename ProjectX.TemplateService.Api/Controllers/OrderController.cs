using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Template.Application.Features.Orders.Commands.CreateOrder;
using ProjectX.Template.Application.Features.Orders.Commands.DeleteOrder;
using ProjectX.Template.Application.Features.Orders.Queries.GetOrdersForMonth;

namespace ProjectX.Template.Api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("/getpagedordersformonth", Name = "GetPagedOrdersForMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedOrdersForMonthVm>> GetPagedOrdersForMonth(DateTime date, int page, int size) {
            var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date, Page = page, Size = size };
            var dtos = await _mediator.Send(getOrdersForMonthQuery);

            return Ok(dtos);
        }

        //[Authorize]
        [HttpPost(Name = "AddOrder")]
        public async Task<ActionResult<CreateOrderCommandResponse>> AddOrder([FromBody] CreateOrderCommand createOrderCommand) {
            var response = await _mediator.Send(createOrderCommand);
            return Ok(response);
        }

        ////[Authorize]
        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand updateOrderCommand) {
            await _mediator.Send(updateOrderCommand);
            return NoContent();
        }

        ////[Authorize]
        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(Guid id) {
            var deleteOrderCommand = new DeleteOrderCommand() { Id = id };
            await _mediator.Send(deleteOrderCommand);
            return NoContent();
        }
    }
}