using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Application.Exceptions
{
    internal class PackingListAlreadyExistsException : PackItException
    {
        public string Name { get; }
        public PackingListAlreadyExistsException(string name) : base($"Packing list with name '{name} already exists.'")
        {
            Name = name;
        }
    }
}
