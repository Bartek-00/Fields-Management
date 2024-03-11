﻿using MediatR;

namespace FieldsManagement.Application.Commands;

public record CreateField(ObjectId Id, string VillageName, double Area, string AdditionalData) : INotification;