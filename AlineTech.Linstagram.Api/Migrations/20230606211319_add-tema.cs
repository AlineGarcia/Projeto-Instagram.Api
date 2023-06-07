using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlineTech.Linstagram.Api.Migrations
{
    public partial class addtema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tema",
                table: "Perfils",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tema",
                table: "Perfils");
        }
    }
}
