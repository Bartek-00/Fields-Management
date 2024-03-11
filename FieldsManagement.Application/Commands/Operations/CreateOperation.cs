using FieldsManagement.Core.ValueObjects;
using MediatR;

namespace FieldsManagement.Application.Commands.Operations;

public record CreateOperation(ObjectId FieldId, string OperationName, string Description, DateTime Date) : INotification;