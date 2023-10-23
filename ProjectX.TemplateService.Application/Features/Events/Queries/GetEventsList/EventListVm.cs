namespace ProjectX.Template.Application.Features.Events.Queries.GetEventsList {
    public record EventListVm {
        public Guid EventId { get; init; }
        public string Name { get; init; } = string.Empty;
        public DateTime Date { get; init; }
        public string? ImageUrl { get; init; }
    }
}
