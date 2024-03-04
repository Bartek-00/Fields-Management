using MediatR;

namespace FieldsManagement.Application.Commands;

public record CreateFields(string Id, string VillageName, double Area, string AdditionalData) : INotification
{
}