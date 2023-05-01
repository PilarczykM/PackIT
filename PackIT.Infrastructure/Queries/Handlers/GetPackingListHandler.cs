using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infrastructure.Queries.Handlers
{
    public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        public GetPackingListHandler()
        {
        }

        public Task<PackingListDto> HandleAsync(GetPackingList query)
        {
            throw new NotImplementedException();
        }
    }
}

