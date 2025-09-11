using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridges_documen~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridges_propert~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorganizationpostulations_organizationcontacts_~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorganizationpostulations_propertyleaseoffers_o~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorgpostulationspacepropousalbridges_propertyle~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorgpostulationspacepropousalbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorgpostulationspacepropousalbridges_propertysp~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorgpostulationspacepropousalbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridges_propertylease~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulations_naturalbusinesskinds_busine~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulations_propertyleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseperspostulationspacepropousalbridges_propertyl~",
                schema: "decisorframework_leasing",
                table: "propertyleaseperspostulationspacepropousalbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseperspostulationspacepropousalbridges_propertys~",
                schema: "decisorframework_leasing",
                table: "propertyleaseperspostulationspacepropousalbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridges_document~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridges_vehiclel~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseorganizationpostulations_organizationcontacts_c~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseorganizationpostulations_vehicleleaseoffers_off~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridges_documents_ster~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridges_vehicleleasepe~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulations_naturalbusinesskinds_busines~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulations_vehicleleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations");

            migrationBuilder.DropTable(
                name: "propertyleasecontractspacebridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleasingcompensationdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleasingpersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertysupervisioncontrolactions",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehicleleasingcompensationdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehicleleasingpersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehiclesupervisioncontrolactions",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleasingcompensation",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehicleleasingcompensations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleasings",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehicleleasings",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleasecontracts",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehicleleasecontract",
                schema: "decisorframework_leasing");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleasepersonpostulations",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseperspostulationspacepropousalbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseperspostulationspacepropousalbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleasepersonpostulations",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseorgpostulationspacepropousalbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseorgpostulationspacepropousalbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges");

            migrationBuilder.RenameTable(
                name: "vehicleleasepersonpostulations",
                schema: "decisorframework_leasing",
                newName: "vehleaspersonpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                newName: "vehleaspersonpostdocumentbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                newName: "vehleasorgpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                newName: "vehleasorgpostdocumentbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseperspostulationspacepropousalbridges",
                schema: "decisorframework_leasing",
                newName: "propleasperspostspacepropbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleasepersonpostulations",
                schema: "decisorframework_leasing",
                newName: "propleaspersonpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseorgpostulationspacepropousalbridges",
                schema: "decisorframework_leasing",
                newName: "propleaseorgpostspacepropousalbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                newName: "propleasorgpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                newName: "propleasorgpostdocumentbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleasepersonpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                newName: "ix_vehleaspersonpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleasepersonpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                newName: "ix_vehleaspersonpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleasepersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                newName: "ix_vehleaspersonpostulations_businesskindid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleasepersonpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostdocumentbridges",
                newName: "ix_vehleaspersonpostdocumentbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseorganizationpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                newName: "ix_vehleasorgpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseorganizationpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                newName: "ix_vehleasorgpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseorganizationpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostdocumentbridges",
                newName: "ix_vehleasorgpostdocumentbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseperspostulationspacepropousalbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propleasperspostspacepropbridges",
                newName: "ix_propleasperspostspacepropbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleasepersonpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                newName: "ix_propleaspersonpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleasepersonpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                newName: "ix_propleaspersonpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleasepersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                newName: "ix_propleaspersonpostulations_businesskindid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseorgpostulationspacepropousalbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propleaseorgpostspacepropousalbridges",
                newName: "ix_propleaseorgpostspacepropousalbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseorganizationpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                newName: "ix_propleasorgpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseorganizationpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                newName: "ix_propleasorgpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseorganizationpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostdocumentbridges",
                newName: "ix_propleasorgpostdocumentbridges_sternid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehleaspersonpostulations",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehleaspersonpostdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostdocumentbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehleasorgpostulations",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehleasorgpostdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostdocumentbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propleasperspostspacepropbridges",
                schema: "decisorframework_leasing",
                table: "propleasperspostspacepropbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propleaspersonpostulations",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_propleaseorgpostspacepropousalbridges",
                schema: "decisorframework_leasing",
                table: "propleaseorgpostspacepropousalbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propleasorgpostulations",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_propleasorgpostdocumentbridges",
                schema: "decisorframework_leasing",
                table: "propleasorgpostdocumentbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.CreateTable(
                name: "leasecontracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    feed = table.Column<double>(type: "double precision", nullable: false),
                    feeddurationunitmeasurekind = table.Column<int>(type: "integer", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    postulationid = table.Column<Guid>(type: "uuid", nullable: true),
                    clientid = table.Column<Guid>(type: "uuid", nullable: true),
                    propertyid = table.Column<Guid>(type: "uuid", nullable: true),
                    year = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_leasecontracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_leasecontracts_legalclients_clientid",
                        column: x => x.clientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_leasecontracts_naturalclients_clientid",
                        column: x => x.clientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_leasecontracts_properties_propertyid",
                        column: x => x.propertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_leasecontracts_propleasorgpostulations_postulationid",
                        column: x => x.postulationid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propleasorgpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_leasecontracts_propleaspersonpostulations_postulationid",
                        column: x => x.postulationid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propleaspersonpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientvehicleleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    operativelicencecode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientvehicleleasings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientvehicleleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    operativelicencecode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientvehicleleasings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "legalclientpropertyleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientpropertyleasings", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclientpropertyleasings_leasecontracts_contractid",
                        column: x => x.contractid,
                        principalTable: "leasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientpropleascontractspacebridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<int>(type: "integer", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientpropleascontractspacebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientpropleascontractspacebridges_leasecontracts_prowid",
                        column: x => x.prowid,
                        principalTable: "leasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientpropleascontractspacebridges_propertyspaces_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "propertyspaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientpropeleascontractspacebridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<int>(type: "integer", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientpropeleascontractspacebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientpropeleascontractspacebridges_leasecontracts_prowid",
                        column: x => x.prowid,
                        principalTable: "leasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientpropeleascontractspacebridges_propertyspaces_stern~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "propertyspaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientpropertyleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientpropertyleasings", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclientpropertyleasings_leasecontracts_contractid",
                        column: x => x.contractid,
                        principalTable: "leasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientvehicleleasingcompensations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientvehicleleasingcompensations", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclientvehicleleasingcompensations_agreements_agreement~",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientvehicleleasingcompensations_legalclientvehiclele~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "legclientvehsupervcontrolactions",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientvehsupervcontrolactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_legclientvehsupervcontrolactions_legalclientvehicleleasings~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientvehsupervcontrolactions_supervisiongroups_supervis~",
                        column: x => x.supervisiongroupid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
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

            migrationBuilder.CreateTable(
                name: "natclientvehsupervcontrolactions",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientvehsupervcontrolactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_natclientvehsupervcontrolactions_naturalclientvehicleleasin~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientvehsupervcontrolactions_supervisiongroups_supervis~",
                        column: x => x.supervisiongroupid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientvehicleleasingcompensations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientvehicleleasingcompensations", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclientvehicleleasingcompensations_agreements_agreeme~",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientvehicleleasingcompensations_naturalclientvehic~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientpropertyleasingcompensations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientpropertyleasingcompensations", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclientpropertyleasingcompensations_agreements_agreemen~",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientpropertyleasingcompensations_legalclientproperty~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientpropleaspersoncontactbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientpropleaspersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientpropleaspersoncontactbridges_legalclientpropertyle~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientpropleaspersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientpropsupervcontrolactions",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientpropsupervcontrolactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_legclientpropsupervcontrolactions_legalclientpropertyleasin~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientpropsupervcontrolactions_supervisiongroups_supervi~",
                        column: x => x.supervisiongroupid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientpropleaspersoncontactbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientpropleaspersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientpropleaspersoncontactbridges_naturalclientproperty~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientpropleaspersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientpropsupervcontrolactions",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientpropsupervcontrolactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_natclientpropsupervcontrolactions_naturalclientpropertyleas~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientpropsupervcontrolactions_supervisiongroups_supervi~",
                        column: x => x.supervisiongroupid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientpropertyleasingcompensations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientpropertyleasingcompensations", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclientpropertyleasingcompensations_agreements_agreem~",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientpropertyleasingcompensations_naturalclientprop~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientvehleascompdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientvehleascompdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientvehleascompdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientvehleascompdocumentbridges_legalclientvehicleleasi~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasingcompensations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientvehleascompdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientvehleascompdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientvehleascompdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientvehleascompdocumentbridges_naturalclientvehiclelea~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasingcompensations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientpropleascompdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientpropleascompdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientpropleascompdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientpropleascompdocumentbridges_legalclientpropertylea~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientpropertyleasingcompensations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientpropleascompdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientpropleascompdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientpropleascompdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientpropleascompdocumentbridges_naturalclientpropertyl~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientpropertyleasingcompensations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_clientid",
                table: "leasecontracts",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_postulationid",
                table: "leasecontracts",
                column: "postulationid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_propertyid",
                table: "leasecontracts",
                column: "propertyid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientpropertyleasingcompensations_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasingcompensations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientpropertyleasingcompensations_leasingid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasingcompensations",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientpropertyleasings_contractid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasings",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientvehicleleasingcompensations_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasingcompensations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientvehicleleasingcompensations_leasingid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasingcompensations",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientpropleascompdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientpropleascompdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientpropleascontractspacebridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientpropleascontractspacebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientpropleaspersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientpropleaspersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientpropsupervcontrolactions_leasingid",
                schema: "decisorframework_leasing",
                table: "legclientpropsupervcontrolactions",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientpropsupervcontrolactions_supervisiongroupid",
                schema: "decisorframework_leasing",
                table: "legclientpropsupervcontrolactions",
                column: "supervisiongroupid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehleascompdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientvehleascompdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehleaspersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientvehleaspersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehsupervcontrolactions_leasingid",
                schema: "decisorframework_leasing",
                table: "legclientvehsupervcontrolactions",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehsupervcontrolactions_supervisiongroupid",
                schema: "decisorframework_leasing",
                table: "legclientvehsupervcontrolactions",
                column: "supervisiongroupid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientpropeleascontractspacebridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientpropeleascontractspacebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientpropleascompdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientpropleascompdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientpropleaspersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientpropleaspersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientpropsupervcontrolactions_leasingid",
                schema: "decisorframework_leasing",
                table: "natclientpropsupervcontrolactions",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientpropsupervcontrolactions_supervisiongroupid",
                schema: "decisorframework_leasing",
                table: "natclientpropsupervcontrolactions",
                column: "supervisiongroupid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehleascompdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientvehleascompdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehleaspersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientvehleaspersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehsupervcontrolactions_leasingid",
                schema: "decisorframework_leasing",
                table: "natclientvehsupervcontrolactions",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehsupervcontrolactions_supervisiongroupid",
                schema: "decisorframework_leasing",
                table: "natclientvehsupervcontrolactions",
                column: "supervisiongroupid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientpropertyleasingcompensations_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasingcompensations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientpropertyleasingcompensations_leasingid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasingcompensations",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientpropertyleasings_contractid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasings",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientvehicleleasingcompensations_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasingcompensations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientvehicleleasingcompensations_leasingid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasingcompensations",
                column: "leasingid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridges_propleasperso~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleaspersonpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleaseorgpostspacepropousalbridges_propertyspaceleasepro~",
                schema: "decisorframework_leasing",
                table: "propleaseorgpostspacepropousalbridges",
                column: "sternid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyspaceleasepropousals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleaseorgpostspacepropousalbridges_propleasorgpostulatio~",
                schema: "decisorframework_leasing",
                table: "propleaseorgpostspacepropousalbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleasorgpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleasorgpostdocumentbridges_documents_sternid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostdocumentbridges",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleasorgpostdocumentbridges_propleasorgpostulations_prow~",
                schema: "decisorframework_leasing",
                table: "propleasorgpostdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleasorgpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleasorgpostulations_organizationcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleasorgpostulations_propertyleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleaspersonpostulations_naturalbusinesskinds_businesskin~",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleaspersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleaspersonpostulations_propertyleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleasperspostspacepropbridges_propertyspaceleasepropousa~",
                schema: "decisorframework_leasing",
                table: "propleasperspostspacepropbridges",
                column: "sternid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyspaceleasepropousals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleasperspostspacepropbridges_propleaspersonpostulations~",
                schema: "decisorframework_leasing",
                table: "propleasperspostspacepropbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleaspersonpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleasorgpostdocumentbridges_documents_sternid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostdocumentbridges",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleasorgpostdocumentbridges_vehleasorgpostulations_prowid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehleasorgpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleasorgpostulations_organizationcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleasorgpostulations_vehicleleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleaspersonpostdocumentbridges_documents_sternid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostdocumentbridges",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleaspersonpostdocumentbridges_vehleaspersonpostulations_~",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehleaspersonpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleaspersonpostulations_naturalbusinesskinds_businesskind~",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleaspersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleaspersonpostulations_vehicleleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridges_propleasperso~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propleaseorgpostspacepropousalbridges_propertyspaceleasepro~",
                schema: "decisorframework_leasing",
                table: "propleaseorgpostspacepropousalbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propleaseorgpostspacepropousalbridges_propleasorgpostulatio~",
                schema: "decisorframework_leasing",
                table: "propleaseorgpostspacepropousalbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propleasorgpostdocumentbridges_documents_sternid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propleasorgpostdocumentbridges_propleasorgpostulations_prow~",
                schema: "decisorframework_leasing",
                table: "propleasorgpostdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propleasorgpostulations_organizationcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propleasorgpostulations_propertyleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propleaspersonpostulations_naturalbusinesskinds_businesskin~",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propleaspersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propleaspersonpostulations_propertyleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propleasperspostspacepropbridges_propertyspaceleasepropousa~",
                schema: "decisorframework_leasing",
                table: "propleasperspostspacepropbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propleasperspostspacepropbridges_propleaspersonpostulations~",
                schema: "decisorframework_leasing",
                table: "propleasperspostspacepropbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleasorgpostdocumentbridges_documents_sternid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleasorgpostdocumentbridges_vehleasorgpostulations_prowid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleasorgpostulations_organizationcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleasorgpostulations_vehicleleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleaspersonpostdocumentbridges_documents_sternid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleaspersonpostdocumentbridges_vehleaspersonpostulations_~",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleaspersonpostulations_naturalbusinesskinds_businesskind~",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleaspersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleaspersonpostulations_vehicleleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropTable(
                name: "legclientpropleascompdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientpropleascontractspacebridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientpropleaspersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientpropsupervcontrolactions",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientvehleascompdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientvehleaspersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientvehsupervcontrolactions",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientpropeleascontractspacebridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientpropleascompdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientpropleaspersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientpropsupervcontrolactions",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientvehleascompdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientvehleaspersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientvehsupervcontrolactions",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legalclientpropertyleasingcompensations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legalclientvehicleleasingcompensations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "naturalclientpropertyleasingcompensations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "naturalclientvehicleleasingcompensations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legalclientpropertyleasings",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legalclientvehicleleasings",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "naturalclientpropertyleasings",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "naturalclientvehicleleasings",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "leasecontracts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehleaspersonpostulations",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehleaspersonpostdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostdocumentbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehleasorgpostulations",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehleasorgpostdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostdocumentbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propleasperspostspacepropbridges",
                schema: "decisorframework_leasing",
                table: "propleasperspostspacepropbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propleaspersonpostulations",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propleasorgpostulations",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propleasorgpostdocumentbridges",
                schema: "decisorframework_leasing",
                table: "propleasorgpostdocumentbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propleaseorgpostspacepropousalbridges",
                schema: "decisorframework_leasing",
                table: "propleaseorgpostspacepropousalbridges");

            migrationBuilder.RenameTable(
                name: "vehleaspersonpostulations",
                schema: "decisorframework_leasing",
                newName: "vehicleleasepersonpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehleaspersonpostdocumentbridges",
                schema: "decisorframework_leasing",
                newName: "vehicleleasepersonpostulationdocumentbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehleasorgpostulations",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseorganizationpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehleasorgpostdocumentbridges",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseorganizationpostulationdocumentbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propleasperspostspacepropbridges",
                schema: "decisorframework_leasing",
                newName: "propertyleaseperspostulationspacepropousalbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propleaspersonpostulations",
                schema: "decisorframework_leasing",
                newName: "propertyleasepersonpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propleasorgpostulations",
                schema: "decisorframework_leasing",
                newName: "propertyleaseorganizationpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propleasorgpostdocumentbridges",
                schema: "decisorframework_leasing",
                newName: "propertyleaseorganizationpostulationdocumentbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propleaseorgpostspacepropousalbridges",
                schema: "decisorframework_leasing",
                newName: "propertyleaseorgpostulationspacepropousalbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameIndex(
                name: "ix_vehleaspersonpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                newName: "ix_vehicleleasepersonpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_vehleaspersonpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                newName: "ix_vehicleleasepersonpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_vehleaspersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                newName: "ix_vehicleleasepersonpostulations_businesskindid");

            migrationBuilder.RenameIndex(
                name: "ix_vehleaspersonpostdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges",
                newName: "ix_vehicleleasepersonpostulationdocumentbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_vehleasorgpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                newName: "ix_vehicleleaseorganizationpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_vehleasorgpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                newName: "ix_vehicleleaseorganizationpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_vehleasorgpostdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges",
                newName: "ix_vehicleleaseorganizationpostulationdocumentbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_propleasperspostspacepropbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseperspostulationspacepropousalbridges",
                newName: "ix_propertyleaseperspostulationspacepropousalbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_propleaspersonpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                newName: "ix_propertyleasepersonpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_propleaspersonpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                newName: "ix_propertyleasepersonpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_propleaspersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                newName: "ix_propertyleasepersonpostulations_businesskindid");

            migrationBuilder.RenameIndex(
                name: "ix_propleasorgpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                newName: "ix_propertyleaseorganizationpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_propleasorgpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                newName: "ix_propertyleaseorganizationpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_propleasorgpostdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges",
                newName: "ix_propertyleaseorganizationpostulationdocumentbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_propleaseorgpostspacepropousalbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorgpostulationspacepropousalbridges",
                newName: "ix_propertyleaseorgpostulationspacepropousalbridges_sternid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleasepersonpostulations",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseperspostulationspacepropousalbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseperspostulationspacepropousalbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleasepersonpostulations",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseorgpostulationspacepropousalbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseorgpostulationspacepropousalbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.CreateTable(
                name: "propertyleasecontracts",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    propertyid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true),
                    feed = table.Column<double>(type: "double precision", nullable: false),
                    feeddurationunitmeasurekind = table.Column<int>(type: "integer", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasecontracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleasecontracts_properties_propertyid",
                        column: x => x.propertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasecontracts_propertyleaseoffers_offerid",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleasecontract",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicleid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true),
                    feed = table.Column<double>(type: "double precision", nullable: false),
                    feeddurationunitmeasurekind = table.Column<int>(type: "integer", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleasecontract", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicleleasecontract_vehicleleaseoffers_offerid",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasecontract_vehicles_vehicleid",
                        column: x => x.vehicleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleasecontractspacebridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<int>(type: "integer", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasecontractspacebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleasecontractspacebridges_propertyleasecontracts_pr~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasecontractspacebridges_propertyspaces_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "propertyspaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasings", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleasings_propertyleasecontracts_contractid",
                        column: x => x.contractid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    operativelicencecode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleasings", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicleleasings_vehicleleasecontract_contractid",
                        column: x => x.contractid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleasecontract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleasingcompensation",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasingcompensation", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleasingcompensation_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasingcompensation_propertyleasings_leasingid",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleasingpersoncontactbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasingpersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleasingpersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasingpersoncontactbridges_propertyleasings_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertysupervisioncontrolactions",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertysupervisioncontrolactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertysupervisioncontrolactions_propertyleasings_leasingid",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertysupervisioncontrolactions_supervisiongroups_supervi~",
                        column: x => x.supervisiongroupid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleasingcompensations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleasingcompensations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicleleasingcompensations_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasingcompensations_vehicleleasings_leasingid",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleasingpersoncontactbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleasingpersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleleasingpersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasingpersoncontactbridges_vehicleleasings_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehiclesupervisioncontrolactions",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiclesupervisioncontrolactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehiclesupervisioncontrolactions_supervisiongroups_supervis~",
                        column: x => x.supervisiongroupid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehiclesupervisioncontrolactions_vehicleleasings_leasingid",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleasingcompensationdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasingcompensationdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleasingcompensationdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasingcompensationdocumentbridges_propertyleasingc~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasingcompensation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleasingcompensationdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleasingcompensationdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleleasingcompensationdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasingcompensationdocumentbridges_vehicleleasingcom~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleasingcompensations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasecontracts_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleasecontracts",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasecontracts_propertyid",
                schema: "decisorframework_leasing",
                table: "propertyleasecontracts",
                column: "propertyid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasecontractspacebridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleasecontractspacebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasingcompensation_agreementid",
                schema: "decisorframework_leasing",
                table: "propertyleasingcompensation",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasingcompensation_leasingid",
                schema: "decisorframework_leasing",
                table: "propertyleasingcompensation",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasingcompensationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleasingcompensationdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasingpersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleasingpersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasings_contractid",
                schema: "decisorframework_leasing",
                table: "propertyleasings",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "ix_propertysupervisioncontrolactions_leasingid",
                schema: "decisorframework_leasing",
                table: "propertysupervisioncontrolactions",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_propertysupervisioncontrolactions_supervisiongroupid",
                schema: "decisorframework_leasing",
                table: "propertysupervisioncontrolactions",
                column: "supervisiongroupid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasecontract_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleasecontract",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasecontract_vehicleid",
                schema: "decisorframework_leasing",
                table: "vehicleleasecontract",
                column: "vehicleid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasingcompensationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleasingcompensationdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasingcompensations_agreementid",
                schema: "decisorframework_leasing",
                table: "vehicleleasingcompensations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasingcompensations_leasingid",
                schema: "decisorframework_leasing",
                table: "vehicleleasingcompensations",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasingpersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleasingpersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasings_contractid",
                schema: "decisorframework_leasing",
                table: "vehicleleasings",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "ix_vehiclesupervisioncontrolactions_leasingid",
                schema: "decisorframework_leasing",
                table: "vehiclesupervisioncontrolactions",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_vehiclesupervisioncontrolactions_supervisiongroupid",
                schema: "decisorframework_leasing",
                table: "vehiclesupervisioncontrolactions",
                column: "supervisiongroupid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridges_documen~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridges_propert~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseorganizationpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorganizationpostulations_organizationcontacts_~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorganizationpostulations_propertyleaseoffers_o~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorgpostulationspacepropousalbridges_propertyle~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorgpostulationspacepropousalbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseorganizationpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorgpostulationspacepropousalbridges_propertysp~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorgpostulationspacepropousalbridges",
                column: "sternid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyspaceleasepropousals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridges_propertylease~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleasepersonpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulations_naturalbusinesskinds_busine~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulations_propertyleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseperspostulationspacepropousalbridges_propertyl~",
                schema: "decisorframework_leasing",
                table: "propertyleaseperspostulationspacepropousalbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleasepersonpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseperspostulationspacepropousalbridges_propertys~",
                schema: "decisorframework_leasing",
                table: "propertyleaseperspostulationspacepropousalbridges",
                column: "sternid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyspaceleasepropousals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridges_document~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridges_vehiclel~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseorganizationpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseorganizationpostulations_organizationcontacts_c~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseorganizationpostulations_vehicleleaseoffers_off~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridges_documents_ster~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridges_vehicleleasepe~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleasepersonpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulations_naturalbusinesskinds_busines~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulations_vehicleleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
