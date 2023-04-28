using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender
{
    public class MalePolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData policyData)
            => new List<PackingItem>
            {
                new("Lipstick", 1),
                new("Powder", 1),
                new("Eyeliner", 1)
            };

        public bool IsApplicable(PolicyData policyData)
            => policyData.Gender is Consts.Gender.Female;

    }
}
