using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TreinoSaep.Models
{
    public partial class db_ChamadoContext : DbContext
    {
        public db_ChamadoContext()
        {
        }

        public db_ChamadoContext(DbContextOptions<db_ChamadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chamado> Chamados { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv-eno.database.windows.net;User Id=admin.eno;Password=erasmo.123;Database=db_Chamado");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chamado>(entity =>
            {
                entity.HasKey(e => e.Idchamado)
                    .HasName("PK__Chamados__867B8C8465176EEA");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Prioridade)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Setor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Statuss)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Chamados)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Chamados__Usuari__398D8EEE");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusu)
                    .HasName("PK__Usuarios__135E85A66D275317");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534EA51C139")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
