using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlineTech.Linstagram.Api.Migrations
{
    public partial class modificandofotoparabyte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Publicacoes");

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPublicacao",
                table: "Publicacoes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPublicacao",
                table: "Publicacoes");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Publicacoes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
