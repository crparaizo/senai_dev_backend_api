using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Svigufo.WebApi.Domains
{
    public partial class MedGroupContext : DbContext
    {
        public MedGroupContext()
        {
        }

        public MedGroupContext(DbContextOptions<MedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Convites> Convites { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Instituicoes> Instituicoes { get; set; }
        public virtual DbSet<TiposEventos> TiposEventos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SqlExpress;initial catalog=SENAI_SVIGUFU_TARDE;user id=sa;password=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Convites>(entity =>
            {
                entity.Property(e => e.Situacao).IsUnicode(false);

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Convites)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__CONVITES__ID_EVE__6477ECF3");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Convites)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__CONVITES__ID_USU__6383C8BA");
            });

            modelBuilder.Entity<Eventos>(entity =>
            {
                entity.Property(e => e.AcessoLivre).HasDefaultValueSql("((1))");

                entity.Property(e => e.Titulo).IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__EVENTOS__ID_INST__5165187F");

                entity.HasOne(d => d.IdTipoEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdTipoEvento)
                    .HasConstraintName("FK__EVENTOS__ID_TIPO__5070F446");
            });

            modelBuilder.Entity<Instituicoes>(entity =>
            {
                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__INSTITUI__AA57D6B47D88E3A6")
                    .IsUnique();

                entity.Property(e => e.Cep).IsUnicode(false);

                entity.Property(e => e.Cidade).IsUnicode(false);

                entity.Property(e => e.Cnpj).IsUnicode(false);

                entity.Property(e => e.Logradouro).IsUnicode(false);

                entity.Property(e => e.NomeFantasia).IsUnicode(false);

                entity.Property(e => e.RazaoSocial).IsUnicode(false);

                entity.Property(e => e.Uf).IsUnicode(false);
            });

            modelBuilder.Entity<TiposEventos>(entity =>
            {
                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__TIPOS_EV__AC728E506DA6F0C8")
                    .IsUnique();

                entity.Property(e => e.Titulo).IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF724CE949BEC")
                    .IsUnique();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.Property(e => e.TipoUsuario).IsUnicode(false);
            });
        }
    }
}
