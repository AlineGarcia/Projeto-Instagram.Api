﻿// <auto-generated />
using System;
using AlineTech.Linstagram.Api.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlineTech.Linstagram.Api.Migrations
{
    [DbContext(typeof(LinstagramContext))]
    [Migration("20230504183117_add-novas-tabelas")]
    partial class addnovastabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<int>("Publicacoes")
                        .HasColumnType("int");

                    b.Property<int>("Seguidores")
                        .HasColumnType("int");

                    b.Property<int>("Seguindo")
                        .HasColumnType("int");

                    b.Property<int>("TipoPerfil")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Perfils", (string)null);
                });

            modelBuilder.Entity("AlineTech.Linstagram.Api.Models.Entitys.Publicacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Arquivar")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Legenda")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("PerfilId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Publicacaos", (string)null);
                });

            modelBuilder.Entity("AlineTech.Linstagram.Api.Models.Entitys.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
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
