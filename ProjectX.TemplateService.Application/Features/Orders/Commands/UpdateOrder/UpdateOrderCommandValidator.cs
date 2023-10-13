using FluentValidation;
using ProjectX.Template.Application.Features.Orders.Commands.CreateOrder;

namespace ProjectX.Template.Application.Features.Orders.Commands.UpdateOrder {
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand> {
        public UpdateOrderCommandValidator() {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
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