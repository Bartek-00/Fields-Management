using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Fields.Handlers;

public class DeleteFieldHandler(IFieldsRepository fieldsRepository) : INotificationHandler<DeleteField>
{
    public async Task Handle(DeleteField notification, CancellationToken cancellationToken = default)
    {
        await fieldsRepository.Delete(notification.Id);
    }
}