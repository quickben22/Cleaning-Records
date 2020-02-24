using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningRecords.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Friday2",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FridayEnd2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FridayStart2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Monday2",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "MondayEnd2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MondayStart2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "NotAvailable2",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NotAvailableEnd2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NotAvailableStart2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Saturday2",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SaturdayEnd2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SaturdayStart2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Sunday2",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SundayEnd2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SundayStart2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Thursday2",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThursdayEnd2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ThursdayStart2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Tuesday2",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TuesdayEnd2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TuesdayStart2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Wednesday2",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "WednesdayEnd2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WednesdayStart2",
                table: "Cleaners",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Friday2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "FridayEnd2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "FridayStart2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Monday2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "MondayEnd2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "MondayStart2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "NotAvailable2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "NotAvailableEnd2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "NotAvailableStart2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Saturday2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "SaturdayEnd2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "SaturdayStart2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Sunday2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "SundayEnd2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "SundayStart2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Thursday2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "ThursdayEnd2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "ThursdayStart2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Tuesday2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "TuesdayEnd2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "TuesdayStart2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Wednesday2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "WednesdayEnd2",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "WednesdayStart2",
                table: "Cleaners");
        }
    }
}
