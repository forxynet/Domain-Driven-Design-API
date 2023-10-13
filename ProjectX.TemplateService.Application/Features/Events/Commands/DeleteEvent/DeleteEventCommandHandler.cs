using MediatR;
using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Application.Exceptions;
using ProjectX.Template.Domain.Common;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Features.Events.Commands.DeleteEvent {
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand> {
        private readonly IAsyncRepository<Event> _eventRepository;

        public DeleteEventCommandHandler(IAsyncRepository<Event> eventRepository) {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken) {

            var validator = new DeleteEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0) {
                throw new ValidationException(validationResult);
            }

            var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId) ?? throw new NotFoundException(nameof(Event), request.EventId);

            eventToDelete.RecordStatus = RecordStatus.Passive;
            await _eventRepository.UpdateAsync(eventToDelete);

            return Unit.Value;
        }
    }
}
