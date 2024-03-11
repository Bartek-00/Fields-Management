using MediatR;

namespace FieldsManagement.Application.Commands.Operations;
public record DeleteOperation(ObjectId OperationId) : INotification;