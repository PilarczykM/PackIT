using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using PackIT.Domain.Entity;
using PackIT.Domain.ValueObjects;

namespace PackIT.Infrastructure.EF.Configs
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingList>, IEntityTypeConfiguration<PackingItem>
    {
        public void Configure(EntityTypeBuilder<PackingList> builder)
        {
            builder.ToTable("PackingList");

            builder.HasKey(pl => pl.Id);

            var localizationConvertion =
                new ValueConverter<Localization, string>(l => l.ToString(), l => Localization.Create(l));

            var packingListNameConverter = new ValueConverter<PackingListName, string>(pln => pln.Value,
                pln => new(pln));

            builder
                .Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new(id));

            builder
                .Property(typeof(Localization), "_localization")
                .HasConversion(localizationConvertion)
                .HasColumnName("Localization"); // Without implicit name it would use '_localization' name which will not match ReadDbContext

            builder
                .Property(typeof(PackingListName), "_name")
                .HasConversion(packingListNameConverter)
                .HasColumnName("Name");

            builder
                .HasMany(typeof(PackingItem), "_items");
        }

        public void Configure(EntityTypeBuilder<PackingItem> builder)
        {
            builder.ToTable("PackingItems");

            builder.Property<Guid>("Id");
            builder.Property(pi => pi.Name);
            builder.Property(pi => pi.Quantity);
            builder.Property(pi => pi.IsPacked);
        }
    }
}
