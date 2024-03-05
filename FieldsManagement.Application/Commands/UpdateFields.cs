using MediatR;

namespace FieldsManagement.Application.Commands;

public record UpdateFields(Guid Id, string AdditionalData) : INotification;