using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Categories.Commands.CreateCateogry {
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse> {
        public string Name { get; set; } = string.Empty;
        public RecordStatus RecordStatus { get; set; }
    }
}
