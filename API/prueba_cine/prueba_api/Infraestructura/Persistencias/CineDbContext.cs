using System;
using System.Collections.Generic;
using Infraestructura.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencias;

public partial class CineDbContext : DbContext
{
    public CineDbContext()
    {
    }

    public CineDbContext(DbContextOptions<CineDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PeliculaSalacine> PeliculaSalacines { get; set; }

    public virtual DbSet<SalaCine> SalaCines { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       //  => optionsBuilder.UseSqlServer("Server=RaystormMetal\\SQLEXPRESS;Database=prueba_cine;User Id=developer_admin;Password=admin89;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("PK__pelicula__B5017F4D84885B14");

            entity.ToTable("pelicula");

            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PeliculaSalacine>(entity =>
        {
            entity.HasKey(e => e.IdPeliculaSala).HasName("PK__pelicula__39BC477FC27CDB73");

            entity.ToTable("pelicula_salacine");

            entity.Property(e => e.IdPeliculaSala).HasColumnName("id_pelicula_sala");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaPublicacion).HasColumnName("fecha_publicacion");
            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
            entity.Property(e => e.IdSalaCine).HasColumnName("id_sala_cine");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.PeliculaSalacines)
                .HasForeignKey(d => d.IdPelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pelicula___id_pe__3B75D760");

            entity.HasOne(d => d.IdSalaCineNavigation).WithMany(p => p.PeliculaSalacines)
                .HasForeignKey(d => d.IdSalaCine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pelicula___id_sa__3C69FB99");
        });

        modelBuilder.Entity<SalaCine>(entity =>
        {
            entity.HasKey(e => e.IdSalaCine).HasName("PK__sala_cin__83CDE2C14920FEE2");

            entity.ToTable("sala_cine");

            entity.Property(e => e.IdSalaCine).HasColumnName("id_sala_cine");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
