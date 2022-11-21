using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WSPruebaTecnica.Models;

public partial class PruebaTecnicaContext : DbContext
{
    public PruebaTecnicaContext()
    {
    }

    public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PruebaTecnica;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nip).HasColumnName("NIP");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoNip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TipoNIP");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
