using MediatR;

namespace FieldsManagement.Application.Commands;

public record UpdateField(ObjectId Id, string AdditionalData) : INotification;