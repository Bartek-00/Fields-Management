using FieldsManagement.Core.Entities;
using MediatR;

namespace FieldsManagement.Infrastructure.Queries.Fields;
public record GetFieldsByVillageQuery(string VillageName) : IRequest<List<Field>>;