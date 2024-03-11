using MediatR;

namespace FieldsManagement.Application.Commands;

public record CreateField(Guid Id, string VillageName, double Area, string AdditionalData) : INotification;