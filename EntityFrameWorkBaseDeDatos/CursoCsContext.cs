using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkBaseDeDatos;

/*Proyecto de ejemplo para ver que podemos usar EntityFramework en 
 * proyectos de bases de datos pre-existentes
 */

public partial class CursoCsContext : DbContext
{
    public CursoCsContext()
    {
    }

    public CursoCsContext(DbContextOptions<CursoCsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       /* Condición adicional para que la cadena de conexión se cambie en cada
        * implementación de esta biblioteca de clases. Pero si no se hace esa
        * configuración, aún así se puede usar la cadena de conexión aquí definida.
        */
        if (!optionsBuilder.IsConfigured) //Cuando NO está configurado
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=B450M; Database=CursoCS; User=usuariodb; Password=elfruto; TrustServerCertificate=True;");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("db_owner");

        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BEER__3214EC277D0C4F85");

            entity.ToTable("BEER", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BrandId).HasColumnName("BRAND_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.HasOne(d => d.Brand).WithMany(p => p.Beers)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BEER__BRAND_ID__398D8EEE");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BRAND__3214EC2719DA2380");

            entity.ToTable("BRAND", "dbo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
