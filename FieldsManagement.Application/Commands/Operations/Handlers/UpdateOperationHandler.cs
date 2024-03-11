using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Operations.Handlers;

public class UpdateOperationHandler(IOperationRepository operationRepository) : INotificationHandler<UpdateOperation>
{
    public async Task Handle(UpdateOperation notification, CancellationToken cancellationToken)
    {
        var operation = await operationRepository.GetByOperationId(notification.OperationId);

        if (operation == null)
        {
            throw new ApplicationException("Operation not found");
        }

        operation.Update(notification.OperationName, notification.Description, notification.Date);

        await operationRepository.Update(operation);
    }
}