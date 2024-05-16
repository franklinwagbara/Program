using Microsoft.Extensions.DependencyInjection;
using Program.Application.Interfaces;
using Program.Application.Services;

namespace Program.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IApplicationFormService, ApplicationFormService>();
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        //services.AddScoped<IApplicationResponseService, IApplicationResponseService>();
        return services;
    }
}
