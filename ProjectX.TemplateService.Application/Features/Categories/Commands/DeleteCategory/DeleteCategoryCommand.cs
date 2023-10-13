using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Categories.Commands.DeleteCategory {
    public class DeleteCategoryCommand : IRequest {
        public Guid CategoryId { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
