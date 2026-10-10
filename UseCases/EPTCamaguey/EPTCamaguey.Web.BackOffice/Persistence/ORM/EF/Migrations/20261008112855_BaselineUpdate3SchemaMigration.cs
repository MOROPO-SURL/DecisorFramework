using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class BaselineUpdate3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_abstractemploymentcontract_employees_responsibleid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract");

            migrationBuilder.DropForeignKey(
                name: "fk_abstractemploymentcontract_resolutions_resolutionid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract");

            migrationBuilder.DropForeignKey(
                name: "fk_costcenters_structures_structureid",
                schema: "decisorframework_finantial",
                table: "costcenters");

            migrationBuilder.DropForeignKey(
                name: "fk_decisionmakinggroups_structures_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_structures_structureid",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_ocupationcandidate_candidateid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_staff_staffid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_vacant_vacantid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_staff_structures_structureid",
                schema: "decisorframework_humanresources",
                table: "staff");

            migrationBuilder.DropForeignKey(
                name: "fk_vacant_workforceorganizationalunity_workforceorganizational~",
                schema: "decisorframework_humanresources",
                table: "vacant");

            migrationBuilder.DropForeignKey(
                name: "fk_vacantpostulation_schooling_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_structures_structureid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_workforce_vacant_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforce");

            migrationBuilder.DropForeignKey(
                name: "fk_workposition_schooling_schoolingid",
                schema: "decisorframework_humanresources",
                table: "workposition");

            migrationBuilder.DropTable(
                name: "schooling",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "structureorganizationalunitybridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunity",
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
                name: "ix_workposition_schoolingid",
                schema: "decisorframework_humanresources",
                table: "workposition");

            migrationBuilder.DropIndex(
                name: "ix_vacantpostulation_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation");

            migrationBuilder.DropColumn(
                name: "schoolingid",
                schema: "decisorframework_humanresources",
                table: "workposition");

            migrationBuilder.DropColumn(
                name: "schoolingcomplement",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation");

            migrationBuilder.DropColumn(
                name: "schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation");

            migrationBuilder.RenameColumn(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforce",
                newName: "organizationalstructureid");

            migrationBuilder.RenameIndex(
                name: "ix_workforce_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforce",
                newName: "ix_workforce_organizationalstructureid");

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
                table: "vacant",
                newName: "workforceorganizationalunitid");

            migrationBuilder.RenameIndex(
                name: "ix_vacant_workforceorganizationalunityid",
                schema: "decisorframework_humanresources",
                table: "vacant",
                newName: "ix_vacant_workforceorganizationalunitid");

            migrationBuilder.RenameColumn(
                name: "workingdaycount",
                schema: "decisorframework_humanresources",
                table: "staff",
                newName: "workingweekhourcount");

            migrationBuilder.RenameColumn(
                name: "structureid",
                schema: "decisorframework_humanresources",
                table: "staff",
                newName: "administrativeentityid");

            migrationBuilder.RenameIndex(
                name: "ix_staff_structureid",
                schema: "decisorframework_humanresources",
                table: "staff",
                newName: "ix_staff_administrativeentityid");

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
                name: "structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                newName: "administrativeentityid");

            migrationBuilder.RenameIndex(
                name: "ix_decisionmakinggroups_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                newName: "ix_decisionmakinggroups_administrativeentityid");

            migrationBuilder.RenameColumn(
                name: "responsibleid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                newName: "namingresolutionid");

            migrationBuilder.RenameColumn(
                name: "resolutionid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                newName: "designationresolutionid");

            migrationBuilder.RenameIndex(
                name: "ix_abstractemploymentcontract_responsibleid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                newName: "ix_abstractemploymentcontract_namingresolutionid");

            migrationBuilder.RenameIndex(
                name: "ix_abstractemploymentcontract_resolutionid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                newName: "ix_abstractemploymentcontract_designationresolutionid");

            migrationBuilder.AddColumn<int>(
                name: "educationlevel",
                schema: "decisorframework_humanresources",
                table: "workposition",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "responsabilitycommitment",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "maleparentname",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "femaleparentname",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "alignment",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "educationlevel",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "titulationtitle",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ultimateeducationinstitution",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "doctorateextrafeed",
                schema: "decisorframework_humanresources",
                table: "staff",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "masteryextrafeed",
                schema: "decisorframework_humanresources",
                table: "staff",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "fee",
                schema: "decisorframework_humanresources",
                table: "salarystandard",
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
                name: "academicachievements",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    academiclevel = table.Column<int>(type: "integer", nullable: false),
                    mainknowledgeareaid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    institution = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academicachievements", x => x.id);
                    table.ForeignKey(
                        name: "fk_academicachievements_knowledgeareas_mainknowledgeareaid",
                        column: x => x.mainknowledgeareaid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academicachievements_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
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
                name: "academicachievementknowledgeareabridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academicachievementknowledgeareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_academicachievementknowledgeareabridges_academicachievement~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "academicachievements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academicachievementknowledgeareabridges_knowledgeareas_ster~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
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
                name: "workforceorganizationalunit",
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
                    table.PrimaryKey("pk_workforceorganizationalunit", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunit_organizationalstructuringunits_~",
                        column: x => x.organizationalstructuringunitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructuringunits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunit_vacant_chiefvacantid",
                        column: x => x.chiefvacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacant",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunit_workforce_workforceid",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforce",
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
                name: "ix_academicachievementknowledgeareabridges_sternid",
                schema: "decisorframework_domain",
                table: "academicachievementknowledgeareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_academicachievements_contactid",
                schema: "decisorframework_domain",
                table: "academicachievements",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_academicachievements_mainknowledgeareaid",
                schema: "decisorframework_domain",
                table: "academicachievements",
                column: "mainknowledgeareaid");

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
                name: "ix_workforceorganizationalunit_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunit",
                column: "chiefvacantid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunit_organizationalstructuringunitid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunit",
                column: "organizationalstructuringunitid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunit_workforceid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunit",
                column: "workforceid");

            migrationBuilder.AddForeignKey(
                name: "fk_abstractemploymentcontract_resolutions_designationresolutio~",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                column: "designationresolutionid",
                principalTable: "resolutions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_abstractemploymentcontract_resolutions_namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                column: "namingresolutionid",
                principalTable: "resolutions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_costcenters_administrativeentities_structureid",
                schema: "decisorframework_finantial",
                table: "costcenters",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "fk_properties_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "administrativeentityid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_admitionpropousal_admitionpropousalid",
                table: "resolutions",
                column: "admitionpropousalid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "admitionpropousal",
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
                name: "fk_resolutions_staff_staffid",
                table: "resolutions",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staff",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_vacant_vacantid",
                table: "resolutions",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_staff_administrativeentities_administrativeentityid",
                schema: "decisorframework_humanresources",
                table: "staff",
                column: "administrativeentityid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vacant_workforceorganizationalunit_workforceorganizationalu~",
                schema: "decisorframework_humanresources",
                table: "vacant",
                column: "workforceorganizationalunitid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforceorganizationalunit",
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
                name: "fk_workforce_organizationalstructures_organizationalstructureid",
                schema: "decisorframework_humanresources",
                table: "workforce",
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
                name: "fk_abstractemploymentcontract_resolutions_designationresolutio~",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract");

            migrationBuilder.DropForeignKey(
                name: "fk_abstractemploymentcontract_resolutions_namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract");

            migrationBuilder.DropForeignKey(
                name: "fk_costcenters_administrativeentities_structureid",
                schema: "decisorframework_finantial",
                table: "costcenters");

            migrationBuilder.DropForeignKey(
                name: "fk_decisionmakinggroups_administrativeentities_administrativee~",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_admitionpropousal_admitionpropousalid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_staff_staffid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_vacant_vacantid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_staff_administrativeentities_administrativeentityid",
                schema: "decisorframework_humanresources",
                table: "staff");

            migrationBuilder.DropForeignKey(
                name: "fk_vacant_workforceorganizationalunit_workforceorganizationalu~",
                schema: "decisorframework_humanresources",
                table: "vacant");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_workforce_organizationalstructures_organizationalstructureid",
                schema: "decisorframework_humanresources",
                table: "workforce");

            migrationBuilder.DropTable(
                name: "academicachievementknowledgeareabridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "administrativeentities",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "changenotificationuserbridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunit",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "academicachievements",
                schema: "decisorframework_domain");

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
                name: "knowledgeareas",
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
                table: "workposition");

            migrationBuilder.DropColumn(
                name: "educationlevel",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation");

            migrationBuilder.DropColumn(
                name: "titulationtitle",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation");

            migrationBuilder.DropColumn(
                name: "ultimateeducationinstitution",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation");

            migrationBuilder.DropColumn(
                name: "doctorateextrafeed",
                schema: "decisorframework_humanresources",
                table: "staff");

            migrationBuilder.DropColumn(
                name: "masteryextrafeed",
                schema: "decisorframework_humanresources",
                table: "staff");

            migrationBuilder.RenameColumn(
                name: "organizationalstructureid",
                schema: "decisorframework_humanresources",
                table: "workforce",
                newName: "chiefvacantid");

            migrationBuilder.RenameIndex(
                name: "ix_workforce_organizationalstructureid",
                schema: "decisorframework_humanresources",
                table: "workforce",
                newName: "ix_workforce_chiefvacantid");

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
                table: "vacant",
                newName: "workforceorganizationalunityid");

            migrationBuilder.RenameIndex(
                name: "ix_vacant_workforceorganizationalunitid",
                schema: "decisorframework_humanresources",
                table: "vacant",
                newName: "ix_vacant_workforceorganizationalunityid");

            migrationBuilder.RenameColumn(
                name: "workingweekhourcount",
                schema: "decisorframework_humanresources",
                table: "staff",
                newName: "workingdaycount");

            migrationBuilder.RenameColumn(
                name: "administrativeentityid",
                schema: "decisorframework_humanresources",
                table: "staff",
                newName: "structureid");

            migrationBuilder.RenameIndex(
                name: "ix_staff_administrativeentityid",
                schema: "decisorframework_humanresources",
                table: "staff",
                newName: "ix_staff_structureid");

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
                name: "administrativeentityid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                newName: "structureid");

            migrationBuilder.RenameIndex(
                name: "ix_decisionmakinggroups_administrativeentityid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                newName: "ix_decisionmakinggroups_structureid");

            migrationBuilder.RenameColumn(
                name: "namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                newName: "responsibleid");

            migrationBuilder.RenameColumn(
                name: "designationresolutionid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                newName: "resolutionid");

            migrationBuilder.RenameIndex(
                name: "ix_abstractemploymentcontract_namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                newName: "ix_abstractemploymentcontract_responsibleid");

            migrationBuilder.RenameIndex(
                name: "ix_abstractemploymentcontract_designationresolutionid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                newName: "ix_abstractemploymentcontract_resolutionid");

            migrationBuilder.AddColumn<Guid>(
                name: "schoolingid",
                schema: "decisorframework_humanresources",
                table: "workposition",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "responsabilitycommitment",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<string>(
                name: "maleparentname",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "femaleparentname",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "alignment",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "schoolingcomplement",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<double>(
                name: "fee",
                schema: "decisorframework_humanresources",
                table: "salarystandard",
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
                name: "schooling",
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
                    table.PrimaryKey("pk_schooling", x => x.id);
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
                name: "workforceorganizationalunity",
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
                    table.PrimaryKey("pk_workforceorganizationalunity", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunity_organizationalunities_organiza~",
                        column: x => x.organizationalunityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunity_vacant_chiefvacantid",
                        column: x => x.chiefvacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacant",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunity_workforce_workforceid",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforce",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunity_workforceorganizationalunity_p~",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforceorganizationalunity",
                        principalColumn: "id");
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
                name: "ix_workposition_schoolingid",
                schema: "decisorframework_humanresources",
                table: "workposition",
                column: "schoolingid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulation_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
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
                name: "ix_workforceorganizationalunity_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunity",
                column: "chiefvacantid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunity_organizationalunityid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunity",
                column: "organizationalunityid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunity_parentid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunity",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunity_workforceid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunity",
                column: "workforceid");

            migrationBuilder.AddForeignKey(
                name: "fk_abstractemploymentcontract_employees_responsibleid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                column: "responsibleid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_abstractemploymentcontract_resolutions_resolutionid",
                schema: "decisorframework_humanresources",
                table: "abstractemploymentcontract",
                column: "resolutionid",
                principalTable: "resolutions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_costcenters_structures_structureid",
                schema: "decisorframework_finantial",
                table: "costcenters",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "fk_resolutions_ocupationcandidate_candidateid",
                table: "resolutions",
                column: "candidateid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "ocupationcandidate",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_staff_staffid",
                table: "resolutions",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staff",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_vacant_vacantid",
                table: "resolutions",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacant",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_staff_structures_structureid",
                schema: "decisorframework_humanresources",
                table: "staff",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
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
                name: "fk_vacantpostulation_schooling_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulation",
                column: "schoolingid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "schooling",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "fk_workforce_vacant_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforce",
                column: "chiefvacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workposition_schooling_schoolingid",
                schema: "decisorframework_humanresources",
                table: "workposition",
                column: "schoolingid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "schooling",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
