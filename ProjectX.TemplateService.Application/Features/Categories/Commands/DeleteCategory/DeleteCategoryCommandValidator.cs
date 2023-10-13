using FluentValidation;

namespace ProjectX.Template.Application.Features.Categories.Commands.DeleteCategory {
    public class DeleteEventCommandValidator : AbstractValidator<DeleteCategoryCommand> {
        public DeleteEventCommandValidator() {
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("{PropertyName} is required").NotNull();
        }
    }
}
