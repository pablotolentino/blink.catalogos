using System;
using Catalogs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Catalogs.Data
{
    public partial class CatalogsContext : DbContext
    {
        public CatalogsContext(DbContextOptions<CatalogsContext> options) : base(options)
        {
        }



        public virtual DbSet<Catalog> Catalog { get; set; }
        public virtual DbSet<CatalogItem> CatalogItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.Property(e => e.CatalogId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(350);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<CatalogItem>(entity =>
            {
                entity.Property(e => e.CatalogItemId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(350);

                entity.Property(e => e.Name).HasMaxLength(150);
            });
        }
    }
}
