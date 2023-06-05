using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlineTech.Linstagram.Api.Migrations
{
    public partial class addnovastabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(30)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfils",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<string>(type: "varchar(300)", nullable: false),
                    NomeUsuario = table.Column<string>(type: "varchar(80)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Publicacoes = table.Column<int>(type: "int", nullable: false),
                    Seguidores = table.Column<int>(type: "int", nullable: false),
                    Seguindo = table.Column<int>(type: "int", nullable: false),
                    TipoPerfil = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfils_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Publicacaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerfilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<string>(type: "varchar(300)", nullable: false),
                    Legenda = table.Column<string>(type: "varchar(100)", nullable: false),
                    Arquivar = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicacaos_Perfils_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfils",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfils_UsuarioId",
                table: "Perfils",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacaos_PerfilId",
                table: "Publicacaos",
                column: "PerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publicacaos");

            migrationBuilder.DropTable(
                name: "Perfils");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
