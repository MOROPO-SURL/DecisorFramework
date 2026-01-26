using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingExtend7SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "specification",
                schema: "decisorframework_leasing",
                table: "drivelicencevehiclekindbridges",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "limitation",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "specification",
                schema: "decisorframework_leasing",
                table: "drivelicencevehiclekindbridges");

            migrationBuilder.DropColumn(
                name: "limitation",
                schema: "decisorframework_leasing",
                table: "drivelicences");
        }
    }
}
