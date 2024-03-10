using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Fields.Handlers;

public class CreateFieldsHandler(IFieldsRepository fieldsRepository) : INotificationHandler<CreateFields>
{
    public async Task Handle(CreateFields notification, CancellationToken cancellationToken = default)
    {
        await fieldsRepository.Create(new Field(notification.Id, notification.VillageName, notification.Area, notification.AdditionalData));
    }
}