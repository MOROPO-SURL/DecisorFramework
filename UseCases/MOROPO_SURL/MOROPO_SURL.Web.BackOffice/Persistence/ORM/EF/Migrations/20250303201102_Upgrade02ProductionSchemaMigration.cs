using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class Upgrade02ProductionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productions_productionplans_planid",
                schema: "decisorframework_production",
                table: "productions");

            migrationBuilder.DropTable(
                name: "productionplans",
                schema: "decisorframework_production");

            migrationBuilder.CreateTable(
                name: "productionorders",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    elaborationid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    requestedfor = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    approvedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    decisorid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionorders", x => x.id);
                    table.ForeignKey(
                        name: "fk_productionorders_elaborations_elaborationid",
                        column: x => x.elaborationid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionorders_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionorders_employees_decisorid",
                        column: x => x.decisorid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionorders_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_authorid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_decisorid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "decisorid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_elaborationid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "elaborationid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_responsibleid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "responsibleid");

            migrationBuilder.AddForeignKey(
                name: "fk_productions_productionorders_planid",
                schema: "decisorframework_production",
                table: "productions",
                column: "planid",
                principalSchema: "decisorframework_production",
                principalTable: "productionorders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productions_productionorders_planid",
                schema: "decisorframework_production",
                table: "productions");

            migrationBuilder.DropTable(
                name: "productionorders",
                schema: "decisorframework_production");

            migrationBuilder.CreateTable(
                name: "productionplans",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    decisorid = table.Column<Guid>(type: "uuid", nullable: false),
                    elaborationid = table.Column<Guid>(type: "uuid", nullable: false),
                    plannerid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    approvedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    plannedfor = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionplans", x => x.id);
                    table.ForeignKey(
                        name: "fk_productionplans_elaborations_elaborationid",
                        column: x => x.elaborationid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionplans_employees_decisorid",
                        column: x => x.decisorid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionplans_employees_plannerid",
                        column: x => x.plannerid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionplans_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_productionplans_decisorid",
                schema: "decisorframework_production",
                table: "productionplans",
                column: "decisorid");

            migrationBuilder.CreateIndex(
                name: "ix_productionplans_elaborationid",
                schema: "decisorframework_production",
                table: "productionplans",
                column: "elaborationid");

            migrationBuilder.CreateIndex(
                name: "ix_productionplans_plannerid",
                schema: "decisorframework_production",
                table: "productionplans",
                column: "plannerid");

            migrationBuilder.CreateIndex(
                name: "ix_productionplans_responsibleid",
                schema: "decisorframework_production",
                table: "productionplans",
                column: "responsibleid");

            migrationBuilder.AddForeignKey(
                name: "fk_productions_productionplans_planid",
                schema: "decisorframework_production",
                table: "productions",
                column: "planid",
                principalSchema: "decisorframework_production",
                principalTable: "productionplans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
