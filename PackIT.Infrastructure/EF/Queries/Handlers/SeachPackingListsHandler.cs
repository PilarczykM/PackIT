using Microsoft.EntityFrameworkCore;
using PackIT.Application.DTO;
using PackIT.Application.Queries;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Models;
using PackIT.Shared.Abstractions.Queries;

namespace PackIT.Infrastructure.EF.Queries.Handlers
{
    internal class SeachPackingListsHandler : IQueryHandler<SeachPackingLists, IEnumerable<PackingListDto>>
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public SeachPackingListsHandler(ReadDbContext context)
        {
            _packingList = context.PackingLists;
        }

        public async Task<IEnumerable<PackingListDto>> HandleAsync(SeachPackingLists query)
        {
            var dbQuery = _packingList
                .Include(pl => pl.Items)
                .AsQueryable();

            if (query.SearchTerm is not null)
            {
                dbQuery
                    .Where(pl =>
                    Microsoft.EntityFrameworkCore.EF.Functions.ILike(pl.Name, $"%{query.SearchTerm}%"));
            }

            return await dbQuery
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

