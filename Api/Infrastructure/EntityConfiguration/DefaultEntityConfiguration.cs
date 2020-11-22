using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration
{
    public static class DefaultEntityConfiguration
    {
        public static void SetupDefaults(this EntityTypeBuilder builder)
        {
            builder.HasKey(nameof(BaseEntity.ID));
            builder.Property(nameof(BaseEntity.ID)).ValueGeneratedNever();
        }
    }
}
