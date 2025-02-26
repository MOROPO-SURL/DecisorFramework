using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseZoneSpenBridgeSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "currencyid",
                schema: "decisorframework_purchasing",
                table: "purchasezonespentbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_purchasezonespentbridges_currencyid",
                schema: "decisorframework_purchasing",
                table: "purchasezonespentbridges",
                column: "currencyid");

            migrationBuilder.AddForeignKey(
                name: "fk_purchasezonespentbridges_currencies_currencyid",
                schema: "decisorframework_purchasing",
                table: "purchasezonespentbridges",
                column: "currencyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchasezonespentbridges_currencies_currencyid",
                schema: "decisorframework_purchasing",
                table: "purchasezonespentbridges");

            migrationBuilder.DropIndex(
                name: "ix_purchasezonespentbridges_currencyid",
                schema: "decisorframework_purchasing",
                table: "purchasezonespentbridges");

            migrationBuilder.DropColumn(
                name: "currencyid",
                schema: "decisorframework_purchasing",
                table: "purchasezonespentbridges");
        }
    }
}
