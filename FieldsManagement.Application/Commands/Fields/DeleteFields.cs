using MediatR;

namespace FieldsManagement.Application.Commands.Fields;

public record DeleteFields(Guid Id) : INotification;