using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade5SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teachingcategories",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teachingcategories", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_researchers_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "teachingcategoryid");

            migrationBuilder.AddForeignKey(
                name: "fk_researchers_teachingcategories_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "teachingcategoryid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "teachingcategories",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_researchers_teachingcategories_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropTable(
                name: "teachingcategories",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropIndex(
                name: "ix_researchers_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers");
        }
    }
}
