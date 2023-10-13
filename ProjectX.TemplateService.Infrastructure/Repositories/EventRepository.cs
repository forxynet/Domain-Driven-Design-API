using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Infrastructure.Persistence.Repositories {
    public class EventRepository : BaseRepository<Event>, IEventRepository {
        public EventRepository(TemplateDbContext dbContext) : base(dbContext) {
        }
        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate) {
            var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
            return Task.FromResult(matches);
        }
    }
}
