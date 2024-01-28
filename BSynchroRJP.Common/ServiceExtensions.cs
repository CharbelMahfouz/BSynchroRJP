using BSynchroRJP.DataAccessLayer.Connections;
using BSynchroRJP.DataAccessLayer.IRepositories;
using BSynchroRJP.DataAccessLayer.Repositories;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;


namespace BSynchroRJP.Common
{
    public static class ServiceExtensions
    {
        public static void ConfigureMongoDbConnection(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<MongoDbSettings>(options =>
            {

                options.ConnectionString = Configuration["MongoDbSettings:ConnectionString"]!;
                options.DatabaseName = Configuration["MongoDbSettings:DatabaseName"]!;
            });

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(Configuration["RabbitMqConfig:Host"]!), h =>
                    {
                        h.Username(Configuration["RabbitMqConfig:Username"]!);
                        h.Password(Configuration["RabbitMqConfig:Password"]!);
                    });
                });

            });
        }

        public static void ConfigureMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
