using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Contracts.Persistence {
    public interface IEventRepository : IAsyncRepository<Event> {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}
