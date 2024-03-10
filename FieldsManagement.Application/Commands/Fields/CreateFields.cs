using MediatR;

namespace FieldsManagement.Application.Commands;

public record CreateFields(ObjectId Id, string VillageName, double Area, string AdditionalData) : INotification;