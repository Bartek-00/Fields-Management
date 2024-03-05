using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Handler;

public class GetByVillageQueryHandler(IFieldsRepository fieldsRepository) : IRequestHandler<GetByVillageQuery, List<Fields>>
{
    public async Task<List<Fields>> Handle(GetByVillageQuery request, CancellationToken cancellationToken = default)
    {
        return await fieldsRepository.FindByVillageName(request.VillageName);
    }
}