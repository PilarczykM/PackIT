using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Temperature
{
    public class HeighTemperaturePolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Hat", 1),
                new("Sunglesses", 1),
                new("Cream with UV filter", 1)
            };

        public bool IsApplicable(PolicyData policyData)
            => policyData.Temperature > 20;
    }
}

