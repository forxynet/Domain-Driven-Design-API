using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Orders.Commands.DeleteOrder {
    public class DeleteOrderCommand : IRequest {
        public Guid Id { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
