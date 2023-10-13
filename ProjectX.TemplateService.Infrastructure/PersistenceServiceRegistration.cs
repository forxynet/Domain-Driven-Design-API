using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectX.Template.Application.Contracts.Persistence;
using ProjectX.Template.Infrastructure.Persistence.Repositories;

namespace ProjectX.Template.Infrastructure.Persistence {
    public static class PersistenceServiceRegistration {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<TemplateDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            //DateTime with Kind=UTC to PostgreSQL type 'timestamp without time zone'
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
