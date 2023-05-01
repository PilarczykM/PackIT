using PackIT.Application.DTO;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static PackingListDto AsDto(this PackingListReadModel readModel)
        {
            return new()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Localization = new LocalizationDto
                {
                    City = readModel.Localization.City,
                    Country = readModel.Localization.Country
                },
                Items = readModel.Items?.Select(pi => new PackingItemDto
                {
                    Name = pi.Name,
                    Quentity = pi.Quentity,
                    IsPacked = pi.IsPacked
                })
            };
        }
    }
}

