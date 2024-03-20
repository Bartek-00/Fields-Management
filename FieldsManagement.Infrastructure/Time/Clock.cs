using FieldsManagement.Core.Abstractions;

namespace FieldsManagement.Infrastructure.Time;

internal sealed class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}