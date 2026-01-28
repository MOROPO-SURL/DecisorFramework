using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LinebaseUpdate2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vacant_workforceorganizationalunity_workforceorganizational~",
                schema: "decisorframework_humanresources",
                table: "vacant");

            migrationBuilder.DropTable(
                name: "legclientvehleaspersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientvehleaspersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.AddColumn<Guid>(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforce",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AlterColumn<Guid>(
                name: "workforceorganizationalunityid",
                schema: "decisorframework_humanresources",
                table: "vacant",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
                name: "drivelicences",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    reference = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    releasedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expireat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    limitation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drivelicences", x => x.id);
                    table.ForeignKey(
                        name: "fk_drivelicences_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "drivelicencevehiclekindbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    category = table.Column<int>(type: "integer", nullable: false),
                    specification = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    achievedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drivelicencevehiclekindbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_drivelicencevehiclekindbridges_drivelicences_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "drivelicences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_drivelicencevehiclekindbridges_vehiclekinds_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehiclekinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientvehleasdrivlicbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientvehleasdrivlicbridges_drivelicences_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "drivelicences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientvehleasdrivlicbridges_legalclientvehicleleasings_p~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientvehleasdrivlicbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientvehleasdrivlicbridges_drivelicences_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "drivelicences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientvehleasdrivlicbridges_naturalclientvehicleleasings~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasings",
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
                name: "ix_workforce_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforce",
                column: "chiefvacantid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals",
                column: "baselinecurrencyid");

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
                name: "ix_drivelicences_contactid",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_drivelicencevehiclekindbridges_sternid",
                schema: "decisorframework_leasing",
                table: "drivelicencevehiclekindbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehleasdrivlicbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientvehleasdrivlicbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehleasdrivlicbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientvehleasdrivlicbridges",
                column: "sternid");

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
                name: "fk_vacant_workforceorganizationalunity_workforceorganizational~",
                schema: "decisorframework_humanresources",
                table: "vacant",
                column: "workforceorganizationalunityid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforceorganizationalunity",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseoffers_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
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

            migrationBuilder.AddForeignKey(
                name: "fk_workforce_vacant_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforce",
                column: "chiefvacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacant",
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
                name: "fk_vacant_workforceorganizationalunity_workforceorganizational~",
                schema: "decisorframework_humanresources",
                table: "vacant");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseoffers_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepropousals_currencies_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals");

            migrationBuilder.DropForeignKey(
                name: "fk_workforce_vacant_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforce");

            migrationBuilder.DropTable(
                name: "drivelicencevehiclekindbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleaseofferspacespecificationclausebridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "drivelicences",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleaseofferspacespecifications",
                schema: "decisorframework_leasing");

            migrationBuilder.DropIndex(
                name: "ix_workforce_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforce");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals");

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
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforce");

            migrationBuilder.DropColumn(
                name: "operativelicencecode",
                schema: "decisorframework_domain",
                table: "vehicles");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "workforceorganizationalunityid",
                schema: "decisorframework_humanresources",
                table: "vacant",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "legclientvehleaspersoncontactbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientvehleaspersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientvehleaspersoncontactbridges_legalclientvehicleleas~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientvehleaspersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientvehleaspersoncontactbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientvehleaspersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientvehleaspersoncontactbridges_naturalclientvehiclele~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientvehleaspersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehleaspersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientvehleaspersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehleaspersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientvehleaspersoncontactbridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_vacant_workforceorganizationalunity_workforceorganizational~",
                schema: "decisorframework_humanresources",
                table: "vacant",
                column: "workforceorganizationalunityid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforceorganizationalunity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
