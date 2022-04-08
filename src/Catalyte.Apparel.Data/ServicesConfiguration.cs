using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalyte.Apparel.Data
{
    /// <summary>
    /// This class provides configuration options for services and context.
    /// </summary>
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApparelCtx>(options =>
                options.UseNpgsql(config.GetConnectionString("CatalyteApparel")));

            services.AddScoped<IApparelCtx>(provider => provider.GetService<ApparelCtx>());
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IEncounterRepository, EncounterRepository>();

            return services;

        }

    }

}
