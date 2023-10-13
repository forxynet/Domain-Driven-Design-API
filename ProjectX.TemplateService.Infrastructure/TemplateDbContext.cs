using Microsoft.EntityFrameworkCore;
using ProjectX.Template.Application.Contracts;
using ProjectX.Template.Domain.Common;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Infrastructure.Persistence {
    public class TemplateDbContext : DbContext {
        private readonly ILoggedInUserService? _loggedInUserService;

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options) {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>()) {
                switch (entry.State) {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
