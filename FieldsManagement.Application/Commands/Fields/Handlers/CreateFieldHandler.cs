using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Fields.Handlers;

public class CreateFieldHandler(IFieldsRepository fieldsRepository) : INotificationHandler<CreateField>
{
    public async Task Handle(CreateField notification, CancellationToken cancellationToken = default)
    {
        await fieldsRepository.Create(new Field(notification.Id, notification.VillageName, notification.Area, notification.AdditionalData));
    }
}