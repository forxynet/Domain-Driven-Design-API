using MediatR;

namespace ProjectX.Template.Application.Features.Events.Commands.CreateEvent {
    public record CreateEventCommand : IRequest<CreateEventCommandResponse> {
        public string Name { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public string? Artist { get; init; }
        public DateTime Date { get; init; }
        public string? Description { get; init; }
        public string? ImageUrl { get; init; }
        public Guid CategoryId { get; init; }
    }
}
