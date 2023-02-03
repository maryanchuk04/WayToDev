using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WayToDev.Db.Migrations
{
    public partial class ChatUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_Users_UserId",
                table: "UserRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Image_ImageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Users_UserId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_VacancyStacks_Tags_TagId",
                table: "VacancyStacks");

            migrationBuilder.DropForeignKey(
                name: "FK_VacancyStacks_Vacancies_VacancyId",
                table: "VacancyStacks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_Users_UserId",
                table: "UserRooms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Image_ImageId",
                table: "Users",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Users_UserId",
                table: "Vacancies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyStacks_Tags_TagId",
                table: "VacancyStacks",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyStacks_Vacancies_VacancyId",
                table: "VacancyStacks",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_Users_UserId",
                table: "UserRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Image_ImageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Users_UserId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_VacancyStacks_Tags_TagId",
                table: "VacancyStacks");

            migrationBuilder.DropForeignKey(
                name: "FK_VacancyStacks_Vacancies_VacancyId",
                table: "VacancyStacks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_Users_UserId",
                table: "UserRooms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Image_ImageId",
                table: "Users",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Companies_CompanyId",
                table: "Vacancies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Users_UserId",
                table: "Vacancies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyStacks_Tags_TagId",
                table: "VacancyStacks",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyStacks_Vacancies_VacancyId",
                table: "VacancyStacks",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
