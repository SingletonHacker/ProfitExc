using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public class GemeenteEntityConfiguration : IEntityTypeConfiguration<Gemeente>
    {
        public void Configure(EntityTypeBuilder<Gemeente> builder)
        {
            DefaultEntityConfiguration.SetupDefaults(builder);

            builder.ToTable("Gemeente");

            //TODO: Dit moet eigenlijk geen owns zijn, even fixen
            builder.OwnsOne(b => b.Provincie);
        }
    }
}
