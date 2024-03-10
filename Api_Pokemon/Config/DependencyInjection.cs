using Domain.Repositories;
using InfraData.Context;
using InfraData.Repositories;
using Microsoft.EntityFrameworkCore;


namespace CrossCutting.Configuration
{
    public static class DependencyInjection
    {
            public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
            {
                services.AddDbContext<ContextDb>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IPokemonRepository, PokemonRepository>();
                return services;
            }
            public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
            {
                /*services.AddScoped<IUserService, UserService>();
                services.AddAutoMapper(typeof(DomainToDto));*/
                return services;
            }
    }
}
