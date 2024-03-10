using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries;

public record GetAllFieldsQuery : IRequest<List<Field>>;