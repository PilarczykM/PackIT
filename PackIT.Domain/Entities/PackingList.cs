using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Entity;

public class PackingList
{
	public Guid Id { get; private set; }
	private readonly PackingListName _name;
	private readonly Localization _localization;
	private readonly LinkedList<PackingItem> _items = ();

	internal PackingList(Guid id, PackingListName name, Localization localization)
	{
		Id = id;
		_name = name;
		_localization = localization;
	}
}
