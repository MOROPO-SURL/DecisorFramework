using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "propertyleasecontracts",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    propertyid = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true),
                    feed = table.Column<double>(type: "double precision", nullable: false),
                    feeddurationunitmeasurekind = table.Column<int>(type: "integer", nullable: false)
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
                name: "supervisiongroups",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    representativeid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supervisiongroups", x => x.id);
                    table.ForeignKey(
                        name: "fk_supervisiongroups_employees_representativeid",
                        column: x => x.representativeid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
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
                    vehicleid = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true),
                    feed = table.Column<double>(type: "double precision", nullable: false),
                    feeddurationunitmeasurekind = table.Column<int>(type: "integer", nullable: false)
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
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    contractid = table.Column<int>(type: "integer", nullable: false)
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
                name: "supervisiongroupemployeebridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supervisiongroupemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_supervisiongroupemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_supervisiongroupemployeebridges_supervisiongroups_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    contractid = table.Column<int>(type: "integer", nullable: false),
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
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
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
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false)
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
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
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
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "ix_supervisiongroupemployeebridges_sternid",
                schema: "decisorframework_leasing",
                table: "supervisiongroupemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_supervisiongroups_representativeid",
                schema: "decisorframework_leasing",
                table: "supervisiongroups",
                column: "representativeid");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "supervisiongroupemployeebridges",
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
                name: "supervisiongroups",
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
        }
    }
}
