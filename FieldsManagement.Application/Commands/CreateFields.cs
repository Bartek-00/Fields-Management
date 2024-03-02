using CoreRock.Shared.CQRS.Abstractions;
using FieldsManagement.Core.Entities;

namespace FieldsManagement.Application.Commands;

public record CreateFields(string Id, string VillageName, double Area, string additionalData) : ICommand;