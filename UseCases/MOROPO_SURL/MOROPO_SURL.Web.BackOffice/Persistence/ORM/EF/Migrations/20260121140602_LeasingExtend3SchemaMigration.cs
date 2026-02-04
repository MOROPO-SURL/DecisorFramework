using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingExtend3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyspaceleasepropousals_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals");

            migrationBuilder.DropIndex(
                name: "ix_propertyspaceleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals");

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
                table: "propertyleasepropousals",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleasepropousals",
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

            migrationBuilder.CreateTable(
                name: "propertyleaseofferspacespecifications",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    spaceid = table.Column<Guid>(type: "uuid", nullable: false),
                    baselineamount = table.Column<decimal>(type: "numeric", nullable: false),
                    baselinecurrencyid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseofferspacespecifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferspacespecifications_currencies_baselinecu~",
                        column: x => x.baselinecurrencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferspacespecifications_propertyleaseoffers_o~",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferspacespecifications_propertyspaces_spaceid",
                        column: x => x.spaceid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "propertyspaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleaseofferspacespecificationclausebridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseofferspacespecificationclausebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseofferspacespecificationclausebridges_clauses_s~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clauses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferspacespecificationclausebridges_propertyl~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseofferspacespecifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseoffers_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "baselinecurrencyid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleasepropousals",
                column: "baselinecurrencyid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseoffers_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "baselinecurrencyid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferspacespecificationclausebridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferspacespecificationclausebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferspacespecifications_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferspacespecifications",
                column: "baselinecurrencyid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferspacespecifications_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferspacespecifications",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferspacespecifications_spaceid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferspacespecifications",
                column: "spaceid");

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
                name: "fk_propertyleasepropousals_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleasepropousals",
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
                name: "fk_propertyleasepropousals_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleasepropousals");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseoffers_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropTable(
                name: "propertyleaseofferspacespecificationclausebridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleaseofferspacespecifications",
                schema: "decisorframework_leasing");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleaseoffers_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropIndex(
                name: "ix_propertyleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleasepropousals");

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
                table: "propertyleasepropousals");

            migrationBuilder.DropColumn(
                name: "baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleasepropousals");

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
        }
    }
}
