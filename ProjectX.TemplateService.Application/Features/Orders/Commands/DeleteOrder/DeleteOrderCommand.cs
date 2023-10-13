using MediatR;

namespace ProjectX.Template.Application.Features.Orders.Commands.DeleteOrder {
    public class DeleteOrderCommand : IRequest {
        public Guid Id { get; set; }
    }
}
