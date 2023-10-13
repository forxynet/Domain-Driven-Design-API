using FluentValidation;

namespace ProjectX.Template.Application.Features.Categories.Commands.UpdateCategory {
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand> {
        public UpdateCategoryCommandValidator() {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(52).WithMessage("{PropertyName} must not exceed 52 characters.");

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
