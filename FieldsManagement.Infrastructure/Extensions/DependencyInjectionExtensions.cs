using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.Queries.Handlers;
using FieldsManagement.Infrastructure.Repositories;
using MediatR;
using MongoDB.Driver;
using FieldsManagement.Infrastructure.Queries.Fields;
using FieldsManagement.Infrastructure.Queries.Workers;
using FieldsManagement.Infrastructure.Queries.Fields.Handlers;
using FieldsManagement.Infrastructure.Queries.Workers.Handlers;
using FieldsManagement.Infrastructure.Queries.Operations;
using FieldsManagement.Infrastructure.Queries.Handler;
using FieldsManagement.Infrastructure.Queries.Operations.Handlers;

namespace FieldsManagement.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            //services.Configure<DataBaseConfiguration>(configuration.GetSection("DatabaseConfiguration"));
            services.AddHttpClient();
            services.AddMongo(configuration);

            services.AddTransient<IFieldsRepository, FieldsRepository>();
            services.AddTransient<IWorkerRespository, WorkersRepository>();
            services.AddTransient<IOperationRepository, OperationsRepository>();

            services.AddScoped<IRequestHandler<GetAllFieldsQuery, List<Field>>, GetAllFieldsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllWarkersQuery, List<Worker>>, GetAllWarkersQueryHandler>();
            services.AddScoped<IRequestHandler<GetFieldsByVillageQuery, List<Field>>, GetFieldsByVillageQueryHandler>();
            services.AddScoped<IRequestHandler<GetOperationsByFieldIdQuery, List<Operation>>, GetOperationsByFieldIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetOperationsQuery, List<Operation>>, GetOperationsQueryHandler>();

            return services;
        }
    }
}