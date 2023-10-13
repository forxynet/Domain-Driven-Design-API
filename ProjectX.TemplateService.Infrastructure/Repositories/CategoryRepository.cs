using Microsoft.EntityFrameworkCore;
using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Infrastructure.Persistence.Repositories {
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository {
        public CategoryRepository(TemplateDbContext dbContext) : base(dbContext) {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents) {
            var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            if (!includePassedEvents) {
                allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return allCategories;
        }
    }
}
