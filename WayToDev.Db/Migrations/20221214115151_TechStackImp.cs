using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayToDev.Db.Migrations
{
    public partial class TechStackImp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TechStack_TechStackId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechStack",
                table: "TechStack");

            migrationBuilder.RenameTable(
                name: "TechStack",
                newName: "TechStacks");

            migrationBuilder.AddColumn<Guid>(
                name: "TechStackId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechStacks",
                table: "TechStacks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TechStackId",
                table: "Companies",
                column: "TechStackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_TechStacks_TechStackId",
                table: "Companies",
                column: "TechStackId",
                principalTable: "TechStacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TechStacks_TechStackId",
                table: "Tags",
                column: "TechStackId",
                principalTable: "TechStacks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_TechStacks_TechStackId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TechStacks_TechStackId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Companies_TechStackId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechStacks",
                table: "TechStacks");

            migrationBuilder.DropColumn(
                name: "TechStackId",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "TechStacks",
                newName: "TechStack");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechStack",
                table: "TechStack",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TechStack_TechStackId",
                table: "Tags",
                column: "TechStackId",
                principalTable: "TechStack",
                principalColumn: "Id");
        }
    }
}
