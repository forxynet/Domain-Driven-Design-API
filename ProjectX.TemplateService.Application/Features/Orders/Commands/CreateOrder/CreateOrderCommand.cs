using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Orders.Commands.CreateOrder {
    public record CreateOrderCommand : IRequest<CreateOrderCommandResponse> {
        public Guid UserId { get; init; }
        public decimal OrderTotal { get; init; }
        public DateTime OrderPlaced { get; init; }
        public bool OrderPaid { get; init; }
        public RecordStatus RecordStatus { get; init; }
    }
}
