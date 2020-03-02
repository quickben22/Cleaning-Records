using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningRecords.Migrations
{
    public partial class init14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Holiday",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Holiday2",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "HolidayEnd",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HolidayEnd2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HolidayStart",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HolidayStart2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Holiday",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Holiday2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "HolidayEnd",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "HolidayEnd2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "HolidayStart",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "HolidayStart2",
                table: "Cleaners");
        }
    }
}
