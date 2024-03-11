using MediatR;

namespace FieldsManagement.Application.Commands.Fields;

public record DeleteField(Guid Id) : INotification;