using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.InfrastructureModel;
using FieldsManagement.Infrastructure.Queries.Handlers;
using FieldsManagement.Infrastructure.Queries;
using FieldsManagement.Infrastructure.Repositories;
using MediatR;
using MongoDB.Driver;
using FieldsManagement.Infrastructure.Queries.Handler;

namespace FieldsManagement.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<DataBaseConfiguration>(configuration.GetSection("DatabaseConfiguration"));
            services.AddHttpClient();
            services.AddMongoDb(configuration);

            services.AddTransient<IFieldsRepository, FieldsRepository>();

            services.AddScoped<IRequestHandler<GetAllQuery, List<Field>>, GetAllQueryHandler>();
            services.AddScoped<IRequestHandler<GetByVillageQuery, List<Field>>, GetByVillageQueryHandler>();

            return services;
        }
    }

    public static class MongoDbExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure MongoDB connection
            var mongoConfig = configuration.GetSection("DatabaseConfiguration").Get<DataBaseConfiguration>();
            var mongoClient = new MongoClient(mongoConfig!.MongoDbConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoConfig.MongoDatabaseName);

            services.AddSingleton<IMongoDatabase>(mongoDatabase);
            return services;
        }
    }
}