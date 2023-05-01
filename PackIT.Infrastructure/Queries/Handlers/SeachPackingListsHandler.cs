using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infrastructure.Queries.Handlers
{
    public class SeachPackingListsHandler : IQueryHandler<SeachPackingLists, IEnumerable<PackingListDto>>
    {
        public SeachPackingListsHandler()
        {
        }

        public Task<IEnumerable<PackingListDto>> HandleAsync(SeachPackingLists query)
        {
            throw new NotImplementedException();
        }
    }
}

