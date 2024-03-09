using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Handlers;

public class GetAllQueryHandler(IFieldsRepository fieldsRepository) : IRequestHandler<GetAllQuery, List<Field>>
{
    public async Task<List<Field>> Handle(GetAllQuery request, CancellationToken cancellationToken = default)
    {
        return await fieldsRepository.GetAll();
    }
}