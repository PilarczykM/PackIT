using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record class PackingItem
    {
        public string Name { get; }
        public uint Quantity { get; }
        public bool IsPacked { get; init; }

        public PackingItem(string name, uint quantity, bool isPacked = false)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptyPackingListItemNameException();
            }

            Name = name.Trim();
            Quantity = quantity;
            IsPacked = isPacked;
        }
    }
}
