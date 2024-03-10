using FieldsManagement.Core.ValueObjects;
using MediatR;

namespace FieldsManagement.Application.Commands.Users;

public record CreateWorker(ObjectId objectId, WorkerName workerName, WorkerSurname workerSurname, string additionalData) : INotification;