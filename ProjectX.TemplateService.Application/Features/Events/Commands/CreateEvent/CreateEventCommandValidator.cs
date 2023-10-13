using FluentValidation;
using ProjectX.Template.Application.Features.Events.Commands.CreateEvent;

namespace ProjectX.Template.Application.Features.Categories.Commands.CreateCateogry {
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand> {
        public CreateEventCommandValidator() {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}