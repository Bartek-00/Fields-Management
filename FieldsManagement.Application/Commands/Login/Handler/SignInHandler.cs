using FieldsManagement.Application.Commands.Login;
using FieldsManagement.Application.Security;
using MediatR;
using MySpot.Application.Security;
using MySpot.Core.Repositories;

namespace FieldsManagement.Application.Commands.Login.Handler;

internal sealed class SignInHandler : INotificationHandler<SignIn>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticator _authenticator;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenStorage _tokenStorage;

    public SignInHandler(IUserRepository userRepository, IAuthenticator authenticator, IPasswordManager passwordManager,
        ITokenStorage tokenStorage)
    {
        _userRepository = userRepository;
        _authenticator = authenticator;
        _passwordManager = passwordManager;
        _tokenStorage = tokenStorage;
    }

    public async Task Handle(SignIn command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(command.Email);
        if (user is null)
        {
            throw new Exception();
        }

        if (!_passwordManager.Validate(command.Password, user.Password))
        {
            throw new Exception();
        }

        var jwt = _authenticator.CreateToken(user.Id, user.Role);
        _tokenStorage.Set(jwt);
    }
}