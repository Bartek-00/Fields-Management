using MediatR;

namespace FieldsManagement.Application.Commands.Login;

public record SignUp(string Email, string Username, string Password, string FullName, string Role) : INotification
{
    public Guid UserId { get; set; } = Guid.NewGuid();
}