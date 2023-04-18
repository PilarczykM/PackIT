using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Application.Exceptions
{
    internal class MissingLocalizationWeatherException : PackItException
    {
        public Localization Localization { get; }
        public MissingLocalizationWeatherException(Localization localization) : base($"Couldn't featch weather data for localization '${localization.Country}/${localization.City}'")
        {
            Localization = localization;
        }
    }
}
