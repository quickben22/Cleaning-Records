using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningRecords.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address3",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address4",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address3",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address4",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Clients");
        }
    }
}
