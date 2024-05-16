﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Program.Domain.Interfaces;
using Program.Persistence.Repositories;

namespace Program.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationFormRepository, ApplicationFormRepository>();
        services.AddScoped<IApplicationResponseRepository, ApplicationResponseRepository>();
        services.AddDbContext<AppDbContext>(options => options.UseCosmos(
            configuration["CosmosDb:Endpoint"],
            configuration["CosmosDb:Key"],
            configuration["CosmosDb:DatabaseName"]
        ));
        return services;
    }
}
