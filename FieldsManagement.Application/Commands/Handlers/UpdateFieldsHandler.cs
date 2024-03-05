using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Handlers;

public class UpdateFieldsHandler(IFieldsRepository fieldsRepository) : INotificationHandler<UpdateFields>
{
    public async Task Handle(UpdateFields notification, CancellationToken cancellationToken = default)
    {
        var data = await fieldsRepository.FindById(notification.Id);
        if (data == null)
        {
            throw new Exception("Nie ma takiego pola w bazie");
        }
        await fieldsRepository.Update(new Fields(notification.Id, data.VillageName, data.Area, notification.AdditionalData));
    }
}