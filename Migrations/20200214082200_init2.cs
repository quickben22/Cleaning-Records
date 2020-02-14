using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningRecords.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ironing",
                table: "Cleaners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pets",
                table: "Cleaners",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ironing",
                table: "Cleaners");

            migrationBuilder.DropColumn(
                name: "Pets",
                table: "Cleaners");
        }
    }
}
