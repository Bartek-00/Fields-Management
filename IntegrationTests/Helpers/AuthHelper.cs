using FieldsManagement.Application.Security;
using IntegrationTests.Factory;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace IntegrationTests.Helpers
{
    public static class AuthHelper
    {
        public static HttpClient Authorize(FieldsManagementWebAplicationFactory webAppFactory, Guid userId, string role)
        {
            var client = webAppFactory.CreateClient();
            var authenticator = webAppFactory.Services.GetRequiredService<IAuthenticator>();
            var jwt = authenticator.CreateToken(userId, role);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.AccessToken);

            return client;
        }
    }
}