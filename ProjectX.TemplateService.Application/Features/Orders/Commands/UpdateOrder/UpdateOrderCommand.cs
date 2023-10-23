using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Orders.Commands.CreateOrder {
    public record UpdateOrderCommand : IRequest {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public decimal OrderTotal { get; init; }
        public DateTime OrderPlaced { get; init; }
        public bool OrderPaid { get; init; }
        public RecordStatus RecordStatus { get; init; }
    }
}
