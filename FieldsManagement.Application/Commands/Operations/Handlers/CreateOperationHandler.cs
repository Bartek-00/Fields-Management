using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Operations.Handlers;

public class CreateOperationHandler(IOperationRepository operationRepository) : INotificationHandler<CreateOperation>
{
    public async Task Handle(CreateOperation notification, CancellationToken cancellationToken)
    {
        await operationRepository.Create(new Operation(notification.OperationId, notification.OperationFieldId, notification.OperationName, notification.Description, notification.Date));
    }
}