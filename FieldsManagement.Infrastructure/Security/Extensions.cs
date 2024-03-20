using FieldsManagement.Core.Entities;
using Microsoft.AspNetCore.Identity;
using MySpot.Application.Security;

namespace FieldsManagement.Infrastructure.Security;

internal static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddSingleton<IPasswordManager, PasswordManager>();

        return services;
    }
}