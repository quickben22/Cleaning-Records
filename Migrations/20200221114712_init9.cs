using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningRecords.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Friday",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Monday",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NotAvailable",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Saturday",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sunday",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Thursday",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Tuesday",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Wednesday",
                table: "Cleaners",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Friday",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Monday",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "NotAvailable",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Saturday",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Sunday",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Thursday",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Tuesday",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Wednesday",
                table: "Cleaners");
        }
    }
}
