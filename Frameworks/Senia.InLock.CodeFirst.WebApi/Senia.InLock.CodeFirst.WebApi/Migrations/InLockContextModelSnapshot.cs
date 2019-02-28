﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senai.InLock.CodeFirst.WebApi.Contexts;

namespace Senai.InLock.CodeFirst.WebApi.Migrations
{
    [DbContext(typeof(InLockContext))]
    partial class InLockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senai.InLock.CodeFirst.WebApi.Domains.EstudioDomain", b =>
                {
                    b.Property<int>("EstudioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeEstudio")
                        .IsRequired()
                        .HasColumnName("NomeEstudio")
                        .HasColumnType("varchar(150)");

                    b.HasKey("EstudioId");

                    b.ToTable("Estudios");
                });

            modelBuilder.Entity("Senai.InLock.CodeFirst.WebApi.Domains.JogoDomain", b =>
                {
                    b.Property<int>("JogoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataLancamento");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("Text");

                    b.Property<int>("EstudioId");

                    b.Property<string>("NomeJogo")
                        .IsRequired()
                        .HasColumnType("varchar (150)");

                    b.Property<decimal>("Valor");

                    b.HasKey("JogoId");

                    b.HasIndex("EstudioId");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("Senai.InLock.CodeFirst.WebApi.Domains.JogoDomain", b =>
                {
                    b.HasOne("Senai.InLock.CodeFirst.WebApi.Domains.EstudioDomain", "Estudio")
                        .WithMany("Jogos")
                        .HasForeignKey("EstudioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
