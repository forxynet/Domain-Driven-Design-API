using AutoMapper;
using MediatR;
using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Application.Features.Categories.Commands.CreateCateogry;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Features.Events.Commands.CreateEvent {
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreateEventCommandResponse> {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository) {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<CreateEventCommandResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken) {
            var createEventCommandResponse = new CreateEventCommandResponse();

            var validator = new CreateEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0) {
                createEventCommandResponse.Success = false;
                createEventCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors) {
                    createEventCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createEventCommandResponse.Success) {
                var _event = new Event() {
                    Name = request.Name,
                    Price = request.Price,
                    Artist = request.Artist,
                    Date = request.Date,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl,
                    CategoryId = request.CategoryId
                };
                _event = await _eventRepository.AddAsync(_event);
                createEventCommandResponse.Event = _mapper.Map<CreateEventDto>(_event);
            }

            return createEventCommandResponse;
        }
    }
}
