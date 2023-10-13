using AutoMapper;
using MediatR;
using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Features.Orders.Commands.CreateOrder {
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse> {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IAsyncRepository<Order> orderRepository, IMapper mapper) {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken) {
            var createOrderCommandResponse = new CreateOrderCommandResponse();

            var validator = new CreateOrderCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (validatorResult.Errors.Count > 0) {
                createOrderCommandResponse.Success = false;
                createOrderCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validatorResult.Errors) {
                    createOrderCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createOrderCommandResponse.Success) {
                var order = new Order() {
                    OrderPlaced = request.OrderPlaced,
                    OrderPaid = request.OrderPaid,
                    OrderTotal = request.OrderTotal
                };
                order = await _orderRepository.AddAsync(order);
                createOrderCommandResponse.Order = _mapper.Map<CreateOrderDto>(order);
            }
            return createOrderCommandResponse;
        }
    }
}
