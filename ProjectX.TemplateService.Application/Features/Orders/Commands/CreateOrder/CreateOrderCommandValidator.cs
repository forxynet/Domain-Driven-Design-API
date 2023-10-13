using FluentValidation;

namespace ProjectX.Template.Application.Features.Orders.Commands.CreateOrder {
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand> {
        public CreateOrderCommandValidator() {
            RuleFor(p => p.OrderTotal)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull();
            RuleFor(p => p.OrderPlaced)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.OrderPaid)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
