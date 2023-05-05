using PackIT.Application.Exceptions;
using PackIT.Domain.Repositories;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class RemovePackingListHandler : ICommandHandler<RemovePackingList>
    {
        private readonly IPackingListRepository _packingListRepository;
        public RemovePackingListHandler(IPackingListRepository packingListRepository)
        {
            _packingListRepository = packingListRepository;
        }

        public async Task HandleAsync(RemovePackingList command)
        {
            var packingList = await _packingListRepository.GetAsync(command.PackingListId) ??
                throw new PackingListNotFoundException(command.PackingListId);

            await _packingListRepository.DeleteAsync(packingList);
        }
    }
}

