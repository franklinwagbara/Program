using Microsoft.EntityFrameworkCore;
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
        services.AddScoped<IApplicationFormRepository, CachedApplicationFormRespository>();
        services.AddScoped<IApplicationResponseRepository, CachedApplicationResponseRespository>();
        services.AddDbContext<AppDbContext>(options => options.UseCosmos(
            configuration["CosmosDb:Endpoint"],
            configuration["CosmosDb:Key"],
            configuration["CosmosDb:DatabaseName"]
        ));
        return services;
    }
}
