using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Entity;

public class PackingList
{
	public Guid Id { get; private set; }
	private readonly PackingListName _name;
	public readonly Localization _localization;
}
