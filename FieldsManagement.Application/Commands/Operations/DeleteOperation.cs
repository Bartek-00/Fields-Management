using MediatR;

namespace FieldsManagement.Application.Commands.Operations;
public record DeleteOperation(Guid OperationId) : INotification;