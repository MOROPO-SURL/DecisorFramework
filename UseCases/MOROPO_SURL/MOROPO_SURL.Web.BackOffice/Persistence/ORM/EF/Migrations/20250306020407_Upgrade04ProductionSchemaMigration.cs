using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class Upgrade04ProductionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "referenceamount",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<Guid>(
                name: "classificcationid",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_elaborations_classificcationid",
                schema: "decisorframework_production",
                table: "elaborations",
                column: "classificcationid");

            migrationBuilder.AddForeignKey(
                name: "fk_elaborations_classifications_classificcationid",
                schema: "decisorframework_production",
                table: "elaborations",
                column: "classificcationid",
                principalSchema: "decisorframework_inventory",
                principalTable: "classifications",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_elaborations_classifications_classificcationid",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.DropIndex(
                name: "ix_elaborations_classificcationid",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.DropColumn(
                name: "classificcationid",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.AlterColumn<double>(
                name: "referenceamount",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
