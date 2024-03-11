using MediatR;

namespace FieldsManagement.Application.Commands.Users;

public record DeleteWorker(Guid Id) : INotification;