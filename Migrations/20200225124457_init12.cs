using Microsoft.EntityFrameworkCore.Migrations;

namespace CleaningRecords.Migrations
{
    public partial class init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceJob",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false),
                    CleaningJobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceJob", x => new { x.ServiceId, x.CleaningJobId });
                    table.ForeignKey(
                        name: "FK_ServiceJob_CleaningJobs_CleaningJobId",
                        column: x => x.CleaningJobId,
                        principalTable: "CleaningJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceJob_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceJob_CleaningJobId",
                table: "ServiceJob",
                column: "CleaningJobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceJob");
        }
    }
}
