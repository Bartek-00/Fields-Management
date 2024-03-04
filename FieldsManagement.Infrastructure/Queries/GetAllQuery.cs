using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries;

public class GetAllQuery() : IRequest<List<Fields>>
{
}