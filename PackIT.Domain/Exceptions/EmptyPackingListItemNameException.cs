using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingListItemNameException : PackItException
{
	public EmptyPackingListItemNameException() : base("Packing list item name can not be empty.")
	{
	}
}
