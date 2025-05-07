using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class BaseLineUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_naturalclients_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviders_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_images_featureimageid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehiclebrands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehiclecategories_categoryid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "vehiclebrands",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "vehiclecategories",
                schema: "decisorframework_domain");

            migrationBuilder.DropIndex(
                name: "ix_vehicles_categoryid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "ix_naturalproviders_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropIndex(
                name: "ix_naturalclients_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropColumn(
                name: "categoryid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropColumn(
                name: "taxidentificationnumber",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropColumn(
                name: "taxidentificationnumber",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_production");

            migrationBuilder.AlterColumn<Guid>(
                name: "featureimageid",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "assignment",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "kindid",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "productionid",
                table: "receptions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "assignment",
                schema: "decisorframework_domain",
                table: "properties",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "stateidentificationcode",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "taxidentificationnumber",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "brands",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "elaborations",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificcationid = table.Column<Guid>(type: "uuid", nullable: true),
                    referenceamount = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    minperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    maxperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborations", x => x.id);
                    table.ForeignKey(
                        name: "fk_elaborations_classifications_classificcationid",
                        column: x => x.classificcationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_elaborations_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientdocumentbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalclientdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientdocumentbridges_legalclients_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviderdocumentbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalproviderdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderdocumentbridges_legalproviders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientdocumentbridge",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientdocumentbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalclientdocumentbridge_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientdocumentbridge_naturalclients_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderdocumentbridge",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderdocumentbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalproviderdocumentbridge_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderdocumentbridge_naturalproviders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "vehiclekinds",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiclekinds", x => x.id);
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
                name: "elaborationinputproductbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationinputproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationinputproductbridges_elaborations_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationinputproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationinputproductclassificationbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationinputproductclassificationbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationinputproductclassificationbridges_classification~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationinputproductclassificationbridges_elaborations_p~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationoutputproductbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    minperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    maxperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationoutputproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductbridges_elaborations_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationsteps",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    elaborationid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    mindecrease = table.Column<decimal>(type: "numeric", nullable: false),
                    maxdecrease = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationsteps", x => x.id);
                    table.ForeignKey(
                        name: "fk_elaborationsteps_elaborations_elaborationid",
                        column: x => x.elaborationid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionorders",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    elaborationid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    requestedfor = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    approvedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    decisorid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionorders", x => x.id);
                    table.ForeignKey(
                        name: "fk_productionorders_elaborations_elaborationid",
                        column: x => x.elaborationid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionorders_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionorders_employees_decisorid",
                        column: x => x.decisorid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionorders_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
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

            migrationBuilder.CreateTable(
                name: "elaborationstepworkpositionbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    participation = table.Column<decimal>(type: "numeric", nullable: false),
                    linked = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationstepworkpositionbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationstepworkpositionbridges_elaborationsteps_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationstepworkpositionbridges_workpositions_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productions",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    planid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productions", x => x.id);
                    table.ForeignKey(
                        name: "fk_productions_productionorders_planid",
                        column: x => x.planid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productionorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productions_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departures",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    productionid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departures", x => x.id);
                    table.ForeignKey(
                        name: "FK_departures_departures_id",
                        column: x => x.id,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "departures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_departures_productions_productionid",
                        column: x => x.productionid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "productioncolaboratorbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    stepid = table.Column<Guid>(type: "uuid", nullable: false),
                    workpositionid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productioncolaboratorbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_colaborators_sternid",
                        column: x => x.sternid,
                        principalTable: "colaborators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_elaborationsteps_stepid",
                        column: x => x.stepid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_productions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_workpositions_workpositionid",
                        column: x => x.workpositionid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionemployeebridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    stepid = table.Column<Guid>(type: "uuid", nullable: false),
                    workpositionid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_elaborationsteps_stepid",
                        column: x => x.stepid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_productions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_workpositions_workpositionid",
                        column: x => x.workpositionid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionproductbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productionproductbridges_productions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionproductbridges_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_kindid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_receptions_productionid",
                table: "receptions",
                column: "productionid");

            migrationBuilder.CreateIndex(
                name: "ix_personcontacts_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_personcontacts_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "mainpostalcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "mainpostalcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "representativeid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "workforceid");

            migrationBuilder.CreateIndex(
                name: "ix_departures_productionid",
                schema: "decisorframework_production",
                table: "departures",
                column: "productionid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductclassificationbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborations_classificcationid",
                schema: "decisorframework_production",
                table: "elaborations",
                column: "classificcationid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborations_productid",
                schema: "decisorframework_production",
                table: "elaborations",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationsteps_elaborationid",
                schema: "decisorframework_production",
                table: "elaborationsteps",
                column: "elaborationid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationstepworkpositionbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationstepworkpositionbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientdocumentbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalclientdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderdocumentbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalproviderdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientdocumentbridge_sternid",
                schema: "decisorframework_commercial",
                table: "naturalclientdocumentbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderdocumentbridge_sternid",
                schema: "decisorframework_commercial",
                table: "naturalproviderdocumentbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridges_stepid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "stepid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridges_sternid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridges_workpositionid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "workpositionid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridges_stepid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "stepid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridges_sternid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridges_workpositionid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "workpositionid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_authorid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_decisorid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "decisorid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_elaborationid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "elaborationid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_responsibleid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_productionproductbridges_sternid",
                schema: "decisorframework_production",
                table: "productionproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionproductbridges_unitmeasurementid",
                schema: "decisorframework_production",
                table: "productionproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_productions_planid",
                schema: "decisorframework_production",
                table: "productions",
                column: "planid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productions_unitmeasurementid",
                schema: "decisorframework_production",
                table: "productions",
                column: "unitmeasurementid");

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

            migrationBuilder.AddForeignKey(
                name: "fk_ocupations_workforces_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "workforceid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationcontacts_personcontacts_representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "representativeid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_organizationcontacts_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "mainpostalcontactid",
                principalSchema: "guamaframework_identity",
                principalTable: "postalcontactitems",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_personcontacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_personcontacts_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "mainpostalcontactid",
                principalSchema: "guamaframework_identity",
                principalTable: "postalcontactitems",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_receptions_productions_productionid",
                table: "receptions",
                column: "productionid",
                principalSchema: "decisorframework_production",
                principalTable: "productions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_brands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "brandid",
                principalSchema: "decisorframework_domain",
                principalTable: "brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_images_featureimageid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "featureimageid",
                principalSchema: "guamaframework_media",
                principalTable: "images",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehiclekinds_kindid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "kindid",
                principalSchema: "decisorframework_domain",
                principalTable: "vehiclekinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_ocupations_workforces_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationcontacts_personcontacts_representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationcontacts_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropForeignKey(
                name: "fk_personcontacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropForeignKey(
                name: "fk_personcontacts_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropForeignKey(
                name: "fk_receptions_productions_productionid",
                table: "receptions");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_brands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_images_featureimageid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehiclekinds_kindid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "departures",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationinputproductbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationinputproductclassificationbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationoutputproductbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationstepworkpositionbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "legalclientdocumentbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalproviderdocumentbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalclientdocumentbridge",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderdocumentbridge",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "productioncolaboratorbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionemployeebridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionproductbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "vehiclekinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationsteps",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productions",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "propertyleaseoffers",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "vehicleleaseoffers",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionorders",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborations",
                schema: "decisorframework_production");

            migrationBuilder.DropIndex(
                name: "ix_vehicles_kindid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "ix_receptions_productionid",
                table: "receptions");

            migrationBuilder.DropIndex(
                name: "ix_personcontacts_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropIndex(
                name: "ix_personcontacts_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropIndex(
                name: "ix_organizationcontacts_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropIndex(
                name: "ix_organizationcontacts_representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropIndex(
                name: "ix_ocupations_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropColumn(
                name: "assignment",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "kindid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "productionid",
                table: "receptions");

            migrationBuilder.DropColumn(
                name: "assignment",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropColumn(
                name: "mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropColumn(
                name: "mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropColumn(
                name: "representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropColumn(
                name: "stateidentificationcode",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropColumn(
                name: "taxidentificationnumber",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropColumn(
                name: "workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.AlterColumn<Guid>(
                name: "featureimageid",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoryid",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "taxidentificationnumber",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "taxidentificationnumber",
                schema: "decisorframework_commercial",
                table: "legalclients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "vehiclebrands",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiclebrands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehiclecategories",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parentid = table.Column<int>(type: "integer", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiclecategories", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehiclecategories_vehiclecategories_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehiclecategories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_categoryid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviders_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclients_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_vehiclecategories_parentid",
                schema: "decisorframework_domain",
                table: "vehiclecategories",
                column: "parentid");

            migrationBuilder.AddForeignKey(
                name: "fk_naturalclients_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviders_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_images_featureimageid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "featureimageid",
                principalSchema: "guamaframework_media",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehiclebrands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "brandid",
                principalSchema: "decisorframework_domain",
                principalTable: "vehiclebrands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehiclecategories_categoryid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "categoryid",
                principalSchema: "decisorframework_domain",
                principalTable: "vehiclecategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
