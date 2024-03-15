using FieldsManagement.Core.ValueObjects;
using MediatR;

namespace FieldsManagement.Application.Commands.Users;

public record CreateWorker(WorkerName workerName, WorkerSurname workerSurname, string additionalData) : INotification
{
    public Guid WorkerId { get; } = Guid.NewGuid();
}