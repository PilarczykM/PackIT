using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature
{
    public class LowTemperaturePolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Winter hat", 1),
                new("Gloves", 1),
                new("Cream", 1)
            };

        public bool IsApplicable(PolicyData policyData)
            => policyData.Temperature <= 20;
    }
}

