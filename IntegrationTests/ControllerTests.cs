using FieldsManagement.Application.DTO;
using FieldsManagement.Application.Security;
using FieldsManagement.Core.Abstractions;
using FieldsManagement.Infrastructure.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

public abstract class ControllerTests
{
    private readonly IAuthenticator _authenticator;
    protected HttpClient Client { get; }

    protected JwtDto Authorize(Guid userId, string role)
    {
        var jwt = _authenticator.CreateToken(userId, role);
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.AccessToken);

        return jwt;
    }

    public ControllerTests(IClock clock, IConfiguration configuration)
    : this(clock, new Authenticator(new OptionsWrapper<AuthOptions>(configuration.GetSection("auth").Get<AuthOptions>()), clock))
    {
    }

    // Constructor with parameters
    protected ControllerTests(IClock clock, IAuthenticator authenticator)
    {
        _authenticator = authenticator;
        Client = new HttpClient(); // Initialize HttpClient here or in derived classes
    }
}