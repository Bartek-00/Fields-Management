using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Handlers;

public class DeleteFieldsHandler(IFieldsRepository fieldsRepository) : INotificationHandler<DeleteFields>
{
    public async Task Handle(DeleteFields notification, CancellationToken cancellationToken = default)
    {
        fieldsRepository.Delete(notification.Id);
    }
}