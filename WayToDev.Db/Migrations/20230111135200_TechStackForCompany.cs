using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayToDev.Db.Migrations
{
    public partial class TechStackForCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_TechStacks_TechStackId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TechStacks_TechStackId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TechStackId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Companies_TechStackId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TechStackId",
                table: "Tags");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "TechStacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TagId",
                table: "TechStacks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "TechStacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechStacks_CompanyId",
                table: "TechStacks",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TechStacks_TagId",
                table: "TechStacks",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TechStacks_UserId",
                table: "TechStacks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TechStacks_Companies_CompanyId",
                table: "TechStacks",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TechStacks_Tags_TagId",
                table: "TechStacks",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechStacks_Users_UserId",
                table: "TechStacks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechStacks_Companies_CompanyId",
                table: "TechStacks");

            migrationBuilder.DropForeignKey(
                name: "FK_TechStacks_Tags_TagId",
                table: "TechStacks");

            migrationBuilder.DropForeignKey(
                name: "FK_TechStacks_Users_UserId",
                table: "TechStacks");

            migrationBuilder.DropIndex(
                name: "IX_TechStacks_CompanyId",
                table: "TechStacks");

            migrationBuilder.DropIndex(
                name: "IX_TechStacks_TagId",
                table: "TechStacks");

            migrationBuilder.DropIndex(
                name: "IX_TechStacks_UserId",
                table: "TechStacks");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "TechStacks");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "TechStacks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TechStacks");

            migrationBuilder.AddColumn<Guid>(
                name: "TechStackId",
                table: "Tags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TechStackId",
                table: "Tags",
                column: "TechStackId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TechStackId",
                table: "Companies",
                column: "TechStackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_TechStacks_TechStackId",
                table: "Companies",
                column: "TechStackId",
                principalTable: "TechStacks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TechStacks_TechStackId",
                table: "Tags",
                column: "TechStackId",
                principalTable: "TechStacks",
                principalColumn: "Id");
        }
    }
}
