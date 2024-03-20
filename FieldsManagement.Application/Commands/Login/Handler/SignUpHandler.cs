using FieldsManagement.Application.Commands.Login;
using FieldsManagement.Core.Abstractions;
using FieldsManagement.Core.Entities;
using FieldsManagement.Core.ValueObjects;
using MediatR;
using MySpot.Application.Security;
using MySpot.Core.Repositories;

namespace FieldsManagement.Application.Commands.Login.Handler;

public sealed class SignUpHandler(IUsersRepository userRepository, IPasswordManager passwordManager, IClock clock) : INotificationHandler<SignUp>
{
    public async Task Handle(SignUp notification, CancellationToken cancellationToken)
    {
        var userId = new UserId(notification.UserId);
        var email = new Email(notification.Email);
        var username = new Username(notification.Username);
        var password = new Password(notification.Password);
        var fullName = new FullName(notification.FullName);
        var role = string.IsNullOrWhiteSpace(notification.Role) ? Role.User() : new Role(notification.Role);

        if (await userRepository.GetByEmailAsync(email) is not null)
        {
            throw new Exception(email);
        }

        if (await userRepository.GetByUsernameAsync(username) is not null)
        {
            throw new Exception(username);
        }

        var securedPassword = passwordManager.Secure(password);
        var user = new User(userId, email, username, securedPassword, fullName, role, clock.Current());
        await userRepository.AddAsync(user);
    }
}