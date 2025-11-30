using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LinebaseProductionUpdate1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "referenceamount",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.RenameColumn(
                name: "linked",
                schema: "decisorframework_production",
                table: "elaborationstepworkpositionbridges",
                newName: "relative");

            migrationBuilder.AlterColumn<decimal>(
                name: "participation",
                schema: "decisorframework_production",
                table: "elaborationstepworkpositionbridges",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

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

            migrationBuilder.AddColumn<Guid>(
                name: "parentid",
                schema: "decisorframework_production",
                table: "elaborationsteps",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "elaborationoutputproductclassificationbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    minperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    maxperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationoutputproductclassificationbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductclassificationbridges_classificatio~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductclassificationbridges_elaborations_~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductclassificationbridges_unitmeasureme~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_elaborationsteps_parentid",
                schema: "decisorframework_production",
                table: "elaborationsteps",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductbridges_unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductclassificationbridges_unitmeasuremen~",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductbridges_unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductclassificationbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductclassificationbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductclassificationbridges_unitmeasureme~",
                schema: "decisorframework_production",
                table: "elaborationoutputproductclassificationbridges",
                column: "unitmeasurementid");

            migrationBuilder.AddForeignKey(
                name: "fk_elaborationinputproductbridges_unitmeasurements_unitmeasure~",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges",
                column: "unitmeasurementid",
                principalSchema: "decisorframework_domain",
                principalTable: "unitmeasurements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_elaborationinputproductclassificationbridges_unitmeasuremen~",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges",
                column: "unitmeasurementid",
                principalSchema: "decisorframework_domain",
                principalTable: "unitmeasurements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_elaborationoutputproductbridges_unitmeasurements_unitmeasur~",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges",
                column: "unitmeasurementid",
                principalSchema: "decisorframework_domain",
                principalTable: "unitmeasurements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_elaborationsteps_elaborationsteps_parentid",
                schema: "decisorframework_production",
                table: "elaborationsteps",
                column: "parentid",
                principalSchema: "decisorframework_production",
                principalTable: "elaborationsteps",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_elaborationinputproductbridges_unitmeasurements_unitmeasure~",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_elaborationinputproductclassificationbridges_unitmeasuremen~",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_elaborationoutputproductbridges_unitmeasurements_unitmeasur~",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_elaborationsteps_elaborationsteps_parentid",
                schema: "decisorframework_production",
                table: "elaborationsteps");

            migrationBuilder.DropTable(
                name: "elaborationoutputproductclassificationbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropIndex(
                name: "ix_elaborationsteps_parentid",
                schema: "decisorframework_production",
                table: "elaborationsteps");

            migrationBuilder.DropIndex(
                name: "ix_elaborationoutputproductbridges_unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges");

            migrationBuilder.DropIndex(
                name: "ix_elaborationinputproductclassificationbridges_unitmeasuremen~",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges");

            migrationBuilder.DropIndex(
                name: "ix_elaborationinputproductbridges_unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges");

            migrationBuilder.DropColumn(
                name: "parentid",
                schema: "decisorframework_production",
                table: "elaborationsteps");

            migrationBuilder.DropColumn(
                name: "unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges");

            migrationBuilder.DropColumn(
                name: "unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges");

            migrationBuilder.DropColumn(
                name: "unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges");

            migrationBuilder.RenameColumn(
                name: "relative",
                schema: "decisorframework_production",
                table: "elaborationstepworkpositionbridges",
                newName: "linked");

            migrationBuilder.AlterColumn<decimal>(
                name: "participation",
                schema: "decisorframework_production",
                table: "elaborationstepworkpositionbridges",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisorframework_production",
                table: "elaborationsteps",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<decimal>(
                name: "referenceamount",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
