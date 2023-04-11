using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record PackingListId
    {
        public Guid Value { get; }

        public PackingListId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new EmptyPackingListIdException();
            }

            Value = id;
        }

        public static implicit operator PackingListId(Guid id) => new(id);
        public static implicit operator Guid(PackingListId id) => id.Value;
    }
}
