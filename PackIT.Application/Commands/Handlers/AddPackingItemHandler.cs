using System.Xml.Linq;
using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    public class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _packingListRepository;

        public AddPackingItemHandler(IPackingListRepository packingListRepository)
        {
            _packingListRepository = packingListRepository;
        }

        public async Task HandleAsync(AddPackingItem command)
        {
            var (packingListId, name, quantity) = command;
            var packingList = await _packingListRepository.GetAsync(packingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(packingListId);
            }

            packingList.AddItem(new PackingItem(name, quantity));

            await _packingListRepository.UpdateAsync(packingList);
        }
    }
}

