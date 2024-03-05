using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries;
public record GetByVillageQuery(string VillageName) : IRequest<List<Fields>>;