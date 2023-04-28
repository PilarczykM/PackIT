using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record Temperature
    {
        public double Value { get; }
        public Temperature(double value)
        {
            const double minTemperature = -100;
            const double maxTemperature = 100;

            if (value is < minTemperature or > maxTemperature)
            {
                throw new InvalidTemperatureException(value);
            }

            Value = value;
        }

        public static implicit operator double(Temperature temperature) => temperature.Value;
        public static implicit operator Temperature(double temperature) => new(temperature);
    }
}

