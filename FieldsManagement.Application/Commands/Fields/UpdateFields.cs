using MediatR;

namespace FieldsManagement.Application.Commands;

public record UpdateFields(ObjectId Id, string AdditionalData) : INotification;