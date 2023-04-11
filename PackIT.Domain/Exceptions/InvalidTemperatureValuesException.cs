using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class InvalidTemperatureValuesException : PackItException
    {
        public double Temperature { get; }
        public InvalidTemperatureValuesException(double value) : base($"Value '${value}' is invalid temperature.")
            => Temperature = value;
    }
}
