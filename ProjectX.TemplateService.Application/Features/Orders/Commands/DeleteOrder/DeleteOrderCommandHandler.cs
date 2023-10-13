using MediatR;
using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Application.Exceptions;
using ProjectX.Template.Domain.Common;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Features.Orders.Commands.DeleteOrder {
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand> {
        private readonly IAsyncRepository<Order> _orderRepository;
        public DeleteOrderCommandHandler(IAsyncRepository<Order> orderRepository) {
            _orderRepository = orderRepository;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken) {
            var validator = new DeleteOrderCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0) {
                throw new ValidationException(validationResult);
            }

            var orderToDelete = await _orderRepository.GetByIdAsync(request.Id) ??
                throw new NotFoundException(nameof(Order), request.Id);

            orderToDelete.RecordStatus = RecordStatus.Passive;
            await _orderRepository.UpdateAsync(orderToDelete);

            return Unit.Value;
        }
    }
}
