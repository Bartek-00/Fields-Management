using FieldsManagement.Core.ValueObjects;
using MediatR;

namespace FieldsManagement.Application.Commands.Operations;

public record CreateOperation(ObjectId FieldId, string operationName, string description, DateTime date) : INotification;