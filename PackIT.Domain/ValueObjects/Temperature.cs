using PackIT.Domain.Consts;
using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record Temperature
    {
        public double Value { get; }

        public Temperature(double value)
        {
            if (value < Constants.MAX_TEMPERATURE || value > Constants.MIN_TEMPERATURE)
            {
                throw new InvalidTemperatureValuesException(value);
            }

            Value = value;
        }

        public static implicit operator Temperature(ushort value) => new(value);
        public static implicit operator double(Temperature value) => value.Value;
    }
}
