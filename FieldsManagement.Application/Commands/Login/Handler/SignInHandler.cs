using FieldsManagement.Application.Security;
using MediatR;
using MySpot.Application.Security;
using MySpot.Core.Repositories;

namespace FieldsManagement.Application.Commands.Login.Handler;

public sealed class SignInHandler(IUsersRepository userRepository, IAuthenticator authenticator, IPasswordManager passwordManager,
        ITokenStorage tokenStorage) : INotificationHandler<SignIn>
{
    public async Task Handle(SignIn command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(command.Email);
        if (user is null)
        {
            throw new Exception();
        }
        if (!passwordManager.Validate(command.Password, user.Password))
        {
            throw new Exception();
        }

        var jwt = authenticator.CreateToken(user.Id, user.Role);
        tokenStorage.Set(jwt);
    }
}