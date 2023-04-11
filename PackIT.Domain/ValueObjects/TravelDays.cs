using PackIT.Domain.Consts;
using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record TravelDays
    {
        public ushort Value { get; }

        public TravelDays(ushort value)
        {
            if (value is 0 || value > Constants.MAX_TRAVEL_DAY)
            {
                throw new InvalidTravelDaysException(value);
            }

            Value = value;
        }

        public static implicit operator TravelDays(ushort value) => new(value);
        public static implicit operator ushort(TravelDays value) => value.Value;
    }
}
