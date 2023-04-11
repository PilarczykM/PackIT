using PackIT.Domain.Consts;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Gender
{
    internal sealed class FemaleGenderPolicy : IPackingItemsPolicy
    {
        public IEnumerable<PackingItem> GenerateItems(PolicyData data) => new List<PackingItem>()
        {
            new("Laptop", 1),
            new("Flower", 10),
            new("Book", 7)
        };

        public bool IsAplicable(PolicyData data) => data.Gender is GenderEnum.Female;
    }
}
