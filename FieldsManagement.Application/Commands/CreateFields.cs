using MediatR;

namespace FieldsManagement.Application.Commands;

public record CreateFields(Guid Id, string VillageName, double Area, string AdditionalData) : INotification;