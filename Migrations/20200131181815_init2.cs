using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningRecords.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "CleaningJobs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "CleaningJobs",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CleaningJobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NoOfHours",
                table: "CleaningJobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "CleaningJobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "CleaningJobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "CleaningJobs");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CleaningJobs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CleaningJobs");

            migrationBuilder.DropColumn(
                name: "NoOfHours",
                table: "CleaningJobs");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "CleaningJobs");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "CleaningJobs");
        }
    }
}
