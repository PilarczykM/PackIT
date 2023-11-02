using Microsoft.EntityFrameworkCore;

using PackIT.Domain.Entity;
using PackIT.Domain.ValueObjects;
using PackIT.Infrastructure.EF.Configs;

namespace PackIT.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        // Write db context points directly into entity, but read db context points into DTO,
        // which later we have to instruct how to correctly map.
        // Configuration is creating in Config folder.
        public DbSet<PackingList> PackingLists { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            var configuration = new WriteConfiguration();

            modelBuilder.ApplyConfiguration<PackingList>(configuration);
            modelBuilder.ApplyConfiguration<PackingItem>(configuration);
        }
    }
}
