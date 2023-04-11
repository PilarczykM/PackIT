using PackIT.Domain.Consts;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies
{
    public record PolicyData(TravelDays Days, GenderEnum Gender, ValueObjects.Temperature Temperature, Localization Localization)
    {
    }
}
