using FieldsManagement.Application.Security;
using Moq;
using System.Net.Http.Headers;

namespace FieldsManagment.IntegrationTests
{
    public class AuthenticationTests : IClassFixture<FieldsManagementWebAplicationFactory>
    {
        private readonly FieldsManagementWebAplicationFactory _factory;
        private readonly IAuthenticator _authenticatorMock;

        public AuthenticationTests(FieldsManagementWebAplicationFactory factory)
        {
            _factory = factory;
            _authenticatorMock = new Mock<IAuthenticator>().Object;
        }

        [Fact]
        public async Task TestWithAuthentication()
        {
            var token = _authenticatorMock.CreateToken(Guid.NewGuid(), "admin").ToString();

            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("/api/fields");

            // Your assertions based on the response
        }
    }
}