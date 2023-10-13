using FluentValidation;

namespace ProjectX.Template.Application.Features.Events.Commands.DeleteEvent {

    public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand> {
        public DeleteEventCommandValidator() {
            RuleFor(p => p.EventId).NotEmpty().WithMessage("{PropertyName} is required").NotNull();
        }
    }
}
