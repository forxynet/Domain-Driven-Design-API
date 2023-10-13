using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Contracts.Persistence {
    public interface ICategoryRepository : IAsyncRepository<Category> {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}
