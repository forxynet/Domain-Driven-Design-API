﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectX.Template.Application {
    public static class ApplicationServiceRegistration {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
