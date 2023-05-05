using Microsoft.EntityFrameworkCore;
using PackIT.Domain.Entity;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.EF.Contexts;

namespace PackIT.Infrastructure.EF.Repositories
{
    internal sealed class PostgresPackingListRepository : IPackingListRepository
    {
        private readonly DbSet<PackingList> _packingList;
        private readonly WriteDbContext _writeDbContext;

        public PostgresPackingListRepository(WriteDbContext writeDbContext)
        {
            _packingList = writeDbContext.PackingLists;
            _writeDbContext = writeDbContext;
        }

        public async Task AddAsync(PackingList packingList)
        {
            await _packingList.AddAsync(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PackingList packingList)
        {
            _packingList.Remove(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<PackingList> GetAsync(PackingListId id)
            => _packingList
            .Include("_items")
            .SingleOrDefaultAsync(pl => pl.Id == id);

        public async Task UpdateAsync(PackingList packingList)
        {
            _packingList.Update(packingList);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}

