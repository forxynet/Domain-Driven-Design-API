﻿using FluentValidation;

namespace ProjectX.Template.Application.Features.Categories.Commands.CreateCateogry {
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand> {
        public CreateCategoryCommandValidator() {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
