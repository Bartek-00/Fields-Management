using MediatR;

namespace FieldsManagement.Application.Commands.Operations;

public record UpdateOperation(Guid OperationId, Guid FieldId, string OperationName, string Description, DateTime Date) : INotification;