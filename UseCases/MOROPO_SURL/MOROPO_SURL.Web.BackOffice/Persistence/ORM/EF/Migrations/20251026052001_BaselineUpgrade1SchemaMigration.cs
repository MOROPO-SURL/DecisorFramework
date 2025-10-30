using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class BaselineUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_colaborators_identityid",
                table: "colaborators");

            migrationBuilder.RenameTable(
                name: "unitmeasurements",
                schema: "decisorframework_inventory",
                newName: "unitmeasurements",
                newSchema: "decisorframework_domain");

            migrationBuilder.RenameTable(
                name: "unitmeasurementconversionbridges",
                schema: "decisorframework_inventory",
                newName: "unitmeasurementconversionbridges",
                newSchema: "decisorframework_domain");

            migrationBuilder.RenameTable(
                name: "colaborators",
                newName: "colaborators",
                newSchema: "decisorframework_domain");

            migrationBuilder.RenameTable(
                name: "centralstatestructures",
                schema: "decisorframework_legal",
                newName: "centralstatestructures",
                newSchema: "decisorframework_domain");

            migrationBuilder.CreateIndex(
                name: "ix_colaborators_identityid",
                schema: "decisorframework_domain",
                table: "colaborators",
                column: "identityid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_colaborators_identityid",
                schema: "decisorframework_domain",
                table: "colaborators");

            migrationBuilder.RenameTable(
                name: "unitmeasurements",
                schema: "decisorframework_domain",
                newName: "unitmeasurements",
                newSchema: "decisorframework_inventory");

            migrationBuilder.RenameTable(
                name: "unitmeasurementconversionbridges",
                schema: "decisorframework_domain",
                newName: "unitmeasurementconversionbridges",
                newSchema: "decisorframework_inventory");

            migrationBuilder.RenameTable(
                name: "colaborators",
                schema: "decisorframework_domain",
                newName: "colaborators");

            migrationBuilder.RenameTable(
                name: "centralstatestructures",
                schema: "decisorframework_domain",
                newName: "centralstatestructures",
                newSchema: "decisorframework_legal");

            migrationBuilder.CreateIndex(
                name: "ix_colaborators_identityid",
                table: "colaborators",
                column: "identityid");
        }
    }
}
