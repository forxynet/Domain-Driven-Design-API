using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Orders.Commands.DeleteOrder {
    public record DeleteOrderCommand : IRequest {
        public Guid Id { get; init; }
        public RecordStatus RecordStatus { get; init; }
    }
}
