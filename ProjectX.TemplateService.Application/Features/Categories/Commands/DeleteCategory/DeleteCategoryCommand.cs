using MediatR;

namespace ProjectX.Template.Application.Features.Categories.Commands.DeleteCategory {
    public class DeleteCategoryCommand : IRequest {
        public Guid CategoryId { get; set; }
    }
}
