using Microsoft.AspNetCore.Authentication;

namespace FieldsManagement.Infrastructure.Auth;

public sealed class AuthOptions : AuthenticationSchemeOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SigningKey { get; set; }
    public TimeSpan? Expiry { get; set; }
}