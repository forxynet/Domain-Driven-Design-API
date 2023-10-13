﻿using MediatR;
using ProjectX.Template.Domain.Common;

namespace ProjectX.Template.Application.Features.Events.Commands.UpdateEvent {
    public class UpdateEventCommand : IRequest {
        public Guid EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Artist { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
