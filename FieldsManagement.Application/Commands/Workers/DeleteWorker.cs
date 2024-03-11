using MediatR;

namespace FieldsManagement.Application.Commands.Users;

public record DeleteWorker(ObjectId Id) : INotification;