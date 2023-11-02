using PackIT.Application.DTO;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Application.Queries
{
    public class SeachPackingLists : IQuery<IEnumerable<PackingListDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
