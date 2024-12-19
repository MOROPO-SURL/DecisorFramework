using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendContactProductAndServiceBridgeSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "decisorframework_commercial",
                table: "contactservicebridges",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "evaluation",
                schema: "decisorframework_commercial",
                table: "contactservicebridges",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "decisorframework_commercial",
                table: "contactproductbridges",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "evaluation",
                schema: "decisorframework_commercial",
                table: "contactproductbridges",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                schema: "decisorframework_commercial",
                table: "contactservicebridges");

            migrationBuilder.DropColumn(
                name: "evaluation",
                schema: "decisorframework_commercial",
                table: "contactservicebridges");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "decisorframework_commercial",
                table: "contactproductbridges");

            migrationBuilder.DropColumn(
                name: "evaluation",
                schema: "decisorframework_commercial",
                table: "contactproductbridges");
        }
    }
}
