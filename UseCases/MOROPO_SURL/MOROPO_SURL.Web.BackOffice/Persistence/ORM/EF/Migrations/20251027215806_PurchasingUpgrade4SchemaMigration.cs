using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchaseorders_unitmeasurements_advancerequiredunitmeasurem~",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.RenameColumn(
                name: "advancerequiredunitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                newName: "advancerequiredcurrencyid");

            migrationBuilder.RenameIndex(
                name: "ix_purchaseorders_advancerequiredunitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                newName: "ix_purchaseorders_advancerequiredcurrencyid");

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseorders_currencies_advancerequiredcurrencyid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "advancerequiredcurrencyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchaseorders_currencies_advancerequiredcurrencyid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.RenameColumn(
                name: "advancerequiredcurrencyid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                newName: "advancerequiredunitmeasurementid");

            migrationBuilder.RenameIndex(
                name: "ix_purchaseorders_advancerequiredcurrencyid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                newName: "ix_purchaseorders_advancerequiredunitmeasurementid");

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseorders_unitmeasurements_advancerequiredunitmeasurem~",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "advancerequiredunitmeasurementid",
                principalSchema: "decisorframework_domain",
                principalTable: "unitmeasurements",
                principalColumn: "id");
        }
    }
}
