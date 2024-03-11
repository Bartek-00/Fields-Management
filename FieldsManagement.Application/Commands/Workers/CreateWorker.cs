using FieldsManagement.Core.ValueObjects;
using MediatR;

namespace FieldsManagement.Application.Commands.Users;

public record CreateWorker(Guid objectId, WorkerName workerName, WorkerSurname workerSurname, string additionalData) : INotification;