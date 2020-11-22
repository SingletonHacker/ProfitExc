using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class GemeenteContext : DbContext
    {
        public GemeenteContext(DbContextOptions<GemeenteContext> options) : base(options)
        {
        }

        public DbSet<Gemeente> Gemeentes => Set<Gemeente>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
