using FieldsManagement.Core.Exceptions;

namespace FieldsManagement.Core.ValueObjects
{
    public sealed record WorkerName
    {
        public string Value { get; }

        public WorkerName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100 || value.Length < 3)
            {
                throw new InvalidNameException();
            }

            Value = value;
        }

        public static implicit operator string(WorkerName name)
            => name.Value;

        public static implicit operator WorkerName(string value)
            => new WorkerName(value);
    }
}