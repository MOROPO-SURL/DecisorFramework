using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IDiUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "timeavailability",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "timeavailability",
                schema: "decisoriscamaguey_idi",
                table: "projectresearcherbridges",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timeavailability",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropColumn(
                name: "timeavailability",
                schema: "decisoriscamaguey_idi",
                table: "projectresearcherbridges");
        }
    }
}
