using ProjectX.Template.Application.Responses;

namespace ProjectX.Template.Application.Features.Events.Commands.CreateEvent {
    public class CreateEventCommandResponse : BaseResponse {
        public CreateEventCommandResponse() : base() {

        }

        public CreateEventDto Event { get; set; } = default!;
    }
}
