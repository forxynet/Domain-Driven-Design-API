using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Events.Commands.UpdateEvent {
    public record UpdateEventCommand : IRequest {
        public Guid EventId { get; init; }
        public string Name { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public string? Artist { get; init; }
        public DateTime Date { get; init; }
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public Guid CategoryId { get; init; }
        public RecordStatus RecordStatus { get; init; }
    }
}
