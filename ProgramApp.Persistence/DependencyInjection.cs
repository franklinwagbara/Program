using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramApp.Domain.Interfaces;
using ProgramApp.Persistence.Repositories;
using ProgramApp.Persistence.Repositories.CachedRepositories;

namespace ProgramApp.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ApplicationFormRepository>();
        services.AddScoped<ApplicationResponseRepository>();
        services.AddMemoryCache();

        services.AddScoped<IApplicationFormRepository>(provider =>
        {
            var appRepo = provider.GetService<ApplicationFormRepository>();
            var memCache = provider.GetService<IMemoryCache>();
            return new CachedApplicationFormRespository(appRepo!, memCache!);
        });

        services.AddScoped<IApplicationResponseRepository>(provider =>
        {
            var appRepo = provider.GetService<ApplicationResponseRepository>();
            var memCache = provider.GetService<IMemoryCache>();
            return new CachedApplicationResponseRespository(appRepo!, memCache!);
        });

        services.AddDbContext<AppDbContext>(options => options.UseCosmos(
            configuration["CosmosDb:Endpoint"],
            configuration["CosmosDb:Key"],
            configuration["CosmosDb:DatabaseName"]
        ));
        return services;
    }
}
