using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class PackingItemNotFound : PackItException
    {
        public string ItemName { get; }

        public PackingItemNotFound(string itemName) : base($"Packing item {itemName} was not found.")
            => ItemName = itemName;
    }
}

