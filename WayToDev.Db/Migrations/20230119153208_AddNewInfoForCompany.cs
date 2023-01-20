using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayToDev.Db.Migrations
{
    public partial class AddNewInfoForCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BannerImageId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountOfWorkers",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteLink",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_BannerImageId",
                table: "Companies",
                column: "BannerImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Image_BannerImageId",
                table: "Companies",
                column: "BannerImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Image_BannerImageId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_BannerImageId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "BannerImageId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CountOfWorkers",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "WebsiteLink",
                table: "Companies");
        }
    }
}
