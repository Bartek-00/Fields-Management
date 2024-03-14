using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Operations.Handlers;

public class GetOperationsQueryHandler(IOperationRepository operationRepository) : IRequestHandler<GetOperationsQuery, List<Operation>>
{
    public async Task<List<Operation>> Handle(GetOperationsQuery request, CancellationToken cancellationToken)
    {
        var a = await operationRepository.GetAll();
        return await operationRepository.GetAll();
    }
}