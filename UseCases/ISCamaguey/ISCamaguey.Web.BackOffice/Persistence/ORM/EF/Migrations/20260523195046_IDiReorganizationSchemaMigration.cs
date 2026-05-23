using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IDiReorganizationSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projects_researchers_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "fk_publicationresults_researchers_mainauthorid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults");

            migrationBuilder.DropForeignKey(
                name: "fk_researchers_employees_employeeid",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropForeignKey(
                name: "fk_researchers_participatingorganizations_participatingorganiz~",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropForeignKey(
                name: "fk_researchers_personcontacts_contactid",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropForeignKey(
                name: "fk_researchers_researchercategories_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropForeignKey(
                name: "fk_researchers_teachingcategories_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropForeignKey(
                name: "fk_samples_researchers_researcherid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropTable(
                name: "callforproposalresearchareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "financierresearchareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "participatingorganizationresearchareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectresearcherbridges",
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
                name: "thesisresultresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "trainingresultresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "researchareas",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropIndex(
                name: "ix_samples_researcherid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropIndex(
                name: "ix_publicationresults_mainauthorid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults");

            migrationBuilder.DropPrimaryKey(
                name: "pk_researchers",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropIndex(
                name: "ix_researchers_contactid",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropIndex(
                name: "ix_researchers_participatingorganizationid",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropColumn(
                name: "mainauthorid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults");

            migrationBuilder.DropColumn(
                name: "contactid",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropColumn(
                name: "discriminator",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropColumn(
                name: "participatingorganizationid",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.DropColumn(
                name: "salary",
                schema: "decisoriscamaguey_idi",
                table: "researchers");

            migrationBuilder.RenameTable(
                name: "researchers",
                schema: "decisoriscamaguey_idi",
                newName: "internalresearchers",
                newSchema: "decisoriscamaguey_idi");

            migrationBuilder.RenameIndex(
                name: "ix_researchers_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                newName: "ix_internalresearchers_teachingcategoryid");

            migrationBuilder.RenameIndex(
                name: "ix_researchers_employeeid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                newName: "ix_internalresearchers_employeeid");

            migrationBuilder.RenameIndex(
                name: "ix_researchers_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                newName: "ix_internalresearchers_categoryid");

            migrationBuilder.AlterColumn<Guid>(
                name: "employeeid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_internalresearchers",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                column: "id");

            migrationBuilder.CreateTable(
                name: "callforproposalknowledgeareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforproposalknowledgeareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_callforproposalknowledgeareabridges_callforproposals_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforproposals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_callforproposalknowledgeareabridges_knowledgeareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "externalresearchers",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    participatingorganizationid = table.Column<Guid>(type: "uuid", nullable: false),
                    salary = table.Column<decimal>(type: "numeric", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: true),
                    teachingcategoryid = table.Column<Guid>(type: "uuid", nullable: true),
                    timeavailability = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_externalresearchers", x => x.id);
                    table.ForeignKey(
                        name: "fk_externalresearchers_participatingorganizations_participatin~",
                        column: x => x.participatingorganizationid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "participatingorganizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_externalresearchers_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_externalresearchers_researchercategories_categoryid",
                        column: x => x.categoryid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchercategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_externalresearchers_teachingcategories_teachingcategoryid",
                        column: x => x.teachingcategoryid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "teachingcategories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "financierknowledgeareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financierknowledgeareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_financierknowledgeareabridges_financiers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_financierknowledgeareabridges_knowledgeareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participatingorganizationknowledgeareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participatingorganizationknowledgeareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_participatingorganizationknowledgeareabridges_knowledgearea~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_participatingorganizationknowledgeareabridges_participating~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "participatingorganizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectinternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    timeavailability = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectinternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_projectinternalresearcherbridges_internalresearchers_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectinternalresearcherbridges_projects_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "publicationresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    isprincipalauthor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publicationresultinternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_publicationresultinternalresearcherbridges_internalresearch~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_publicationresultinternalresearcherbridges_publicationresul~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "publicationresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thesisresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    isprincipalauthor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thesisresultinternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_thesisresultinternalresearcherbridges_internalresearchers_s~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_thesisresultinternalresearcherbridges_thesisresults_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "thesisresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingresultinternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingresultinternalresearcherbridges_internalresearchers~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingresultinternalresearcherbridges_trainingresults_pro~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "trainingresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectexternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    timeavailability = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectexternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_projectexternalresearcherbridges_externalresearchers_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "externalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectexternalresearcherbridges_projects_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "publicationresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    isprincipalauthor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publicationresultexternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_publicationresultexternalresearcherbridges_externalresearch~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "externalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_publicationresultexternalresearcherbridges_publicationresul~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "publicationresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thesisresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    isprincipalauthor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thesisresultexternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_thesisresultexternalresearcherbridges_externalresearchers_s~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "externalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_thesisresultexternalresearcherbridges_thesisresults_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "thesisresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingresultexternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingresultexternalresearcherbridges_externalresearchers~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "externalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingresultexternalresearcherbridges_trainingresults_pro~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "trainingresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_callforproposalknowledgeareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "callforproposalknowledgeareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearchers_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearchers",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearchers_contactid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearchers",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearchers_participatingorganizationid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearchers",
                column: "participatingorganizationid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearchers_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearchers",
                column: "teachingcategoryid");

            migrationBuilder.CreateIndex(
                name: "ix_financierknowledgeareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "financierknowledgeareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_participatingorganizationknowledgeareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "participatingorganizationknowledgeareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_projectexternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectexternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_projectinternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectinternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_publicationresultexternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresultexternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_publicationresultinternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresultinternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_thesisresultexternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresultexternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_thesisresultinternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresultinternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingresultexternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresultexternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingresultinternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresultinternalresearcherbridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_internalresearchers_employees_employeeid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                column: "employeeid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_internalresearchers_researchercategories_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                column: "categoryid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "researchercategories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_internalresearchers_teachingcategories_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                column: "teachingcategoryid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "teachingcategories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_projects_internalresearchers_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "chiefid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "internalresearchers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_internalresearchers_employees_employeeid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers");

            migrationBuilder.DropForeignKey(
                name: "fk_internalresearchers_researchercategories_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers");

            migrationBuilder.DropForeignKey(
                name: "fk_internalresearchers_teachingcategories_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers");

            migrationBuilder.DropForeignKey(
                name: "fk_projects_internalresearchers_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "projects");

            migrationBuilder.DropTable(
                name: "callforproposalknowledgeareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "financierknowledgeareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "participatingorganizationknowledgeareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectexternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectinternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "publicationresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "publicationresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "thesisresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "thesisresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "trainingresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "trainingresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "externalresearchers",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropPrimaryKey(
                name: "pk_internalresearchers",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers");

            migrationBuilder.RenameTable(
                name: "internalresearchers",
                schema: "decisoriscamaguey_idi",
                newName: "researchers",
                newSchema: "decisoriscamaguey_idi");

            migrationBuilder.RenameIndex(
                name: "ix_internalresearchers_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                newName: "ix_researchers_teachingcategoryid");

            migrationBuilder.RenameIndex(
                name: "ix_internalresearchers_employeeid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                newName: "ix_researchers_employeeid");

            migrationBuilder.RenameIndex(
                name: "ix_internalresearchers_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                newName: "ix_researchers_categoryid");

            migrationBuilder.AddColumn<Guid>(
                name: "mainauthorid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "employeeid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "contactid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "participatingorganizationid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "salary",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_researchers",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "id");

            migrationBuilder.CreateTable(
                name: "projectresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    timeavailability = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "researchareas",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_researchareas", x => x.id);
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
                name: "callforproposalresearchareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforproposalresearchareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_callforproposalresearchareabridges_callforproposals_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforproposals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_callforproposalresearchareabridges_researchareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "financierresearchareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financierresearchareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_financierresearchareabridges_financiers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_financierresearchareabridges_researchareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "participatingorganizationresearchareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participatingorganizationresearchareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_participatingorganizationresearchareabridges_participatingo~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "participatingorganizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_participatingorganizationresearchareabridges_researchareas_~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
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

            migrationBuilder.CreateIndex(
                name: "ix_samples_researcherid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "researcherid");

            migrationBuilder.CreateIndex(
                name: "ix_publicationresults_mainauthorid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                column: "mainauthorid");

            migrationBuilder.CreateIndex(
                name: "ix_researchers_contactid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_researchers_participatingorganizationid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "participatingorganizationid");

            migrationBuilder.CreateIndex(
                name: "ix_callforproposalresearchareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "callforproposalresearchareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_financierresearchareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "financierresearchareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_participatingorganizationresearchareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "participatingorganizationresearchareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_projectresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_publicationresultresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresultresearcherbridges",
                column: "sternid");

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
                name: "ix_thesisresultresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresultresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingresultresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresultresearcherbridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_projects_researchers_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "chiefid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "researchers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_publicationresults_researchers_mainauthorid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                column: "mainauthorid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "researchers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_researchers_employees_employeeid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "employeeid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_researchers_participatingorganizations_participatingorganiz~",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "participatingorganizationid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "participatingorganizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_researchers_personcontacts_contactid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_researchers_researchercategories_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "categoryid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "researchercategories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_researchers_teachingcategories_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "researchers",
                column: "teachingcategoryid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "teachingcategories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_samples_researchers_researcherid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "researcherid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "researchers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
