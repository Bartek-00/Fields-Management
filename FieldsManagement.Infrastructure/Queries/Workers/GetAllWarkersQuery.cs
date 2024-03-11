using Amazon.Runtime.Internal;
using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Workers;

public record GetAllWarkersQuery : IRequest<List<Worker>>;