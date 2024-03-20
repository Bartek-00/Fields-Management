using MediatR;

namespace FieldsManagement.Application.Commands.Login;

public record SignUp(Guid UserId, string Email, string Username, string Password, string FullName, string Role) : INotification;