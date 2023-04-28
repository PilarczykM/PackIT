using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Universal
{
    public class BasicPolicy : IPackingItemsPolicy
    {
        private const uint MaximumQuantity = 7;
        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Pants", Math.Min(policyData.Days, MaximumQuantity)),
                new("Socks", Math.Min(policyData.Days, MaximumQuantity)),
                new("T-Shirt", Math.Min(policyData.Days, MaximumQuantity)),
                new("Trousers", Math.Min(policyData.Days, MaximumQuantity)),
                new("Shampoo", 1),
            };

        public bool IsApplicable(PolicyData _)
            => true;
    }
}

