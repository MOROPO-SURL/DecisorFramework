using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingOfferInclusionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "assignment",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "assignment",
                schema: "decisorframework_domain",
                table: "properties",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "propertyleaseoffers",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    propertyid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    openat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    closedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseoffers", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleaseoffers_properties_propertyid",
                        column: x => x.propertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleaseoffers",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicleid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    openat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    closedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleaseoffers", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicleleaseoffers_vehicles_vehicleid",
                        column: x => x.vehicleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    credentialdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: false),
                    stateidentificationcode = table.Column<string>(type: "text", nullable: true),
                    argument = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseofferorganizationcontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseofferorganizationcontactbridges_documents_cred~",
                        column: x => x.credentialdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_propertyleaseofferorganizationcontactbridges_organizationco~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferorganizationcontactbridges_propertyleaseo~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "propertyleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    credentialdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    businesskindid = table.Column<Guid>(type: "uuid", nullable: false),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseofferpersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseofferpersoncontactbridges_documents_credential~",
                        column: x => x.credentialdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_propertyleaseofferpersoncontactbridges_naturalbusinesskinds~",
                        column: x => x.businesskindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "naturalbusinesskinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferpersoncontactbridges_personcontacts_stern~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferpersoncontactbridges_propertyleaseoffers_~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "propertyleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    credentialdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: false),
                    stateidentificationcode = table.Column<string>(type: "text", nullable: true),
                    argument = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleaseofferorganizationcontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferorganizationcontactbridges_documents_crede~",
                        column: x => x.credentialdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferorganizationcontactbridges_organizationcon~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferorganizationcontactbridges_vehicleleaseoff~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "vehicleleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    credentialdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    businesskindid = table.Column<Guid>(type: "uuid", nullable: false),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleaseofferpersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferpersoncontactbridges_documents_credentiald~",
                        column: x => x.credentialdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferpersoncontactbridges_naturalbusinesskinds_~",
                        column: x => x.businesskindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "naturalbusinesskinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferpersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferpersoncontactbridges_vehicleleaseoffers_pr~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "vehicleleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferorganizationcontactbridges_credentialdocu~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "credentialdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferorganizationcontactbridges_sternid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_businesskindid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_credentialdocumentid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "credentialdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_sternid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseoffers_propertyid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers",
                column: "propertyid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseofferorganizationcontactbridges_credentialdocum~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "credentialdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseofferorganizationcontactbridges_sternid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_businesskindid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_credentialdocumentid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "credentialdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_sternid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseoffers_vehicleid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers",
                column: "vehicleid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "propertyleaseoffers",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "vehicleleaseoffers",
                schema: "decisorframework_production");

            migrationBuilder.DropColumn(
                name: "assignment",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "assignment",
                schema: "decisorframework_domain",
                table: "properties");
        }
    }
}
