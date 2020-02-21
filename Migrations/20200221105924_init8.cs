using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningRecords.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FridayEnd",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FridayStart",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MondayEnd",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MondayStart",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NotAvailableEnd",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NotAvailableStart",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SaturdayEnd",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SaturdayStart",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SundayEnd",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SundayStart",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ThursdayEnd",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ThursdayStart",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TuesdayEnd",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TuesdayStart",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WednesdayEnd",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WednesdayStart",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FridayEnd",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "FridayStart",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "MondayEnd",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "MondayStart",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "NotAvailableEnd",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "NotAvailableStart",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "SaturdayEnd",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "SaturdayStart",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "SundayEnd",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "SundayStart",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "ThursdayEnd",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "ThursdayStart",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "TuesdayEnd",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "TuesdayStart",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "WednesdayEnd",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "WednesdayStart",
                table: "Cleaners");
        }
    }
}
