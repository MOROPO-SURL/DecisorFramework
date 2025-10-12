using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HHRRUpgrade6SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_employeedailycheckings_employeeid",
                schema: "decisorframework_humanresources",
                table: "employeedailycheckings");

            migrationBuilder.AddColumn<int>(
                name: "day",
                schema: "decisorframework_humanresources",
                table: "employeedailycheckings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_employeedailycheckings_employeeid_day_month_year",
                schema: "decisorframework_humanresources",
                table: "employeedailycheckings",
                columns: new[] { "employeeid", "day", "month", "year" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_employeedailycheckings_employeeid_day_month_year",
                schema: "decisorframework_humanresources",
                table: "employeedailycheckings");

            migrationBuilder.DropColumn(
                name: "day",
                schema: "decisorframework_humanresources",
                table: "employeedailycheckings");

            migrationBuilder.CreateIndex(
                name: "ix_employeedailycheckings_employeeid",
                schema: "decisorframework_humanresources",
                table: "employeedailycheckings",
                column: "employeeid");
        }
    }
}
