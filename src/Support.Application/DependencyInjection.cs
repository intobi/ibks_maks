using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Support.Application.MapperProfiles;

namespace Support.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);

            //configuration.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(assembly);

        services.AddAutoMapper(typeof(TicketProfile));   

        return services;
    }
}