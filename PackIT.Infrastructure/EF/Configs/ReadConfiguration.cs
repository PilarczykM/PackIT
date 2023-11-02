using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PackIT.Infrastructure.EF.Models;

namespace PackIT.Infrastructure.EF.Configs
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<PackingListReadModel>,
        IEntityTypeConfiguration<PackingItemReadModel>
    {
        public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
        {
            builder.ToTable("PackingList");
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Localization)
                .HasConversion(l => l.ToString(), l => LocalizationReadModel.Create(l));

            builder
                .HasMany(pl => pl.Items)
                .WithOne(pi => pi.PackingList);
        }

        public void Configure(EntityTypeBuilder<PackingItemReadModel> builder)
        {
            builder.ToTable("PackingItems");
        }
    }
}
