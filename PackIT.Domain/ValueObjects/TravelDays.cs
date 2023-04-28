using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record TravelDays
    {
        public ushort Value { get; }

        public TravelDays(ushort value)
        {
            const ushort maxTravelDay = 100;
            if (value is 0 or > maxTravelDay)
            {
                throw new InvalidTravelDaysException(value);
            }

            Value = value;
        }

        public static implicit operator ushort(TravelDays days) => days.Value;
        public static implicit operator TravelDays(ushort days) => new(days);
    }
}

