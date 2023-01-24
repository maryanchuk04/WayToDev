using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayToDev.Db.Migrations
{
    public partial class TokenType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AccountTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "AccountTokens");
        }
    }
}
