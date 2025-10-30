using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchaseorders_unitmeasurements_estimatedadvanceunitmeasure~",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.DropColumn(
                name: "estimatedadvance",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.RenameColumn(
                name: "estimatedadvanceunitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                newName: "advancerequiredunitmeasurementid");

            migrationBuilder.RenameIndex(
                name: "ix_purchaseorders_estimatedadvanceunitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                newName: "ix_purchaseorders_advancerequiredunitmeasurementid");

            migrationBuilder.AddColumn<float>(
                name: "advancerequired",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                type: "real",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseorders_unitmeasurements_advancerequiredunitmeasurem~",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "advancerequiredunitmeasurementid",
                principalSchema: "decisorframework_domain",
                principalTable: "unitmeasurements",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchaseorders_unitmeasurements_advancerequiredunitmeasurem~",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.DropColumn(
                name: "advancerequired",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.RenameColumn(
                name: "advancerequiredunitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                newName: "estimatedadvanceunitmeasurementid");

            migrationBuilder.RenameIndex(
                name: "ix_purchaseorders_advancerequiredunitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                newName: "ix_purchaseorders_estimatedadvanceunitmeasurementid");

            migrationBuilder.AddColumn<decimal>(
                name: "estimatedadvance",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseorders_unitmeasurements_estimatedadvanceunitmeasure~",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "estimatedadvanceunitmeasurementid",
                principalSchema: "decisorframework_domain",
                principalTable: "unitmeasurements",
                principalColumn: "id");
        }
    }
}
