using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ekka_Shopping.Migrations
{
    public partial class Latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
