using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayToDev.Db.Migrations
{
    public partial class ChatUpdate20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Image_ImageId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ImageId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ImageId",
                table: "Rooms",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Image_ImageId",
                table: "Rooms",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
