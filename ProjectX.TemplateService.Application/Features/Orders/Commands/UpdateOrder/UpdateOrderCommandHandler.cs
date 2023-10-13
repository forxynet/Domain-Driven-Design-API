using AutoMapper;
using MediatR;
using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Application.Exceptions;
using ProjectX.Template.Application.Features.Orders.Commands.CreateOrder;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Features.Orders.Commands.UpdateOrder {
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand> {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Order> _orderRepository;
        public UpdateOrderCommandHandler(IMapper mapper, IAsyncRepository<Order> orderRepository) {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken) {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Order), request.Id);
            var validator = new UpdateOrderCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));
            await _orderRepository.UpdateAsync(orderToUpdate);

            return Unit.Value;
        }
    }
}
