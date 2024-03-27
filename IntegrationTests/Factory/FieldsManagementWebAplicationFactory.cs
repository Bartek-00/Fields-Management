using FieldsManagement.Application.Security;
using FieldsManagement.Infrastructure.Auth;
using FieldsManagement.Infrastructure.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySpot.Application.Security;
using Testcontainers.MongoDb;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Factory
{
    public class FieldsManagementWebAplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        public ITestOutputHelper? Output { get; set; }
        private readonly MongoDbContainer _container = new MongoDbBuilder().Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            //builder.ConfigureServices(services =>
            //{
            //    services.AddSingleton<IAuthenticator, Authenticator>();
            //    services.AddSingleton<IPasswordManager, PasswordManager>();
            //});

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
                var connectionString = _container.GetConnectionString();

                configuration.AddInMemoryCollection(new Dictionary<string, string?>()
                {
                    { "ConnectionStrings:MongoDb", connectionString },
                    { "MongoDb:DatabaseName", "tests" }
                });
            });
        }

        async Task IAsyncLifetime.InitializeAsync()
        {
            await _container.StartAsync();
        }

        async Task IAsyncLifetime.DisposeAsync()
        {
            await _container.StopAsync();
            await _container.DisposeAsync();
        }
    }
}