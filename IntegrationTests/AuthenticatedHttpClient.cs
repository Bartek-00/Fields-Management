using FieldsManagement.Application.Security;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

public interface IAuthenticatedHttpClient
{
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default);
}

public class AuthenticatedHttpClient : IAuthenticatedHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorage _tokenStorage;

    public AuthenticatedHttpClient(HttpClient httpClient, ITokenStorage tokenStorage)
    {
        _httpClient = httpClient;
        _tokenStorage = tokenStorage;
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        // Get token from storage
        var token = _tokenStorage.Get();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.ToString());

        // Send the request using configured HttpClient
        return await _httpClient.SendAsync(request, cancellationToken);
    }
}

public class AuthenticatedHttpClientHandler : DelegatingHandler
{
    private readonly IAuthenticatedHttpClient _authenticatedHttpClient;

    public AuthenticatedHttpClientHandler(IAuthenticatedHttpClient authenticatedHttpClient)
    {
        _authenticatedHttpClient = authenticatedHttpClient;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Call the authenticated HTTP client to send the request
        return await _authenticatedHttpClient.SendAsync(request, cancellationToken);
    }
}