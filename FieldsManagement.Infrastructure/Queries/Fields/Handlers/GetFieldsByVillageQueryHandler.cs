using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.Queries.Fields;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Fields.Handlers;

public class GetFieldsByVillageQueryHandler(IFieldsRepository fieldsRepository) : IRequestHandler<GetFieldsByVillageQuery, List<Field>>
{
    public async Task<List<Field>> Handle(GetFieldsByVillageQuery request, CancellationToken cancellationToken = default)
    {
        return await fieldsRepository.FindByVillageName(request.VillageName);
    }
}