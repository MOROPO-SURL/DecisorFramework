using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResourceExtend1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "employees",
                schema: "decisorframework_humanresources",
                newName: "employees",
                newSchema: "decisorframework_domain");

            migrationBuilder.AddColumn<Guid>(
                name: "responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "vacantpostulations",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    officialpostalcontactitemid = table.Column<Guid>(type: "uuid", nullable: false),
                    alternativepostalcontactitemid = table.Column<Guid>(type: "uuid", nullable: true),
                    schoolingid = table.Column<Guid>(type: "uuid", nullable: false),
                    schoolingcomplement = table.Column<string>(type: "text", nullable: true),
                    maleparentname = table.Column<string>(type: "text", nullable: false),
                    femaleparentname = table.Column<string>(type: "text", nullable: false),
                    alignment = table.Column<bool>(type: "boolean", nullable: false),
                    responsabilitycommitment = table.Column<string>(type: "text", nullable: false),
                    rawmodeldocumentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacantpostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacantpostulations_documents_rawmodeldocumentid",
                        column: x => x.rawmodeldocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vacantpostulations_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacantpostulations_postalcontactitems_alternativepostalcont~",
                        column: x => x.alternativepostalcontactitemid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "postalcontactitems",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vacantpostulations_postalcontactitems_officialpostalcontact~",
                        column: x => x.officialpostalcontactitemid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "postalcontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacantpostulations_schoolings_schoolingid",
                        column: x => x.schoolingid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "schoolings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacantpostulations_vacants_vacantid",
                        column: x => x.vacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workpositionresponsabilities",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    workpositionid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workpositionresponsabilities", x => x.id);
                    table.ForeignKey(
                        name: "fk_workpositionresponsabilities_workpositions_workpositionid",
                        column: x => x.workpositionid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ocupationcandidates",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    interviewat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    postulationid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    medicalcheckat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    rawmedicalcheckdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    physicologicalcheckat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    physicologicalcheckdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    defensestatuscheckat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    rawdefensestatuscheckdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    researchrequestat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    researchresultat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    rawresearchresultdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    rawmodeldocumentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ocupationcandidates", x => x.id);
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_documents_physicologicalcheckdocumentid",
                        column: x => x.physicologicalcheckdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_documents_rawdefensestatuscheckdocument~",
                        column: x => x.rawdefensestatuscheckdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_documents_rawmedicalcheckdocumentid",
                        column: x => x.rawmedicalcheckdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_documents_rawmodeldocumentid",
                        column: x => x.rawmodeldocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_documents_rawresearchresultdocumentid",
                        column: x => x.rawresearchresultdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_vacantpostulations_postulationid",
                        column: x => x.postulationid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacantpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacantpostulationdocumentbridges",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacantpostulationdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vacantpostulationdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacantpostulationdocumentbridges_vacantpostulations_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacantpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacantpostulationocupations",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    postulationid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationname = table.Column<string>(type: "text", nullable: false),
                    organizationaddress = table.Column<string>(type: "text", nullable: true),
                    representativename = table.Column<string>(type: "text", nullable: true),
                    centralstatestructureid = table.Column<Guid>(type: "uuid", nullable: true),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacantpostulationocupations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacantpostulationocupations_centralstatestructures_centrals~",
                        column: x => x.centralstatestructureid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "centralstatestructures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vacantpostulationocupations_vacantpostulations_postulationid",
                        column: x => x.postulationid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacantpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admitionpropousals",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ocupationcandidateid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admitionpropousals", x => x.id);
                    table.ForeignKey(
                        name: "fk_admitionpropousals_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_admitionpropousals_ocupationcandidates_ocupationcandidateid",
                        column: x => x.ocupationcandidateid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "ocupationcandidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_workforces_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "responsiblevacantid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_admitionpropousals_agreementid",
                schema: "decisorframework_humanresources",
                table: "admitionpropousals",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_admitionpropousals_ocupationcandidateid",
                schema: "decisorframework_humanresources",
                table: "admitionpropousals",
                column: "ocupationcandidateid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_physicologicalcheckdocumentid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "physicologicalcheckdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_postulationid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "postulationid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_rawdefensestatuscheckdocumentid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "rawdefensestatuscheckdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_rawmedicalcheckdocumentid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "rawmedicalcheckdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_rawmodeldocumentid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "rawmodeldocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_rawresearchresultdocumentid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "rawresearchresultdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_responsibleid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulationdocumentbridges_sternid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulationdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulationocupations_centralstatestructureid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulationocupations",
                column: "centralstatestructureid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulationocupations_postulationid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulationocupations",
                column: "postulationid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_alternativepostalcontactitemid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "alternativepostalcontactitemid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_contactid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_officialpostalcontactitemid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "officialpostalcontactitemid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_rawmodeldocumentid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "rawmodeldocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "schoolingid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_vacantid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "vacantid");

            migrationBuilder.CreateIndex(
                name: "ix_workpositionresponsabilities_workpositionid",
                schema: "decisorframework_humanresources",
                table: "workpositionresponsabilities",
                column: "workpositionid");

            migrationBuilder.AddForeignKey(
                name: "fk_workforces_vacants_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "responsiblevacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_workforces_vacants_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropTable(
                name: "admitionpropousals",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vacantpostulationdocumentbridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vacantpostulationocupations",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "workpositionresponsabilities",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "ocupationcandidates",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vacantpostulations",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropIndex(
                name: "ix_workforces_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropColumn(
                name: "responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.RenameTable(
                name: "employees",
                schema: "decisorframework_domain",
                newName: "employees",
                newSchema: "decisorframework_humanresources");
        }
    }
}
