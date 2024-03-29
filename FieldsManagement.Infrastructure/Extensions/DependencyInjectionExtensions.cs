using FieldsManagement.Application.DTO;
using FieldsManagement.Core.Abstractions;
using FieldsManagement.Core.Entities;
using FieldsManagement.Core.Repositories;
using FieldsManagement.Infrastructure.Auth;
using FieldsManagement.Infrastructure.Queries.Fields;
using FieldsManagement.Infrastructure.Queries.Fields.Handlers;
using FieldsManagement.Infrastructure.Queries.Handler;
using FieldsManagement.Infrastructure.Queries.Handlers;
using FieldsManagement.Infrastructure.Queries.Operations;
using FieldsManagement.Infrastructure.Queries.Operations.Handlers;
using FieldsManagement.Infrastructure.Queries.Users;
using FieldsManagement.Infrastructure.Queries.Users.Handler;
using FieldsManagement.Infrastructure.Queries.Workers;
using FieldsManagement.Infrastructure.Queries.Workers.Handlers;
using FieldsManagement.Infrastructure.Repositories;
using FieldsManagement.Infrastructure.Security;
using FieldsManagement.Infrastructure.Time;
using MediatR;
using MySpot.Core.Repositories;

namespace FieldsManagement.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddHttpClient();
            services.AddMongo(configuration);
            services.AddAuth(configuration);
            services.AddSecurity();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IClock, Clock>();

            services.AddTransient<IFieldsRepository, FieldsRepository>();
            services.AddTransient<IWorkerRespository, WorkersRepository>();
            services.AddTransient<IOperationRepository, OperationsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddScoped<IRequestHandler<GetAllFieldsQuery, List<Field>>, GetAllFieldsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllWarkersQuery, List<Worker>>, GetAllWarkersQueryHandler>();
            services.AddScoped<IRequestHandler<GetFieldsByVillageQuery, List<Field>>, GetFieldsByVillageQueryHandler>();
            services.AddScoped<IRequestHandler<GetOperationsByFieldIdQuery, List<Operation>>, GetOperationsByFieldIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetOperationsQuery, List<Operation>>, GetOperationsQueryHandler>();
            services.AddScoped<IRequestHandler<GetAllFieldsWithOperationQuery, IEnumerable<FieldDTO>>, GetAllFieldsWithOperationHandler>();
            services.AddScoped<IRequestHandler<GetUser, User>, GetUserHandler>();
            services.AddScoped<IRequestHandler<GetUsers, IEnumerable<User>>, GetUsersHandler>();

            return services;
        }
    }
}