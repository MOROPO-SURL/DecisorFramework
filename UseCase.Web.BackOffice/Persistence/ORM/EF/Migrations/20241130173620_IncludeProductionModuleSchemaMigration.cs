using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IncludeProductionModuleSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "decisorframework_production");

            migrationBuilder.CreateTable(
                name: "elaborations",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    minperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    maxperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborations", x => x.id);
                    table.ForeignKey(
                        name: "fk_elaborations_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionroles",
                schema: "decisorframework_production",
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
                    table.PrimaryKey("pk_productionroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "elaborationinputproductbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationinputproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationinputproductbridges_elaborations_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationinputproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationoutputproductbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    minperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    maxperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationoutputproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductbridges_elaborations_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationsteps",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    elaborationid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    mindecrease = table.Column<decimal>(type: "numeric", nullable: false),
                    maxdecrease = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationsteps", x => x.id);
                    table.ForeignKey(
                        name: "fk_elaborationsteps_elaborations_elaborationid",
                        column: x => x.elaborationid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionplans",
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
                    plannedfor = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    approvedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    plannerid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    decisorid = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "elaborationstepproductionrolebridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    participation = table.Column<decimal>(type: "numeric", nullable: false),
                    linked = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationstepproductionrolebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationstepproductionrolebridges_elaborationsteps_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationstepproductionrolebridges_productionroles_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productionroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productions",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    planid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productions", x => x.id);
                    table.ForeignKey(
                        name: "fk_productions_productionplans_planid",
                        column: x => x.planid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productionplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productions_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departures",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    productionid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departures", x => x.id);
                    table.ForeignKey(
                        name: "FK_departures_departures_id",
                        column: x => x.id,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "departures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_departures_productions_productionid",
                        column: x => x.productionid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "productioncolaboratorbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    stepid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productioncolaboratorbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_colaborators_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_essential",
                        principalTable: "colaborators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_elaborationsteps_stepid",
                        column: x => x.stepid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_productionroles_roleid",
                        column: x => x.roleid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productionroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_productions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionemployeebridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    stepid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_elaborationsteps_stepid",
                        column: x => x.stepid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_productionroles_roleid",
                        column: x => x.roleid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productionroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_productions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionproductbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productionproductbridges_productions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionproductbridges_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receptions",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    productionid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_receptions_receptions_id",
                        column: x => x.id,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "receptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_receptions_productions_productionid",
                        column: x => x.productionid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_departures_productionid",
                schema: "decisorframework_production",
                table: "departures",
                column: "productionid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborations_productid",
                schema: "decisorframework_production",
                table: "elaborations",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationstepproductionrolebridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationstepproductionrolebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationsteps_elaborationid",
                schema: "decisorframework_production",
                table: "elaborationsteps",
                column: "elaborationid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridges_roleid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridges_stepid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "stepid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridges_sternid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridges_roleid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridges_stepid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "stepid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridges_sternid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "sternid");

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

            migrationBuilder.CreateIndex(
                name: "ix_productionproductbridges_sternid",
                schema: "decisorframework_production",
                table: "productionproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionproductbridges_unitmeasurementid",
                schema: "decisorframework_production",
                table: "productionproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_productions_planid",
                schema: "decisorframework_production",
                table: "productions",
                column: "planid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productions_unitmeasurementid",
                schema: "decisorframework_production",
                table: "productions",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_receptions_productionid",
                schema: "decisorframework_production",
                table: "receptions",
                column: "productionid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departures",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationinputproductbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationoutputproductbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationstepproductionrolebridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productioncolaboratorbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionemployeebridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionproductbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "receptions",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationsteps",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionroles",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productions",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionplans",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborations",
                schema: "decisorframework_production");
        }
    }
}
