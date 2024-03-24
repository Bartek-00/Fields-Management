using FieldsManagement.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Testcontainers.MongoDb;
using Xunit.Abstractions;

namespace FieldsManagment.IntegrationTests;

public class FieldsManagementWebAplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    public ITestOutputHelper? Output { get; set; }
    private readonly MongoDbContainer _conteiner = new MongoDbBuilder().Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            if (Output != null)
            {
                logging.SetMinimumLevel(LogLevel.Error);
            }
        });

        builder.ConfigureAppConfiguration(configuration =>
        {
            var connectionString = _conteiner.GetConnectionString();

            configuration.AddInMemoryCollection(new Dictionary<string, string?>()
            {
                { "ConnectionStrings:MongoDb", connectionString },
                { "MongoDb:DatabaseName", "tests" }
            });
        });
        builder.ConfigureServices(services =>
        {
            services.MockAuthorization();
        });
    }

    async Task IAsyncLifetime.InitializeAsync()
    {
        await _conteiner.StartAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await _conteiner.StopAsync();
        await _conteiner.DisposeAsync();
    }
}

public static class ServiceExtension
{
    public static IServiceCollection MockAuthorization(this IServiceCollection services)
    {
        services.Configure<AuthOptions>(delegate
        {
        });
        services.AddAuthentication(ConfigureTestAuthentication).AddScheme<AuthOptions, Authenticator>("Test", null);
        return services;
    }

    private static void ConfigureTestAuthentication(AuthenticationOptions authenticationOptions)
    {
        authenticationOptions.DefaultAuthenticateScheme = "Test";
        authenticationOptions.DefaultChallengeScheme = "Test";
    }
}