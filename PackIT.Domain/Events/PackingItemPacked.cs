using PackIT.Domain.Entity;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Entities
{
    public record PackingItemPacked(PackingList PackingList, PackingItem PackingItem) : IDomainEvent
    { }
}
