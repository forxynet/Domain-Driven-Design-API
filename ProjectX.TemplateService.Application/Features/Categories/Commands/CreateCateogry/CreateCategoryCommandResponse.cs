using ProjectX.Template.Application.Responses;

namespace ProjectX.Template.Application.Features.Categories.Commands.CreateCateogry {
    public class CreateCategoryCommandResponse : BaseResponse {
        public CreateCategoryCommandResponse() : base() {

        }

        public CreateCategoryDto Category { get; set; } = default!;
    }
}