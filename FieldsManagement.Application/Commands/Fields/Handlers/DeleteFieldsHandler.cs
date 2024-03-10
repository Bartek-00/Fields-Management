using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Fields.Handlers;

public class DeleteFieldsHandler(IFieldsRepository fieldsRepository) : INotificationHandler<DeleteFields>
{
    public async Task Handle(DeleteFields notification, CancellationToken cancellationToken = default)
    {
        await fieldsRepository.Delete(notification.Id);
    }
}