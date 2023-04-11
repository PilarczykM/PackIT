using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature
{
    internal sealed class LowTemperaturePolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("Winter hat", 1),
                new("Gloves", 1),
                new("Hoodie", 1),
                new("Scarf", 1),
            };

        public bool IsAplicable(PolicyData data) => data.Temperature < 100;
    }
}
