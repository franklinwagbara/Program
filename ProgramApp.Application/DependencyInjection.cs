using Microsoft.Extensions.DependencyInjection;
using ProgramApp.Application.Interfaces;
using ProgramApp.Application.Services;

namespace ProgramApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IApplicationFormService, ApplicationFormService>();
        services.AddScoped<IApplicationResponseService, ApplicationResponseService>();
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        return services;
    }
}
