using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _packingListRepository;
        public RemovePackingItemHandler(IPackingListRepository packingListRepository)
        {
            _packingListRepository = packingListRepository;
        }

        public async Task HandleAsync(RemovePackingItem command)
        {
            var (packingListId, itemName) = command;

            var packingList = await _packingListRepository.GetAsync(packingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(packingListId);
            }

            packingList.RemoveItem(itemName);

            await _packingListRepository.UpdateAsync(packingList);
        }
    }
}

