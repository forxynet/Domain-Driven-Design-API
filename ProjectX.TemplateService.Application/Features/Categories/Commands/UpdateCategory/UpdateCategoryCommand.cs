using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Categories.Commands.UpdateCategory {
    public record UpdateCategoryCommand : IRequest {
        public Guid CategoryId { get; init; }
        public string Name { get; init; } = string.Empty;
        public RecordStatus RecordStatus { get; init; }
    }
}