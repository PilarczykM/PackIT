using PackIT.Domain.Entity;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Events
{
    public record PackingItemRemoved(PackingList PackingList, PackingItem PackingItem) : IDomainEvent
    {
    }
}

