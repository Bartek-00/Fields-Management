using FieldsManagement.Core.Exceptions;

namespace FieldsManagement.Core.ValueObjects
{
    public sealed record OperationName
    {
        public string Value { get; }

        public OperationName(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100 || value.Length < 3)
            {
                throw new InvalidNameException();
            }

            Value = value;
        }

        public static implicit operator string(OperationName name)
            => name.Value;

        public static implicit operator OperationName(string value)
            => new OperationName(value);
    }
}