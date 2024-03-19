using FieldsManagement.Application.Commands.Login;
using MediatR;
using MySpot.Application.Abstractions;
using MySpot.Application.Exceptions;
using MySpot.Application.Security;
using MySpot.Core.Abstractions;
using MySpot.Core.Entities;
using MySpot.Core.Repositories;
using MySpot.Core.ValueObjects;

namespace MySpot.Application.Commands.Handlers;

internal sealed class SignUpHandler : INotificationHandler<SignUp>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;

    public SignUpHandler(IUserRepository userRepository, IPasswordManager passwordManager, IClock clock)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
        _clock = clock;
    }

    public async Task Handle(SignUp notification, CancellationToken cancellationToken)
    {
        var userId = new UserId(notification.UserId);
        var email = new Email(notification.Email);
        var username = new Username(notification.Username);
        var password = new Password(notification.Password);
        var fullName = new FullName(notification.FullName);
        var role = string.IsNullOrWhiteSpace(notification.Role) ? Role.User() : new Role(notification.Role);

        if (await _userRepository.GetByEmailAsync(email) is not null)
        {
            throw new Exception(email);
        }

        if (await _userRepository.GetByUsernameAsync(username) is not null)
        {
            throw new Exception(username);
        }

        var securedPassword = _passwordManager.Secure(password);
        var user = new User(userId, email, username, securedPassword, fullName, role, _clock.Current());
        await _userRepository.AddAsync(user);
    }
}