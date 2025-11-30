using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ProductionUpgrade4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisorframework_production",
                table: "elaborationsteps",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisorframework_production",
                table: "elaborationsteps",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
