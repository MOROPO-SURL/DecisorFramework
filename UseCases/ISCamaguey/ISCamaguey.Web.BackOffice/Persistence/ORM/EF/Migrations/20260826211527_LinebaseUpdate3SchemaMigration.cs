using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LinebaseUpdate3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productions_productionorders_planid",
                schema: "decisorframework_production",
                table: "productions");

            migrationBuilder.RenameColumn(
                name: "planid",
                schema: "decisorframework_production",
                table: "productions",
                newName: "orderid");

            migrationBuilder.RenameIndex(
                name: "ix_productions_planid",
                schema: "decisorframework_production",
                table: "productions",
                newName: "ix_productions_orderid");

            migrationBuilder.AddForeignKey(
                name: "fk_productions_productionorders_orderid",
                schema: "decisorframework_production",
                table: "productions",
                column: "orderid",
                principalSchema: "decisorframework_production",
                principalTable: "productionorders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productions_productionorders_orderid",
                schema: "decisorframework_production",
                table: "productions");

            migrationBuilder.RenameColumn(
                name: "orderid",
                schema: "decisorframework_production",
                table: "productions",
                newName: "planid");

            migrationBuilder.RenameIndex(
                name: "ix_productions_orderid",
                schema: "decisorframework_production",
                table: "productions",
                newName: "ix_productions_planid");

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
    }
}
