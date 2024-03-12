using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver.Core.Events;
using System.ComponentModel.DataAnnotations;

public static class MongoDbExtensions
{
    public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<MongoDbSettings>()
           .Bind(configuration.GetSection(MongoDbSettings.SectionName))
           .ValidateDataAnnotations()
           .ValidateOnStart();

        services.AddOptions<ConnectionStringsSettings>()
           .Bind(configuration.GetSection(ConnectionStringsSettings.SectionName))
           .ValidateDataAnnotations()
           .ValidateOnStart();

        services.AddSingleton(CreateMongoClient);
        services.AddScoped(GetMongoDatabase);
        return services;
    }

    private static IMongoClient CreateMongoClient(IServiceProvider provider)
    {
        var settings = provider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
        var connectionStrings = provider.GetRequiredService<IOptions<ConnectionStringsSettings>>().Value;

        var mongoConnectionUrl = new MongoUrl(connectionStrings.MongoDb);
        var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);
        mongoClientSettings.ClusterConfigurator = cb =>
        {
            ConfigureLogs(cb, settings);
        };

        var client = new MongoClient(mongoClientSettings);
        return client;
    }

    private static void ConfigureLogs(ClusterBuilder cb, MongoDbSettings settings)
    {
        if (!settings.EnableLogs)
        {
            return;
        }
        cb.Subscribe<CommandStartedEvent>(e =>
        {
            Console.WriteLine($"{e.CommandName} - {e.Command.ToJson()}");
        });
    }

    private static IMongoDatabase GetMongoDatabase(IServiceProvider provider)
    {
        var settings = provider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
        var client = provider.GetRequiredService<IMongoClient>();
        var database = client.GetDatabase(settings.DatabaseName);
        return database;
    }
}