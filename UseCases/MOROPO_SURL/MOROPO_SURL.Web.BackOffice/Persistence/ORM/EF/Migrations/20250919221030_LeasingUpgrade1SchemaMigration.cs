using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "archived",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "archived",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "archived",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "archived",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "archived",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropColumn(
                name: "archived",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations");

            migrationBuilder.DropColumn(
                name: "archived",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropColumn(
                name: "archived",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations");
        }
    }
}
