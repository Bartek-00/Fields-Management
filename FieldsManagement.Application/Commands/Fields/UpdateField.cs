using MediatR;

namespace FieldsManagement.Application.Commands;

public record UpdateField(Guid Id, string AdditionalData) : INotification;