using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Operations;

public record GetOperationsQuery : IRequest<List<Operation>>;