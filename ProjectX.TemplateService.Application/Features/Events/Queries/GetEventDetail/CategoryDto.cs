namespace ProjectX.Template.Application.Features.Events.Queries.GetEventDetail {
    public record CategoryDto {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
