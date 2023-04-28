using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender
{
    public class FemalePolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Laptop", 1),
                new("Beer", 1),
                new("Book", (uint)Math.Ceiling(policyData.Days/7m))
            };

        public bool IsApplicable(PolicyData policyData)
            => policyData.Gender is Consts.Gender.Male;

    }
}
