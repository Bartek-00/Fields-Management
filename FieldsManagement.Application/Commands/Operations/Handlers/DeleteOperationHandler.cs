using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Operations.Handlers;

public class DeleteOperationHandler(IOperationRepository operationRepository) : INotificationHandler<DeleteOperation>
{
    public async Task Handle(DeleteOperation notification, CancellationToken cancellationToken)
    {
        await operationRepository.Delete(notification.OperationId);
    }
}