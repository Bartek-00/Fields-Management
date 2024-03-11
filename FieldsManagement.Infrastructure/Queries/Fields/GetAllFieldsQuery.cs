using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Fields;

public record GetAllFieldsQuery : IRequest<List<Field>>;