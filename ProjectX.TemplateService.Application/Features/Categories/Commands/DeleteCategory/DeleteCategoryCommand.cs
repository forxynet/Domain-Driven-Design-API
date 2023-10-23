using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Categories.Commands.DeleteCategory {
    public record DeleteCategoryCommand : IRequest {
        public Guid CategoryId { get; init; }
        public RecordStatus RecordStatus { get; init; }
    }
}
