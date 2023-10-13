using MediatR;

namespace ProjectX.Template.Application.Features.Events.Commands.DeleteEvent {
    public class DeleteEventCommand : IRequest {
        public Guid EventId { get; set; }
    }
}
