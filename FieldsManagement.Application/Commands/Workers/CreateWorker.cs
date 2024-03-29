using FieldsManagement.Core.ValueObjects;
using MediatR;

namespace FieldsManagement.Application.Commands.Users;

public record CreateWorker(WorkerName WorkerName, WorkerSurname WorkerSurname, string AdditionalData) : INotification
{
    public Guid WorkerId { get; } = Guid.NewGuid();
}