using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class Update2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projectreports_documents_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectreports");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservicereports_employees_employeeid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_sampleanalysisservicereports_sampleanalysisre~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_sampleanalysisreportid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "sampleanalysisreportid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicereports");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_lab");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_reporting");

            migrationBuilder.RenameTable(
                name: "sampleanalysisservicereports",
                schema: "decisoriscamaguey_servicing",
                newName: "sampleanalysisservicereports",
                newSchema: "decisoriscamaguey_reporting");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                newName: "sampleanalysisreportid");

            migrationBuilder.RenameIndex(
                name: "ix_sampleanalysisservicereports_employeeid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                newName: "ix_sampleanalysisservicereports_sampleanalysisreportid");

            migrationBuilder.AlterColumn<Guid>(
                name: "documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectreports",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "authorid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "at",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "authorid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "documentid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "orderid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "samplekinds",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_samplekinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workinggroups",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    chiefid = table.Column<Guid>(type: "uuid", nullable: false),
                    qualityspecialistid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workinggroups", x => x.id);
                    table.ForeignKey(
                        name: "fk_workinggroups_employees_chiefid",
                        column: x => x.chiefid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workinggroups_employees_qualityspecialistid",
                        column: x => x.qualityspecialistid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workplans",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workplans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "samples",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reference = table.Column<string>(type: "text", nullable: false),
                    observation = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    defaultsamplekindid = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    projectid = table.Column<Guid>(type: "uuid", nullable: true),
                    researcherid = table.Column<Guid>(type: "uuid", nullable: true),
                    serviceorderid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_samples", x => x.id);
                    table.ForeignKey(
                        name: "fk_samples_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_samples_researchers_researcherid",
                        column: x => x.researcherid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_samples_samplekinds_defaultsamplekindid",
                        column: x => x.defaultsamplekindid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samplekinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_samples_serviceorders_serviceorderid",
                        column: x => x.serviceorderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workinggroupemployeebridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workinggroupemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workinggroupemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workinggroupemployeebridges_workinggroups_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workinggrouptechniquebridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workinggrouptechniquebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workinggrouptechniquebridges_techniques_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workinggrouptechniquebridges_workinggroups_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analysisorders",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    workplanid = table.Column<Guid>(type: "uuid", nullable: true),
                    sampleid = table.Column<int>(type: "integer", nullable: false),
                    techniqueid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_analysisorders", x => x.id);
                    table.ForeignKey(
                        name: "fk_analysisorders_samples_sampleid",
                        column: x => x.sampleid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analysisorders_techniques_techniqueid",
                        column: x => x.techniqueid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analysisorders_workplans_workplanid",
                        column: x => x.workplanid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workplans",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "analysises",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    orderid = table.Column<Guid>(type: "uuid", nullable: false),
                    techniqueid = table.Column<Guid>(type: "uuid", nullable: false),
                    predecessorid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_analysises", x => x.id);
                    table.ForeignKey(
                        name: "fk_analysises_analysises_predecessorid",
                        column: x => x.predecessorid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "analysises",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_analysises_analysisorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "analysisorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analysises_techniques_techniqueid",
                        column: x => x.techniqueid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessments",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    targetid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assessments", x => x.id);
                    table.ForeignKey(
                        name: "fk_assessments_analysises_targetid",
                        column: x => x.targetid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "analysises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sampleanalysisreports",
                schema: "decisoriscamaguey_reporting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    analysisid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisreports", x => x.id);
                    table.ForeignKey(
                        name: "fk_sampleanalysisreports_analysises_analysisid",
                        column: x => x.analysisid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "analysises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisreports_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_sampleanalysisreports_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_oppositionreports_authorid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicereports_authorid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicereports_documentid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicereports_orderid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_analysises_orderid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_analysises_predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "predecessorid");

            migrationBuilder.CreateIndex(
                name: "ix_analysises_techniqueid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "techniqueid");

            migrationBuilder.CreateIndex(
                name: "ix_analysisorders_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysisorders",
                column: "sampleid");

            migrationBuilder.CreateIndex(
                name: "ix_analysisorders_techniqueid",
                schema: "decisoriscamaguey_lab",
                table: "analysisorders",
                column: "techniqueid");

            migrationBuilder.CreateIndex(
                name: "ix_analysisorders_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysisorders",
                column: "workplanid");

            migrationBuilder.CreateIndex(
                name: "ix_assessments_targetid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "targetid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisreports_analysisid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisreports",
                column: "analysisid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisreports_authorid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisreports",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisreports_documentid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisreports",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_defaultsamplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "defaultsamplekindid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_projectid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_researcherid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "researcherid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_serviceorderid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "serviceorderid");

            migrationBuilder.CreateIndex(
                name: "ix_workinggroupemployeebridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "workinggroupemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_workinggroups_chiefid",
                schema: "decisoriscamaguey_lab",
                table: "workinggroups",
                column: "chiefid");

            migrationBuilder.CreateIndex(
                name: "ix_workinggroups_qualityspecialistid",
                schema: "decisoriscamaguey_lab",
                table: "workinggroups",
                column: "qualityspecialistid");

            migrationBuilder.CreateIndex(
                name: "ix_workinggrouptechniquebridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "workinggrouptechniquebridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_oppositionreports_personcontacts_authorid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_projectreports_documents_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectreports",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservicereports_documents_documentid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservicereports_employees_authorid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservicereports_sampleanalysisreports_samplean~",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "sampleanalysisreportid",
                principalSchema: "decisoriscamaguey_reporting",
                principalTable: "sampleanalysisreports",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservicereports_serviceorders_orderid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "orderid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "serviceorders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_oppositionreports_personcontacts_authorid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports");

            migrationBuilder.DropForeignKey(
                name: "fk_projectreports_documents_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectreports");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservicereports_documents_documentid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservicereports_employees_authorid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservicereports_sampleanalysisreports_samplean~",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservicereports_serviceorders_orderid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropTable(
                name: "assessments",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "sampleanalysisreports",
                schema: "decisoriscamaguey_reporting");

            migrationBuilder.DropTable(
                name: "workinggroupemployeebridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workinggrouptechniquebridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "analysises",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workinggroups",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "analysisorders",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "samples",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workplans",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "samplekinds",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropIndex(
                name: "ix_oppositionreports_authorid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports");

            migrationBuilder.DropIndex(
                name: "ix_sampleanalysisservicereports_authorid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropIndex(
                name: "ix_sampleanalysisservicereports_documentid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropIndex(
                name: "ix_sampleanalysisservicereports_orderid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropColumn(
                name: "authorid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports");

            migrationBuilder.DropColumn(
                name: "at",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropColumn(
                name: "authorid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropColumn(
                name: "documentid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.DropColumn(
                name: "orderid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports");

            migrationBuilder.RenameTable(
                name: "sampleanalysisservicereports",
                schema: "decisoriscamaguey_reporting",
                newName: "sampleanalysisservicereports",
                newSchema: "decisoriscamaguey_servicing");

            migrationBuilder.RenameColumn(
                name: "sampleanalysisreportid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicereports",
                newName: "employeeid");

            migrationBuilder.RenameIndex(
                name: "ix_sampleanalysisservicereports_sampleanalysisreportid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicereports",
                newName: "ix_sampleanalysisservicereports_employeeid");

            migrationBuilder.AddColumn<Guid>(
                name: "sampleanalysisreportid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectreports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicereports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicereports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_sampleanalysisreportid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysisreportid");

            migrationBuilder.AddForeignKey(
                name: "fk_projectreports_documents_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectreports",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservicereports_employees_employeeid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicereports",
                column: "employeeid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_sampleanalysisservicereports_sampleanalysisre~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysisreportid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "sampleanalysisservicereports",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
