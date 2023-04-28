using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies
{
    public interface IPackingItemsPolicy
    {
        bool IsApplicable(PolicyData policyData);
        IEnumerable<PackingItem> GenerateItems(PolicyData policyData);
    }
}

