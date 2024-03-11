using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.Queries.Fields;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Handlers;

public class GetAllFieldsQueryHandler(IFieldsRepository fieldsRepository) : IRequestHandler<GetAllFieldsQuery, List<Field>>
{
    public async Task<List<Field>> Handle(GetAllFieldsQuery request, CancellationToken cancellationToken = default)
    {
        return await fieldsRepository.GetAll();
    }
}