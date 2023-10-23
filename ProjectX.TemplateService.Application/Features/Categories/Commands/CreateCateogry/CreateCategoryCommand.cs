using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Categories.Commands.CreateCateogry {
    public record CreateCategoryCommand : IRequest<CreateCategoryCommandResponse> {
        public string Name { get; init; } = string.Empty;
        public RecordStatus RecordStatus { get; init; }
    }
}
