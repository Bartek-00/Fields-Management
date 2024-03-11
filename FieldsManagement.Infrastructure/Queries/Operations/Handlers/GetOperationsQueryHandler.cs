using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.Queries.Operations;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Operations.Handlers;

public class GetOperationsQueryHandler(IOperationRepository operationRepository) : IRequestHandler<GetOperationsQuery, List<Operation>>
{
    public async Task<List<Operation>> Handle(GetOperationsQuery request, CancellationToken cancellationToken)
    {
        return await operationRepository.GetAll();
    }
}