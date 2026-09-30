using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IncludeCustomeProductionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_production");

            migrationBuilder.CreateTable(
                name: "productionqualitychecks",
                schema: "decisoriscamaguey_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    productionid = table.Column<Guid>(type: "uuid", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    qualitypercent = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionqualitychecks", x => x.id);
                    table.ForeignKey(
                        name: "fk_productionqualitychecks_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionqualitychecks_productions_productionid",
                        column: x => x.productionid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_productionqualitychecks_authorid",
                schema: "decisoriscamaguey_production",
                table: "productionqualitychecks",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_productionqualitychecks_productionid",
                schema: "decisoriscamaguey_production",
                table: "productionqualitychecks",
                column: "productionid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productionqualitychecks",
                schema: "decisoriscamaguey_production");
        }
    }
}
