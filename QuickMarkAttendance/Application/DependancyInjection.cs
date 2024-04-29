

using QuickMarkAttendance.Application.Abstraction;
using QuickMarkAttendance.Application.Service;

namespace QuickMarkAttendance.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(typeof(DependancyInjection).Assembly);

            });

            return services;
        }
    }
}
