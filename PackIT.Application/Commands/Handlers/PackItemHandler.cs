using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    public class PackItemHandler : ICommandHandler<PackItem>
    {
        private readonly IPackingListRepository _repository;

        public PackItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(PackItem command)
        {
            var (PackingListId, Name) = command;

            var packingList = await _repository.GetAsync(PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(PackingListId);
            }

            packingList.PackItem(Name);

            await _repository.UpdateAsync(packingList);
        }
    }
}
