using Microsoft.EntityFrameworkCore;

using PackIT.Infrastructure.EF.Configs;
using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        // Write db context points directly into entity, but read db context points into DTO,
        // which later we have to instruct how to correctly map.
        // Configuration is creating in Config folder.
        public DbSet<PackingListReadModel> PackingLists { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var configuration = new ReadConfiguration();

            modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
            modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);
        }
    }
}
