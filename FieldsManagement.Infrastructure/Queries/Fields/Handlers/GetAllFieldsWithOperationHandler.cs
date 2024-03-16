using FieldsManagement.Application.DTO;
using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.Repositories;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Fields.Handlers;

public class GetAllFieldsWithOperationHandler(IFieldsRepository fieldRepository, IOperationRepository operationRepository) : IRequestHandler<GetAllFieldsWithOperationQuery, IEnumerable<FieldDTO>>
{
    public async Task<IEnumerable<FieldDTO>> Handle(GetAllFieldsWithOperationQuery request, CancellationToken cancellationToken)
    {
        var fields = await fieldRepository.GetAll();
        var fieldDTOs = new List<FieldDTO>();

        foreach (var field in fields)
        {
            var operations = await operationRepository.GetAllByFieldId(field.FieldId);

            var fieldDTO = new FieldDTO
            {
                FieldId = field.FieldId,
                VillageName = field.VillageName,
                Area = field.Area,
                AdditionalData = field.AdditionalData,
                Actions = operations
            };

            fieldDTOs.Add(fieldDTO);
        }

        return fieldDTOs;
    }
}