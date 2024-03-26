using FieldsManagement.Core.Abstractions;

namespace FieldsManagement.Infrastructure.Time;

public sealed class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}