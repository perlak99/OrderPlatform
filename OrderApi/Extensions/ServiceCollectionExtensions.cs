using MongoDB.Driver;
using OrderApi.Configurations;
using OrderApi.Repositories;
using OrderApi.Repositories.Interfaces;
using OrderApi.Services;
using OrderApi.Services.Interfaces;
using RabbitMQ.Client;

namespace OrderApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region MongoDB
        public static IServiceCollection AddMongoDB(this IServiceCollection services)
        {
            services.AddSingleton(x =>
            {
                var configuration = x.GetService<IConfiguration>();
                var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
                var databaseName = new MongoUrl(mongoDbSettings.ConnectionString).DatabaseName;
                return mongoClient.GetDatabase(databaseName);
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IOrderRepository, OrderRepository>();

            return services;
        }

        #endregion

        #region RabbitMq

        #endregion

        #region Services

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }

        #endregion
    }
}
