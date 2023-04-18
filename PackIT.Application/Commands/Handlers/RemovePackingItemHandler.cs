using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    public class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        public readonly IPackingListRepository _repository;

        public RemovePackingItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemovePackingItem command)
        {
            var (PackingListId, Name) = command;
            var packingList = await _repository.GetAsync(PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(PackingListId);
            }

            packingList.RemoveItem(Name);

            await _repository.UpdateAsync(packingList);
        }
    }
}
