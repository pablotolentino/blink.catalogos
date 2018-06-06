using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Catalogs.Core.Entities
{
    public partial class CatalogsContext : DbContext
    {
        public CatalogsContext()
        {
        }

        public CatalogsContext(DbContextOptions<CatalogsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catalog> Catalog { get; set; }
        public virtual DbSet<CatalogItem> CatalogItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Catalogs;Trusted_Connection=True;");
            }
        }

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

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.CatalogItem)
                    .HasForeignKey(d => d.CatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatalogItem_Catalog");
            });
        }
    }
}
