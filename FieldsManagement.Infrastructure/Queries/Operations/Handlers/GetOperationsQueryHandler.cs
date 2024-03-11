using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.Queries.Operations;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Operations.Handlers;

public class GetOperationsQueryHandler(IOperationRepository operationRepository) : IRequestHandler<GetOperationsQuery, IEnumerable<Operation>>
{
    public async Task<IEnumerable<Operation>> Handle(GetOperationsQuery request, CancellationToken cancellationToken)
    {
        return await operationRepository.GetAll();
    }
}