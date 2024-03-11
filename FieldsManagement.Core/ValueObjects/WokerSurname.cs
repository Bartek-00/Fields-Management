using FieldsManagement.Core.Exceptions;

namespace FieldsManagement.Core.ValueObjects
{
    public sealed record WorkerSurname
    {
        public string Value { get; }

        public WorkerSurname(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100 || value.Length < 3)
            {
                throw new InvalidNameException();
            }

            Value = value;
        }

        public static implicit operator string(WorkerSurname value)
            => value.Value;

        public static implicit operator WorkerSurname(string value)
            => new WorkerSurname(value);
    }
}