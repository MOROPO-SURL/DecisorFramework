using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class Upgrade03ProductionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productioncolaboratorbridges_productionroles_roleid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_productionemployeebridges_productionroles_roleid",
                schema: "decisorframework_production",
                table: "productionemployeebridges");

            migrationBuilder.DropTable(
                name: "elaborationstepproductionrolebridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionroles",
                schema: "decisorframework_production");

            migrationBuilder.RenameColumn(
                name: "roleid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                newName: "workpositionid");

            migrationBuilder.RenameIndex(
                name: "ix_productionemployeebridges_roleid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                newName: "ix_productionemployeebridges_workpositionid");

            migrationBuilder.RenameColumn(
                name: "roleid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                newName: "workpositionid");

            migrationBuilder.RenameIndex(
                name: "ix_productioncolaboratorbridges_roleid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                newName: "ix_productioncolaboratorbridges_workpositionid");

            migrationBuilder.AddColumn<double>(
                name: "referenceamount",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "elaborationinputproductclassificationbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationinputproductclassificationbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationinputproductclassificationbridges_classification~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationinputproductclassificationbridges_elaborations_p~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationstepworkpositionbridges",
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
                    table.PrimaryKey("pk_elaborationstepworkpositionbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationstepworkpositionbridges_elaborationsteps_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationstepworkpositionbridges_workpositions_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductclassificationbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationstepworkpositionbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationstepworkpositionbridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_productioncolaboratorbridges_workpositions_workpositionid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "workpositionid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workpositions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productionemployeebridges_workpositions_workpositionid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "workpositionid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workpositions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productioncolaboratorbridges_workpositions_workpositionid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_productionemployeebridges_workpositions_workpositionid",
                schema: "decisorframework_production",
                table: "productionemployeebridges");

            migrationBuilder.DropTable(
                name: "elaborationinputproductclassificationbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationstepworkpositionbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropColumn(
                name: "referenceamount",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.DropColumn(
                name: "amount",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges");

            migrationBuilder.DropColumn(
                name: "amount",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges");

            migrationBuilder.RenameColumn(
                name: "workpositionid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                newName: "roleid");

            migrationBuilder.RenameIndex(
                name: "ix_productionemployeebridges_workpositionid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                newName: "ix_productionemployeebridges_roleid");

            migrationBuilder.RenameColumn(
                name: "workpositionid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                newName: "roleid");

            migrationBuilder.RenameIndex(
                name: "ix_productioncolaboratorbridges_workpositionid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                newName: "ix_productioncolaboratorbridges_roleid");

            migrationBuilder.CreateTable(
                name: "productionroles",
                schema: "decisorframework_production",
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
                    table.PrimaryKey("pk_productionroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "elaborationstepproductionrolebridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    linked = table.Column<bool>(type: "boolean", nullable: false),
                    participation = table.Column<decimal>(type: "numeric", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "ix_elaborationstepproductionrolebridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationstepproductionrolebridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_productioncolaboratorbridges_productionroles_roleid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "roleid",
                principalSchema: "decisorframework_production",
                principalTable: "productionroles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productionemployeebridges_productionroles_roleid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "roleid",
                principalSchema: "decisorframework_production",
                principalTable: "productionroles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
