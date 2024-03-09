using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries;

public record GetAllQuery : IRequest<List<Field>>;