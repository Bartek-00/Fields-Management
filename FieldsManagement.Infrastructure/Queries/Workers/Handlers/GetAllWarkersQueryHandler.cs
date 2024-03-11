using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.Queries.Workers;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Workers.Handlers;

public class GetAllWarkersQueryHandler(IWorkerRespository workerRespository) : IRequestHandler<GetAllWarkersQuery, List<Worker>>
{
    public async Task<List<Worker>> Handle(GetAllWarkersQuery request, CancellationToken cancellationToken = default)
    {
        return await workerRespository.GetAll();
    }
}