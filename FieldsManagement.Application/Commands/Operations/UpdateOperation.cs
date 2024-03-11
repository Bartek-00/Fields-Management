using MediatR;

namespace FieldsManagement.Application.Commands.Operations;

public record UpdateOperation(ObjectId OperationId, ObjectId FieldId, string OperationName, string Description, DateTime Date) : INotification;