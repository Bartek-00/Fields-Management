using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Users.Handlers;

public class DeleteWorkerHandler(IWorkerRespository workerRespository) : INotificationHandler<DeleteWorker>
{
    public async Task Handle(DeleteWorker notification, CancellationToken cancellationToken)
    {
        await workerRespository.Delete(notification.Id);
    }
}