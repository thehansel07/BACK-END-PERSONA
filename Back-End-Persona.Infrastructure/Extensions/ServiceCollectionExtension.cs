using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Back_End_Persona.Core.Entities;
using Back_End_Persona.Infrastructure.Data;



namespace Back_End_Persona.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonaContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DevConnectionHansel"))
           );

            return services;
        }


        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Modelo de API Persona", Version = "v1" });
            });

            return services;
        }
    }
}
