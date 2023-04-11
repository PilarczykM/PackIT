using PackIT.Domain.Consts;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender
{
    internal sealed class MaleGenderPolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data) => new List<PackingItem>()
        {
            new("Laptop", 1),
            new("Beer", 10),
            new("Book", 3)
        };

        public bool IsAplicable(PolicyData data) => data.Gender is GenderEnum.Male;
    }
}
