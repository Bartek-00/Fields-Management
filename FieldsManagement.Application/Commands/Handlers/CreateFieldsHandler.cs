using CoreRock.Shared.CQRS.Handlers;
using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;

namespace FieldsManagement.Application.Commands.Handlers;

public class CreateFieldsHandler(IFieldsRepository fieldsRepository) : ICommandHandler<CreateFields>
{
    public async Task HandleAsync(CreateFields command, CancellationToken cancellationToken = default)
    {
        await fieldsRepository.Create(new Fields(command.Id, command.VillageName, command.Area, command.additionalData));
    }
}