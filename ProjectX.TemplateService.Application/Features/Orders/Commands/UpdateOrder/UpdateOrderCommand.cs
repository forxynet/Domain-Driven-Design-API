﻿using MediatR;

namespace ProjectX.Template.Application.Features.Orders.Commands.CreateOrder {
    public class UpdateOrderCommand : IRequest {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
    }
}