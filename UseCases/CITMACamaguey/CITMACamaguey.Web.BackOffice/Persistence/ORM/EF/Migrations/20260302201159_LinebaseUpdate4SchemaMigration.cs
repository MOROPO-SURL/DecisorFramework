using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.CITMACamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LinebaseUpdate4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_decisionmakinggroups_structures_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_employees_responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_resolutions_resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_structures_structureid",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_ocupationcandidates_candidateid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_staffs_structures_structureid",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.DropForeignKey(
                name: "fk_vacantpostulations_schoolings_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vacants_workforceorganizationalunities_workforceorganizatio~",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_structures_structureid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_workforces_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropForeignKey(
                name: "fk_workpositions_schoolings_schoolingid",
                schema: "decisorframework_humanresources",
                table: "workpositions");

            migrationBuilder.DropTable(
                name: "schoolings",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "structureorganizationalunitybridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunities",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "structures",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "organizationalunities",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "structurekinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropIndex(
                name: "ix_workpositions_schoolingid",
                schema: "decisorframework_humanresources",
                table: "workpositions");

            migrationBuilder.DropIndex(
                name: "ix_vacantpostulations_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.DropColumn(
                name: "schoolingid",
                schema: "decisorframework_humanresources",
                table: "workpositions");

            migrationBuilder.DropColumn(
                name: "schoolingcomplement",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.DropColumn(
                name: "schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.RenameColumn(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                newName: "organizationalstructureid");

            migrationBuilder.RenameIndex(
                name: "ix_workforces_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                newName: "ix_workforces_organizationalstructureid");

            migrationBuilder.RenameColumn(
                name: "structureid",
                schema: "decisorframework_domain",
                table: "vehicles",
                newName: "administrativeentityid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicles_structureid",
                schema: "decisorframework_domain",
                table: "vehicles",
                newName: "ix_vehicles_administrativeentityid");

            migrationBuilder.RenameColumn(
                name: "workforceorganizationalunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                newName: "workforceorganizationalunitid");

            migrationBuilder.RenameIndex(
                name: "ix_vacants_workforceorganizationalunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                newName: "ix_vacants_workforceorganizationalunitid");

            migrationBuilder.RenameColumn(
                name: "workingdaycount",
                schema: "decisorframework_humanresources",
                table: "staffs",
                newName: "workingweekhourcount");

            migrationBuilder.RenameColumn(
                name: "structureid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                newName: "administrativeentityid");

            migrationBuilder.RenameIndex(
                name: "ix_staffs_structureid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                newName: "ix_staffs_administrativeentityid");

            migrationBuilder.RenameColumn(
                name: "candidateid",
                table: "resolutions",
                newName: "admitionpropousalid");

            migrationBuilder.RenameIndex(
                name: "ix_resolutions_candidateid",
                table: "resolutions",
                newName: "ix_resolutions_admitionpropousalid");

            migrationBuilder.RenameColumn(
                name: "structureid",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "administrativeentityid");

            migrationBuilder.RenameIndex(
                name: "ix_properties_structureid",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "ix_properties_administrativeentityid");

            migrationBuilder.RenameColumn(
                name: "responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "namingresolutionid");

            migrationBuilder.RenameColumn(
                name: "resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "designationresolutionid");

            migrationBuilder.RenameIndex(
                name: "ix_employmentcontracts_responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "ix_employmentcontracts_namingresolutionid");

            migrationBuilder.RenameIndex(
                name: "ix_employmentcontracts_resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "ix_employmentcontracts_designationresolutionid");

            migrationBuilder.RenameColumn(
                name: "structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                newName: "administrativeentityid");

            migrationBuilder.RenameIndex(
                name: "ix_decisionmakinggroups_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                newName: "ix_decisionmakinggroups_administrativeentityid");

            migrationBuilder.AddColumn<int>(
                name: "educationlevel",
                schema: "decisorframework_humanresources",
                table: "workpositions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "responsabilitycommitment",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "maleparentname",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "femaleparentname",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "alignment",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "educationlevel",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "titulationtitle",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ultimateeducationinstitution",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "doctorateextrafeed",
                schema: "decisorframework_humanresources",
                table: "staffs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "masteryextrafeed",
                schema: "decisorframework_humanresources",
                table: "staffs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "fee",
                schema: "decisorframework_humanresources",
                table: "salarystandards",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "summary",
                table: "resolutions",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "administrativeentitykinds",
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
                    table.PrimaryKey("pk_administrativeentitykinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "changenotifications",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    kind = table.Column<int>(type: "integer", nullable: false),
                    authorid = table.Column<string>(type: "text", nullable: false),
                    changekind = table.Column<int>(type: "integer", nullable: false),
                    entityname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    cached = table.Column<string>(type: "character varying(10240)", maxLength: 10240, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_changenotifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_changenotifications_users_authorid",
                        column: x => x.authorid,
                        principalSchema: "guamaframework_security_personal",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "knowledgeareas",
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
                    table.PrimaryKey("pk_knowledgeareas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organizationalunits",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalunits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "changenotificationuserbridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<string>(type: "text", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    readedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_changenotificationuserbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_changenotificationuserbridges_changenotifications_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "changenotifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_changenotificationuserbridges_users_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_security_personal",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizationalstructuringunits",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    kind = table.Column<int>(type: "integer", nullable: false),
                    organizationalunitid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    reference = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalstructuringunits", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalstructuringunits_organizationalstructuringuni~",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructuringunits",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationalstructuringunits_organizationalunits_organiza~",
                        column: x => x.organizationalunitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizationalstructures",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    rootstructuringunitid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalstructures", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalstructures_organizationalstructuringunits_roo~",
                        column: x => x.rootstructuringunitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructuringunits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunits",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationalstructuringunitid = table.Column<Guid>(type: "uuid", nullable: false),
                    chiefvacantid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunits", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunits_organizationalstructuringunits~",
                        column: x => x.organizationalstructuringunitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructuringunits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunits_vacants_chiefvacantid",
                        column: x => x.chiefvacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunits_workforces_workforceid",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "administrativeentities",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    socialpropertyid = table.Column<Guid>(type: "uuid", nullable: true),
                    organizationalstructureid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_administrativeentities", x => x.id);
                    table.ForeignKey(
                        name: "fk_administrativeentities_administrativeentities_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "administrativeentities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_administrativeentities_administrativeentitykinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "administrativeentitykinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_administrativeentities_organizationalstructures_organizatio~",
                        column: x => x.organizationalstructureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_administrativeentities_organizationidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_administrativeentities_properties_socialpropertyid",
                        column: x => x.socialpropertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_administrativeentities_identityid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "identityid");

            migrationBuilder.CreateIndex(
                name: "ix_administrativeentities_kindid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_administrativeentities_organizationalstructureid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "organizationalstructureid");

            migrationBuilder.CreateIndex(
                name: "ix_administrativeentities_parentid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_administrativeentities_socialpropertyid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "socialpropertyid");

            migrationBuilder.CreateIndex(
                name: "ix_changenotifications_authorid",
                schema: "decisorframework_domain",
                table: "changenotifications",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_changenotificationuserbridges_sternid",
                schema: "decisorframework_domain",
                table: "changenotificationuserbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructures_rootstructuringunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "rootstructuringunitid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructuringunits_organizationalunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunits",
                column: "organizationalunitid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructuringunits_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunits",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunits_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunits",
                column: "chiefvacantid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunits_organizationalstructuringunitid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunits",
                column: "organizationalstructuringunitid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunits_workforceid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunits",
                column: "workforceid");

            migrationBuilder.AddForeignKey(
                name: "fk_decisionmakinggroups_administrativeentities_administrativee~",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                column: "administrativeentityid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_resolutions_designationresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "designationresolutionid",
                principalTable: "resolutions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_resolutions_namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "namingresolutionid",
                principalTable: "resolutions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_properties_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "administrativeentityid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_admitionpropousals_admitionpropousalid",
                table: "resolutions",
                column: "admitionpropousalid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "admitionpropousals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions",
                column: "agreementid",
                principalSchema: "decisorframework_governance",
                principalTable: "agreements",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staffs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_staffs_administrativeentities_administrativeentityid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "administrativeentityid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vacants_workforceorganizationalunits_workforceorganizationa~",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceorganizationalunitid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforceorganizationalunits",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "administrativeentityid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workforces_organizationalstructures_organizationalstructure~",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "organizationalstructureid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalstructures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_decisionmakinggroups_administrativeentities_administrativee~",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_resolutions_designationresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_resolutions_namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_admitionpropousals_admitionpropousalid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_staffs_administrativeentities_administrativeentityid",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.DropForeignKey(
                name: "fk_vacants_workforceorganizationalunits_workforceorganizationa~",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_workforces_organizationalstructures_organizationalstructure~",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropTable(
                name: "administrativeentities",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "changenotificationuserbridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "knowledgeareas",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunits",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "administrativeentitykinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "organizationalstructures",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "changenotifications",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "organizationalstructuringunits",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "organizationalunits",
                schema: "decisorframework_domain");

            migrationBuilder.DropColumn(
                name: "educationlevel",
                schema: "decisorframework_humanresources",
                table: "workpositions");

            migrationBuilder.DropColumn(
                name: "educationlevel",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.DropColumn(
                name: "titulationtitle",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.DropColumn(
                name: "ultimateeducationinstitution",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.DropColumn(
                name: "doctorateextrafeed",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.DropColumn(
                name: "masteryextrafeed",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.RenameColumn(
                name: "organizationalstructureid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                newName: "chiefvacantid");

            migrationBuilder.RenameIndex(
                name: "ix_workforces_organizationalstructureid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                newName: "ix_workforces_chiefvacantid");

            migrationBuilder.RenameColumn(
                name: "administrativeentityid",
                schema: "decisorframework_domain",
                table: "vehicles",
                newName: "structureid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicles_administrativeentityid",
                schema: "decisorframework_domain",
                table: "vehicles",
                newName: "ix_vehicles_structureid");

            migrationBuilder.RenameColumn(
                name: "workforceorganizationalunitid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                newName: "workforceorganizationalunityid");

            migrationBuilder.RenameIndex(
                name: "ix_vacants_workforceorganizationalunitid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                newName: "ix_vacants_workforceorganizationalunityid");

            migrationBuilder.RenameColumn(
                name: "workingweekhourcount",
                schema: "decisorframework_humanresources",
                table: "staffs",
                newName: "workingdaycount");

            migrationBuilder.RenameColumn(
                name: "administrativeentityid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                newName: "structureid");

            migrationBuilder.RenameIndex(
                name: "ix_staffs_administrativeentityid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                newName: "ix_staffs_structureid");

            migrationBuilder.RenameColumn(
                name: "admitionpropousalid",
                table: "resolutions",
                newName: "candidateid");

            migrationBuilder.RenameIndex(
                name: "ix_resolutions_admitionpropousalid",
                table: "resolutions",
                newName: "ix_resolutions_candidateid");

            migrationBuilder.RenameColumn(
                name: "administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "structureid");

            migrationBuilder.RenameIndex(
                name: "ix_properties_administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "ix_properties_structureid");

            migrationBuilder.RenameColumn(
                name: "namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "responsibleid");

            migrationBuilder.RenameColumn(
                name: "designationresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "resolutionid");

            migrationBuilder.RenameIndex(
                name: "ix_employmentcontracts_namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "ix_employmentcontracts_responsibleid");

            migrationBuilder.RenameIndex(
                name: "ix_employmentcontracts_designationresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "ix_employmentcontracts_resolutionid");

            migrationBuilder.RenameColumn(
                name: "administrativeentityid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                newName: "structureid");

            migrationBuilder.RenameIndex(
                name: "ix_decisionmakinggroups_administrativeentityid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                newName: "ix_decisionmakinggroups_structureid");

            migrationBuilder.AddColumn<Guid>(
                name: "schoolingid",
                schema: "decisorframework_humanresources",
                table: "workpositions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "responsabilitycommitment",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "maleparentname",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "femaleparentname",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "alignment",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "schoolingcomplement",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<double>(
                name: "fee",
                schema: "decisorframework_humanresources",
                table: "salarystandards",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "summary",
                table: "resolutions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2048)",
                oldMaxLength: 2048);

            migrationBuilder.CreateTable(
                name: "organizationalunities",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalunities", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalunities_organizationalunities_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "schoolings",
                schema: "decisorframework_humanresources",
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
                    table.PrimaryKey("pk_schoolings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "structurekinds",
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
                    table.PrimaryKey("pk_structurekinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunities",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    chiefvacantid = table.Column<Guid>(type: "uuid", nullable: true),
                    organizationalunityid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunities", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_organizationalunities_organi~",
                        column: x => x.organizationalunityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_vacants_chiefvacantid",
                        column: x => x.chiefvacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_workforceorganizationaluniti~",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforceorganizationalunities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_workforces_workforceid",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "structures",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    socialpropertyid = table.Column<Guid>(type: "uuid", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_structures", x => x.id);
                    table.ForeignKey(
                        name: "fk_structures_organizationidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_structures_properties_socialpropertyid",
                        column: x => x.socialpropertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_structures_structurekinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structurekinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_structures_structures_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "structureorganizationalunitybridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_structureorganizationalunitybridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_structureorganizationalunitybridges_organizationalunities_s~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_structureorganizationalunitybridges_structures_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_workpositions_schoolingid",
                schema: "decisorframework_humanresources",
                table: "workpositions",
                column: "schoolingid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "schoolingid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalunities_parentid",
                schema: "decisorframework_domain",
                table: "organizationalunities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_structureorganizationalunitybridges_sternid",
                schema: "decisorframework_domain",
                table: "structureorganizationalunitybridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_structures_identityid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "identityid");

            migrationBuilder.CreateIndex(
                name: "ix_structures_kindid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_structures_parentid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_structures_socialpropertyid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "socialpropertyid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "chiefvacantid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_organizationalunityid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "organizationalunityid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_parentid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_workforceid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "workforceid");

            migrationBuilder.AddForeignKey(
                name: "fk_decisionmakinggroups_structures_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_employees_responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "responsibleid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_resolutions_resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "resolutionid",
                principalTable: "resolutions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_properties_structures_structureid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions",
                column: "agreementid",
                principalSchema: "decisorframework_governance",
                principalTable: "agreements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_ocupationcandidates_candidateid",
                table: "resolutions",
                column: "candidateid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "ocupationcandidates",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staffs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_staffs_structures_structureid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vacantpostulations_schoolings_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "schoolingid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "schoolings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vacants_workforceorganizationalunities_workforceorganizatio~",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceorganizationalunityid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforceorganizationalunities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_structures_structureid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workforces_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "chiefvacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workpositions_schoolings_schoolingid",
                schema: "decisorframework_humanresources",
                table: "workpositions",
                column: "schoolingid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "schoolings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
