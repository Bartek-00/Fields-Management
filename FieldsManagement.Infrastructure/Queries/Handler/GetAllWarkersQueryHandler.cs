using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Handler;

public class GetAllWarkersQueryHandler(IWorkerRespository workerRespository) : IRequestHandler<GetAllWarkersQuery, List<Worker>>
{
    public async Task<List<Worker>> Handle(GetAllWarkersQuery request, CancellationToken cancellationToken = default)
    {
        return await workerRespository.GetAll();
    }
}