using FluentValidation;

namespace ProjectX.Template.Application.Features.Orders.Commands.DeleteOrder {
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand> {
        public DeleteOrderCommandValidator() {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
