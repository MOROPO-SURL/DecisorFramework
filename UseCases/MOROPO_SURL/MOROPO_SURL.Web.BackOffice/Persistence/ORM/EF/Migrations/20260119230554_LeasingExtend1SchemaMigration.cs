using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingExtend1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "operativelicencecode",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "baselineamount",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "baselineamount",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseoffers_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "baselinecurrencyid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseoffers_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "baselinecurrencyid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseoffers_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "baselinecurrencyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseoffers_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "baselinecurrencyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseoffers_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseoffers_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleaseoffers_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropIndex(
                name: "ix_propertyleaseoffers_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.DropColumn(
                name: "operativelicencecode",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "baselineamount",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropColumn(
                name: "baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropColumn(
                name: "baselineamount",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.DropColumn(
                name: "baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");
        }
    }
}
