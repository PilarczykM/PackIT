using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies
{
    public interface IPackingItemsPolicy
    {
        bool IsAplicable(PolicyData data);
        IEnumerable<PackingItem> GenerateItems(PolicyData data);
    }
}
