using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Entity;

public class PackingList : AggregateRoot<PackingListId>
{
    public PackingListId Id { get; private set; }
    private readonly PackingListName _name;
    private readonly Localization _localization;
    private readonly LinkedList<PackingItem> _items = new();

    internal PackingList(PackingListId id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
    {
        Id = id;
        _name = name;
        _localization = localization;
    }

    public void AddItem(PackingItem item)
    {
        var alreadyExists = _items.Any(i => i.Name == item.Name);

        if (alreadyExists)
        {
            throw new PackingItemAlreadyExistsException(_name, item.Name);
        }

        _items.AddLast(item);
    }
}
