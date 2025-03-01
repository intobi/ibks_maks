using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Support.Application.Common.Interfaces;
using Support.Domain.Entities;
using Support.Infrastructure.Persistence.DbContext;
using Support.Infrastructure.Persistence.Repositories;

namespace Support.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SupportDbContext>
            (options => options.UseSqlServer(configuration.GetConnectionString("SupportDb")));
        
        services.AddTransient<IRepositoryBase<Ticket>, TicketsRepository>();
        
        return services;
    }
}