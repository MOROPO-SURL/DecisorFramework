using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class Update1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_idi");

            migrationBuilder.CreateTable(
                name: "awardkinds",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_awardkinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "financiers",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financiers", x => x.id);
                    table.ForeignKey(
                        name: "fk_financiers_organizationcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "newtechniqueresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    resultingtechniqueid = table.Column<Guid>(type: "uuid", nullable: false),
                    predecessortechniqueid = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_newtechniqueresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_newtechniqueresults_techniques_predecessortechniqueid",
                        column: x => x.predecessortechniqueid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_newtechniqueresults_techniques_resultingtechniqueid",
                        column: x => x.resultingtechniqueid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participatingorganizations",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participatingorganizations", x => x.id);
                    table.ForeignKey(
                        name: "fk_participatingorganizations_organizationcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "programs",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_programs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projectcategories",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_projectcategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projectproposals",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectproposals", x => x.id);
                    table.ForeignKey(
                        name: "fk_projectproposals_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectreports",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectreports", x => x.id);
                    table.ForeignKey(
                        name: "fk_projectreports_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "researchareas",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_researchareas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "researchercategories",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_researchercategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scientifictechnicalresultkinds",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_scientifictechnicalresultkinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "thesisresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thesisresults", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trainingresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingresults", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "awardresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_awardresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_awardresults_awardkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "awardkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "programexpectresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    programid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_programexpectresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_programexpectresults_programs_programid",
                        column: x => x.programid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "programs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oppositionreports",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    reportid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_oppositionreports", x => x.id);
                    table.ForeignKey(
                        name: "fk_oppositionreports_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_oppositionreports_projectreports_reportid",
                        column: x => x.reportid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projectreports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "researchers",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: true),
                    teachingcategoryid = table.Column<Guid>(type: "uuid", nullable: true),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: true),
                    participatingorganizationid = table.Column<Guid>(type: "uuid", nullable: true),
                    employeeid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_researchers", x => x.id);
                    table.ForeignKey(
                        name: "fk_researchers_employees_employeeid",
                        column: x => x.employeeid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_researchers_participatingorganizations_participatingorganiz~",
                        column: x => x.participatingorganizationid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "participatingorganizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_researchers_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_researchers_researchercategories_categoryid",
                        column: x => x.categoryid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchercategories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "scientifictechnicalresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    registrationcode = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scientifictechnicalresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_scientifictechnicalresults_scientifictechnicalresultkinds_k~",
                        column: x => x.kindid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "scientifictechnicalresultkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false),
                    summary = table.Column<string>(type: "text", nullable: false),
                    problem = table.Column<string>(type: "text", nullable: false),
                    context = table.Column<string>(type: "text", nullable: false),
                    beneficiary = table.Column<string>(type: "text", nullable: false),
                    mainobjetive = table.Column<string>(type: "text", nullable: false),
                    programid = table.Column<Guid>(type: "uuid", nullable: true),
                    proposalid = table.Column<Guid>(type: "uuid", nullable: false),
                    chiefid = table.Column<Guid>(type: "uuid", nullable: false),
                    predecessorid = table.Column<Guid>(type: "uuid", nullable: true),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projects", x => x.id);
                    table.ForeignKey(
                        name: "fk_projects_programs_programid",
                        column: x => x.programid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "programs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_projects_projectcategories_categoryid",
                        column: x => x.categoryid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projectcategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projects_projectproposals_proposalid",
                        column: x => x.proposalid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projectproposals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projects_projects_predecessorid",
                        column: x => x.predecessorid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_projects_researchers_chiefid",
                        column: x => x.chiefid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "publicationresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    mainauthorid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publicationresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_publicationresults_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_publicationresults_researchers_mainauthorid",
                        column: x => x.mainauthorid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "researcherresearchareadoctoratebridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_researcherresearchareadoctoratebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_researcherresearchareadoctoratebridges_researchareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_researcherresearchareadoctoratebridges_researchers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "researcherresearchareamasterybridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_researcherresearchareamasterybridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_researcherresearchareamasterybridges_researchareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_researcherresearchareamasterybridges_researchers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "researcherresearchareaspecializationbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_researcherresearchareaspecializationbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_researcherresearchareaspecializationbridges_researchareas_s~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_researcherresearchareaspecializationbridges_researchers_pro~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thesisresultresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thesisresultresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_thesisresultresearcherbridges_researchers_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_thesisresultresearcherbridges_thesisresults_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "thesisresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingresultresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingresultresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingresultresearcherbridges_researchers_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingresultresearcherbridges_trainingresults_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "trainingresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scientifictechnicalresultintroductions",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    scenery = table.Column<string>(type: "text", nullable: false),
                    resultid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scientifictechnicalresultintroductions", x => x.id);
                    table.ForeignKey(
                        name: "fk_scientifictechnicalresultintroductions_scientifictechnicalr~",
                        column: x => x.resultid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "scientifictechnicalresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "extensions",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    projectid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_extensions", x => x.id);
                    table.ForeignKey(
                        name: "fk_extensions_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectbudgetcurrencybridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectbudgetcurrencybridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_projectbudgetcurrencybridges_currencies_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectbudgetcurrencybridges_projects_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectbudgetfunancings",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    financierid = table.Column<Guid>(type: "uuid", nullable: false),
                    currencyid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    projectid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectbudgetfunancings", x => x.id);
                    table.ForeignKey(
                        name: "fk_projectbudgetfunancings_currencies_financierid",
                        column: x => x.financierid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectbudgetfunancings_financiers_financierid",
                        column: x => x.financierid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectbudgetfunancings_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "projectparticipatingorganizationbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectparticipatingorganizationbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_projectparticipatingorganizationbridges_participatingorgani~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "participatingorganizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectparticipatingorganizationbridges_projects_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_projectresearcherbridges_projects_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectresearcherbridges_researchers_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectspecificobjectives",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    projectid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectspecificobjectives", x => x.id);
                    table.ForeignKey(
                        name: "fk_projectspecificobjectives_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "publicationresultresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publicationresultresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_publicationresultresearcherbridges_publicationresults_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "publicationresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_publicationresultresearcherbridges_researchers_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_awardresults_kindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_extensions_projectid",
                schema: "decisoriscamaguey_idi",
                table: "extensions",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_financiers_contactid",
                schema: "decisoriscamaguey_idi",
                table: "financiers",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_newtechniqueresults_predecessortechniqueid",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults",
                column: "predecessortechniqueid");

            migrationBuilder.CreateIndex(
                name: "ix_newtechniqueresults_resultingtechniqueid",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults",
                column: "resultingtechniqueid");

            migrationBuilder.CreateIndex(
                name: "ix_oppositionreports_documentid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_oppositionreports_reportid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports",
                column: "reportid");

            migrationBuilder.CreateIndex(
                name: "ix_participatingorganizations_contactid",
                schema: "decisoriscamaguey_idi",
                table: "participatingorganizations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_programexpectresults_programid",
                schema: "decisoriscamaguey_idi",
                table: "programexpectresults",
                column: "programid");

            migrationBuilder.CreateIndex(
                name: "ix_projectbudgetcurrencybridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetcurrencybridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_projectbudgetfunancings_financierid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                column: "financierid");

            migrationBuilder.CreateIndex(
                name: "ix_projectbudgetfunancings_projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_projectparticipatingorganizationbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectparticipatingorganizationbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_projectproposals_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_projectreports_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectreports",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_projectresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "chiefid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_predecessorid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "predecessorid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_programid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "programid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_proposalid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "proposalid");

            migrationBuilder.CreateIndex(
                name: "ix_projectspecificobjectives_projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectspecificobjectives",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_publicationresultresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresultresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_publicationresults_documentid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_publicationresults_mainauthorid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                column: "mainauthorid");

            migrationBuilder.CreateIndex(
                name: "ix_researcherresearchareadoctoratebridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "researcherresearchareadoctoratebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_researcherresearchareamasterybridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "researcherresearchareamasterybridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_researcherresearchareaspecializationbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "researcherresearchareaspecializationbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_researchers_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_researchers_contactid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_researchers_employeeid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_researchers_participatingorganizationid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "participatingorganizationid");

            migrationBuilder.CreateIndex(
                name: "ix_scientifictechnicalresultintroductions_resultid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresultintroductions",
                column: "resultid");

            migrationBuilder.CreateIndex(
                name: "ix_scientifictechnicalresults_kindid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_thesisresultresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresultresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingresultresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresultresearcherbridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "awardresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "extensions",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "newtechniqueresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "oppositionreports",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "programexpectresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectbudgetcurrencybridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectbudgetfunancings",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectparticipatingorganizationbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectspecificobjectives",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "publicationresultresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "researcherresearchareadoctoratebridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "researcherresearchareamasterybridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "researcherresearchareaspecializationbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "scientifictechnicalresultintroductions",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "thesisresultresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "trainingresultresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "awardkinds",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectreports",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "financiers",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projects",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "publicationresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "researchareas",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "scientifictechnicalresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "thesisresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "trainingresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "programs",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectcategories",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectproposals",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "researchers",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "scientifictechnicalresultkinds",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "participatingorganizations",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "researchercategories",
                schema: "decisoriscamaguey_idi");
        }
    }
}
