using FieldsManagement.Core.Exceptions;

namespace FieldsManagement.Core.ValueObjects
{
    public sealed record WorkerSurname
    {
        public string Value { get; }

        public WorkerSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname) || surname.Length > 100 || surname.Length < 3)
            {
                throw new InvalidNameException();
            }

            Value = surname;
        }

        public static implicit operator string(WorkerSurname surname)
            => surname.Value;

        public static implicit operator WorkerSurname(string value)
            => new WorkerSurname(value);
    }
}