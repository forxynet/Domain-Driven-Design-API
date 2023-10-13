using AutoMapper;
using MediatR;
using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Features.Events.Queries.GetEventsList {
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>> {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository) {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken) {
            var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);
            return _mapper.Map<List<EventListVm>>(allEvents);
        }
    }
}
