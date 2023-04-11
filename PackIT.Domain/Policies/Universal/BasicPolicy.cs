using PackIT.Domain.Consts;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Universal
{
    internal sealed class BasicPolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>()
            {
                new("Pants", Math.Min(data.Days, Constants.MAX_QUANTITY_OF_CLOTHES)),
                new("Socks", Math.Min(data.Days, Constants.MAX_QUANTITY_OF_CLOTHES)),
                new("T-Shirt", Math.Min(data.Days, Constants.MAX_QUANTITY_OF_CLOTHES)),
                new("Trousers", data.Days < 7 ? 1u : 2u),
                new("Shampoo", 1),
                new("Toothbrash", 1),
                new("Toothpaste", 1),
                new("Towel", 1),
                new("Passport", 1),
                new("Phone charger", 1),
                new("Bag pack", 1),
            };

        public bool IsAplicable(PolicyData _) => true;
    }
}
