using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    public class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _repository;

        public AddPackingItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddPackingItem command)
        {
            var (PackingListId, Name, Quantity) = command;
            var packingList = await _repository.GetAsync(PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(PackingListId);
            }

            var packingItem = new PackingItem(Name, Quantity);
            packingList.AddItem(packingItem);

            await _repository.UpdateAsync(packingList);
        }
    }
}
