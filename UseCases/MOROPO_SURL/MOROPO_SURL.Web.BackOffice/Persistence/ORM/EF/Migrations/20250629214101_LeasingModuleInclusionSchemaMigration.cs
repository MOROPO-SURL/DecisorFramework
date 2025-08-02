using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingModuleInclusionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleasepersonpostulationdocumentbridge",
                schema: "decisorframework_production",
                newName: "vehicleleasepersonpostulationdocumentbridge",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_production",
                newName: "vehicleleaseorganizationpostulationdocumentbridge",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseoffers",
                schema: "decisorframework_production",
                newName: "vehicleleaseoffers",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                newName: "vehicleleaseofferpersoncontactbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                newName: "vehicleleaseofferorganizationcontactbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseofferclausebridge",
                schema: "decisorframework_production",
                newName: "vehicleleaseofferclausebridge",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleasepersonpostulationdocumentbridge",
                schema: "decisorframework_production",
                newName: "propertyleasepersonpostulationdocumentbridge",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_production",
                newName: "propertyleaseorganizationpostulationdocumentbridge",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseoffers",
                schema: "decisorframework_production",
                newName: "propertyleaseoffers",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                newName: "propertyleaseofferpersoncontactbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                newName: "propertyleaseofferorganizationcontactbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseofferclausebridge",
                schema: "decisorframework_production",
                newName: "propertyleaseofferclausebridge",
                newSchema: "decisorframework_leasing");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "vehicleleasepersonpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                newName: "vehicleleasepersonpostulationdocumentbridge",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "vehicleleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseorganizationpostulationdocumentbridge",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "vehicleleaseoffers",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseoffers",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseofferpersoncontactbridges",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseofferorganizationcontactbridges",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "vehicleleaseofferclausebridge",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseofferclausebridge",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "propertyleasepersonpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                newName: "propertyleasepersonpostulationdocumentbridge",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "propertyleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                newName: "propertyleaseorganizationpostulationdocumentbridge",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "propertyleaseoffers",
                schema: "decisorframework_leasing",
                newName: "propertyleaseoffers",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_leasing",
                newName: "propertyleaseofferpersoncontactbridges",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_leasing",
                newName: "propertyleaseofferorganizationcontactbridges",
                newSchema: "decisorframework_production");

            migrationBuilder.RenameTable(
                name: "propertyleaseofferclausebridge",
                schema: "decisorframework_leasing",
                newName: "propertyleaseofferclausebridge",
                newSchema: "decisorframework_production");
        }
    }
}
