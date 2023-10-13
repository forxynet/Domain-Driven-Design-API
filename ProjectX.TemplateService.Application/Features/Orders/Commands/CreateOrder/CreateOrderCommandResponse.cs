using ProjectX.Template.Application.Responses;

namespace ProjectX.Template.Application.Features.Orders.Commands.CreateOrder {
    public class CreateOrderCommandResponse : BaseResponse {
        public CreateOrderCommandResponse() : base() {

        }
        public CreateOrderDto Order { get; set; } = default!;
    }
}
