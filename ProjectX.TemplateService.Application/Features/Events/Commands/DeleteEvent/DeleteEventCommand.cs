using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Events.Commands.DeleteEvent {
    public record DeleteEventCommand : IRequest {
        public Guid EventId { get; init; }
        public RecordStatus RecordStatus { get; init; }
    }
}
