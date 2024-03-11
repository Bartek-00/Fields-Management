using FieldsManagement.Core.ValueObjects;
using MediatR;

namespace FieldsManagement.Application.Commands.Operations;

public record CreateOperation(Guid OperationFieldId, string OperationName, string Description, DateTime Date) : INotification
{
    public Guid OperationId { get; } = Guid.NewGuid();
}