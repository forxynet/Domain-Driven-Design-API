using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Events.Commands.DeleteEvent {
    public class DeleteEventCommand : IRequest {
        public Guid EventId { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
