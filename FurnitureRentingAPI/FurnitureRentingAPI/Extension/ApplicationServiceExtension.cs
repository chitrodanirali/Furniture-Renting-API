using FluentValidation.AspNetCore;
using FurnitureRentingAPI.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureRentingAPI.Extension
{
    [Obsolete]
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            })
             .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Program>());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //services.AddSingleton<ApplicationContext>();
            return services;
        }
    }
}
