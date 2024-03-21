using FieldsManagement.Core.ValueObjects;
using MediatR;

namespace FieldsManagement.Application.Commands.Operations;

public record CreateOperation(Guid FieldId, string PlantName, string OperationName, string Description, DateTime Date) : INotification
{
    public Guid OperationId { get; } = Guid.NewGuid();
}