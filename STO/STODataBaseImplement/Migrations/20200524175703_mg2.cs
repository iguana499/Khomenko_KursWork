using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STODataBaseImplement.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Work",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateImplement",
                table: "Work",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Work",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "DateImplement",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Work");
        }
    }
}
