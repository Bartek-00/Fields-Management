using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.Queries.Operations;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Handler;

public class GetOperationsByFieldIdQueryHandler(IOperationRepository operationRepository) : IRequestHandler<GetOperationsByFieldIdQuery, List<Operation>>
{
    public async Task<List<Operation>> Handle(GetOperationsByFieldIdQuery request, CancellationToken cancellationToken)
    {
        return await operationRepository.GetAllByFieldId(request.FieldId);
    }
}