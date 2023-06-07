﻿// <auto-generated />
using System;
using AlineTech.Linstagram.Api.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlineTech.Linstagram.Api.Migrations
{
    [DbContext(typeof(LinstagramContext))]
    partial class LinstagramContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlineTech.Linstagram.Api.Models.Entitys.Perfil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Publicacoes")
                        .HasColumnType("int");

                    b.Property<int>("Seguidores")
                        .HasColumnType("int");

                    b.Property<int>("Seguindo")
                        .HasColumnType("int");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoPerfil")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Perfils");
                });

            modelBuilder.Entity("AlineTech.Linstagram.Api.Models.Entitys.Publicacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Arquivar")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FotoPublicacao")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Legenda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PerfilId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Publicacoes");
                });

            modelBuilder.Entity("AlineTech.Linstagram.Api.Models.Entitys.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AlineTech.Linstagram.Api.Models.Entitys.Perfil", b =>
                {
                    b.HasOne("AlineTech.Linstagram.Api.Models.Entitys.Usuario", "Usuario")
                        .WithMany("Perfils")
                        .HasForeignKey("UsuarioId")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AlineTech.Linstagram.Api.Models.Entitys.Publicacao", b =>
                {
                    b.HasOne("AlineTech.Linstagram.Api.Models.Entitys.Perfil", "Perfil")
                        .WithMany("Publicacaos")
                        .HasForeignKey("PerfilId")
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("AlineTech.Linstagram.Api.Models.Entitys.Perfil", b =>
                {
                    b.Navigation("Publicacaos");
                });

            modelBuilder.Entity("AlineTech.Linstagram.Api.Models.Entitys.Usuario", b =>
                {
                    b.Navigation("Perfils");
                });
#pragma warning restore 612, 618
        }
    }
}
