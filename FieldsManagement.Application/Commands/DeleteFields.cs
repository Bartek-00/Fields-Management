using MediatR;

namespace FieldsManagement.Application.Commands;

public record DeleteFields(Guid Id) : INotification;