using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Users.Handlers;

public class CreateWorkerHandler(IWorkerRespository workerRespository) : INotificationHandler<CreateWorker>
{
    public async Task Handle(CreateWorker notification, CancellationToken cancellationToken)
    {
        await workerRespository.Create(new Worker(notification.WorkerId, notification.workerName, notification.workerSurname, notification.additionalData));
    }
}