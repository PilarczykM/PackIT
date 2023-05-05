using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class PackItemHandler : ICommandHandler<PackItem>
    {
        private readonly IPackingListRepository _packingListRepository;
        public PackItemHandler(IPackingListRepository packingListRepository)
        {
            _packingListRepository = packingListRepository;
        }

        public async Task HandleAsync(PackItem command)
        {
            var (packingListId, itemName) = command;

            var packingList = await _packingListRepository.GetAsync(packingListId) ??
                throw new PackingListNotFoundException(packingListId);

            packingList.PackItem(itemName);
            await _packingListRepository.UpdateAsync(packingList);
        }
    }
}

