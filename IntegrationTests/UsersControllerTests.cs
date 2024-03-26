using FieldsManagement.Application.Commands.Login;
using FieldsManagement.Application.DTO;
using FieldsManagement.Application.Security;
using FieldsManagement.Core.Entities;
using FieldsManagement.Core.ValueObjects;
using FieldsManagement.Infrastructure.Security;
using FieldsManagement.Infrastructure.Time;
using FluentAssertions;
using IntegrationTests.Factory;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Application.Security;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace FieldsManagement.IntegrationTests
{
    public class UsersControllerTests : IClassFixture<FieldsManagementWebAplicationFactory>
    {
        private readonly FieldsManagementWebAplicationFactory _webAppFactory;
        private readonly IAuthenticator _authenticator;
        private readonly IPasswordManager _passwordManager;

        public UsersControllerTests(FieldsManagementWebAplicationFactory webAppFactory, ITestOutputHelper testOutputHelper, IAuthenticator authenticator, IPasswordManager passwordManager)
        {
            _webAppFactory = webAppFactory;
            _webAppFactory.Output = testOutputHelper;
            _authenticator = webAppFactory.Services.GetRequiredService<IAuthenticator>();
            _passwordManager = webAppFactory.Services.GetRequiredService<IPasswordManager>();
        }

        [Fact]
        public async Task PostUser_ReturnCreated()
        {
            var client = _webAppFactory.CreateClient();
            var command = new SignUp("test-user1@myspot.io", "test-user1", "secret",
                "Test Doe", "user");
            var response = await client.PostAsJsonAsync("/Users", command);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task PostAndSignIn_ReturnCreatedAndOk()
        {
            var client = _webAppFactory.CreateClient();
            var clock = new Clock();
            const string password = "secret";

            var user = new SignUp("test-user1@myspot.io", "test-user1", _passwordManager.Secure(password), "Test Doe", Role.User());
            var response = await client.PostAsJsonAsync("/Users", user);

            var command = new SignIn(user.Email, password);
            var signInResponse = await client.PostAsJsonAsync("/Users/sign-in", command);
            signInResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var jwt = await signInResponse.Content.ReadFromJsonAsync<JwtDto>();

            jwt.Should().NotBeNull();
        }

        [Fact]
        public async Task GetUserMe_ReturnMyAccount()
        {
            var client = _webAppFactory.CreateClient();
            var passwordManager = new PasswordManager(new PasswordHasher<User>());
            var clock = new Clock();
            const string password = "secret";

            var user = new User(Guid.NewGuid(), "test-user1@myspot.io",
                "test-user1", passwordManager.Secure(password), "Test Doe", Role.User(), clock.Current());

            var response = await client.PostAsJsonAsync("/Users", user);

            var userDto = await client.GetFromJsonAsync<UserDto>("users/me");

            userDto.Should().NotBeNull();
            userDto.Id.Should().Be(user.Id.Value);
        }

        [Fact]
        public async Task CreateAuthenticatedClient_Created()
        {
            var userId = Guid.NewGuid();
            var client = Authorize(userId, Role.User().Value);

            client.DefaultRequestHeaders.Authorization.Scheme.Should().Be("Bearer");
        }

        protected HttpClient Authorize(Guid userId, string role)
        {
            var client = _webAppFactory.CreateClient();
            var jwt = _authenticator.CreateToken(userId, role);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.AccessToken);

            return client;
        }
    }
}