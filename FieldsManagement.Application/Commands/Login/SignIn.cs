using MediatR;

namespace FieldsManagement.Application.Commands.Login;

public record SignIn(string Email, string Password) : INotification;