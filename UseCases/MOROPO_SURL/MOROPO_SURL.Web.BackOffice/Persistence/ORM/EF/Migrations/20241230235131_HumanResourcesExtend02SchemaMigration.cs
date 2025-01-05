using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResourcesExtend02SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vacants_ocupationkinds_kindid",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropTable(
                name: "ocupationkinds",
                schema: "decisorframework_humanresources");

            migrationBuilder.CreateTable(
                name: "vacantkinds",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shortname = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacantkinds", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_vacants_vacantkinds_kindid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "kindid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacantkinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vacants_vacantkinds_kindid",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropTable(
                name: "vacantkinds",
                schema: "decisorframework_humanresources");

            migrationBuilder.CreateTable(
                name: "ocupationkinds",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ocupationkinds", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_vacants_ocupationkinds_kindid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "kindid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "ocupationkinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
