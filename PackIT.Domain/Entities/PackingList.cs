using PackIT.Domain.Entities;
using PackIT.Domain.Events;
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

    internal PackingList(PackingListId id, PackingListName name, Localization localization)
    {
        Id = id;
        _name = name;
        _localization = localization;
    }

    internal PackingList(PackingListId id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
        : this(id, name, localization)
    {
        AddItems(items);
    }

    public void AddItem(PackingItem item)
    {
        var alreadyExists = _items.Any(i => i.Name == item.Name);

        if (alreadyExists)
        {
            throw new PackingItemAlreadyExistsException(_name, item.Name);
        }

        _items.AddLast(item);
        AddEvent(new PackingItemAdded(this, item));
    }

    public void AddItems(IEnumerable<PackingItem> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void PackItem(string itemName)
    {
        var item = GetItem(itemName);

        var packedItem = item with { IsPacked = !item.IsPacked }; // Copy of record with changed property.

        _items.Find(item).Value = packedItem;
        AddEvent(new PackingItemPacked(this, packedItem));
    }

    public void RemoveItem(string itemName)
    {
        var item = GetItem(itemName);

        _items.Remove(item);
        AddEvent(new PackingItemRemoved(this, item));
    }

    private PackingItem GetItem(string itemName)
        => _items.SingleOrDefault(i => i.Name == itemName) ?? throw new PackingItemNotFound(itemName);
}
