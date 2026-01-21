using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingExtend2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "baselineamount",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "baselineamount",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals",
                column: "baselinecurrencyid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyspaceleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals",
                column: "baselinecurrencyid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyspaceleasepropousals_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals",
                column: "baselinecurrencyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepropousals_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals",
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
                name: "fk_propertyspaceleasepropousals_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepropousals_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals");

            migrationBuilder.DropIndex(
                name: "ix_propertyspaceleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals");

            migrationBuilder.DropColumn(
                name: "baselineamount",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals");

            migrationBuilder.DropColumn(
                name: "baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals");

            migrationBuilder.DropColumn(
                name: "baselineamount",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals");

            migrationBuilder.DropColumn(
                name: "baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals");

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
    }
}
