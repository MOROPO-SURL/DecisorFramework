using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResoursesUpgrade4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "namingresolutionrequired",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.AddColumn<int>(
                name: "vacantocupationmode",
                schema: "decisorframework_humanresources",
                table: "vacants",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vacantocupationmode",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.AddColumn<bool>(
                name: "namingresolutionrequired",
                schema: "decisorframework_humanresources",
                table: "vacants",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
