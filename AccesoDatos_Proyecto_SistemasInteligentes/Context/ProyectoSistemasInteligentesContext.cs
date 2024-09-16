using System;
using System.Collections.Generic;
using AccesoDatos_Proyecto_SistemasInteligentes.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos_Proyecto_SistemasInteligentes.Context;

public partial class ProyectoSistemasInteligentesContext : DbContext
{
    
   
    public ProyectoSistemasInteligentesContext()
    {
    }

    public ProyectoSistemasInteligentesContext(DbContextOptions<ProyectoSistemasInteligentesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2VASUV7\\MSSQLSERVER01;Database=ProyectoSistemasInteligentes;Trust Server Certificate=True;User Id=AnthoDeveloper;Password=123456789;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF974B140E11");

            entity.ToTable("Usuario");

            entity.Property(e => e.ApmaUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AppUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LogiUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PassUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RolUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
