﻿using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Application.Commands.Fields.Handlers;

public class UpdateFieldsHandler(IFieldsRepository fieldsRepository) : INotificationHandler<UpdateField>
{
    public async Task Handle(UpdateField notification, CancellationToken cancellationToken = default)
    {
        var data = await fieldsRepository.FindById(notification.Id);
        if (data == null)
        {
            throw new Exception("Nie ma takiego pola w bazie");
        }
        await fieldsRepository.Update(new Field(notification.Id, data.VillageName, data.Area, notification.AdditionalData));
    }
}