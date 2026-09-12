using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab11SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_analysises_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropForeignKey(
                name: "fk_analysises_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropForeignKey(
                name: "fk_analysises_techniques_techniqueid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropForeignKey(
                name: "fk_analysises_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropForeignKey(
                name: "fk_assessments_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropForeignKey(
                name: "fk_assessments_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropForeignKey(
                name: "fk_assessments_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisreports_analysises_analysisid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisreports");

            migrationBuilder.DropIndex(
                name: "ix_assessments_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropPrimaryKey(
                name: "pk_analysises",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.RenameTable(
                name: "analysises",
                schema: "decisoriscamaguey_lab",
                newName: "analyses",
                newSchema: "decisoriscamaguey_lab");

            migrationBuilder.RenameIndex(
                name: "ix_analysises_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analyses",
                newName: "ix_analyses_workplanid");

            migrationBuilder.RenameIndex(
                name: "ix_analysises_techniqueid",
                schema: "decisoriscamaguey_lab",
                table: "analyses",
                newName: "ix_analyses_techniqueid");

            migrationBuilder.RenameIndex(
                name: "ix_analysises_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analyses",
                newName: "ix_analyses_sampleid");

            migrationBuilder.RenameIndex(
                name: "ix_analysises_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analyses",
                newName: "ix_analyses_authorid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_analyses",
                schema: "decisoriscamaguey_lab",
                table: "analyses",
                column: "id");

            migrationBuilder.CreateTable(
                name: "analysisqualitychecks",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    workplanid = table.Column<Guid>(type: "uuid", nullable: true),
                    sampleid = table.Column<Guid>(type: "uuid", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    qualitypercent = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_analysisqualitychecks", x => x.id);
                    table.ForeignKey(
                        name: "fk_analysisqualitychecks_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_analysisqualitychecks_samples_sampleid",
                        column: x => x.sampleid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_analysisqualitychecks_workplans_workplanid",
                        column: x => x.workplanid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_assessments_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "sampleid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_analysisqualitychecks_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_analysisqualitychecks_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                column: "sampleid");

            migrationBuilder.CreateIndex(
                name: "ix_analysisqualitychecks_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                column: "workplanid");

            migrationBuilder.AddForeignKey(
                name: "fk_analyses_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analyses",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_analyses_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analyses",
                column: "sampleid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "samples",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_analyses_techniques_techniqueid",
                schema: "decisoriscamaguey_lab",
                table: "analyses",
                column: "techniqueid",
                principalSchema: "decisoriscamaguey_domain",
                principalTable: "techniques",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_analyses_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analyses",
                column: "workplanid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "workplans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "sampleid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "samples",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "workplanid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "workplans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisreports_analyses_analysisid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisreports",
                column: "analysisid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "analyses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_analyses_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analyses");

            migrationBuilder.DropForeignKey(
                name: "fk_analyses_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analyses");

            migrationBuilder.DropForeignKey(
                name: "fk_analyses_techniques_techniqueid",
                schema: "decisoriscamaguey_lab",
                table: "analyses");

            migrationBuilder.DropForeignKey(
                name: "fk_analyses_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analyses");

            migrationBuilder.DropForeignKey(
                name: "fk_assessments_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropForeignKey(
                name: "fk_assessments_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropForeignKey(
                name: "fk_assessments_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisreports_analyses_analysisid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisreports");

            migrationBuilder.DropTable(
                name: "analysisqualitychecks",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropIndex(
                name: "ix_assessments_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropPrimaryKey(
                name: "pk_analyses",
                schema: "decisoriscamaguey_lab",
                table: "analyses");

            migrationBuilder.RenameTable(
                name: "analyses",
                schema: "decisoriscamaguey_lab",
                newName: "analysises",
                newSchema: "decisoriscamaguey_lab");

            migrationBuilder.RenameIndex(
                name: "ix_analyses_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                newName: "ix_analysises_workplanid");

            migrationBuilder.RenameIndex(
                name: "ix_analyses_techniqueid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                newName: "ix_analysises_techniqueid");

            migrationBuilder.RenameIndex(
                name: "ix_analyses_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                newName: "ix_analysises_sampleid");

            migrationBuilder.RenameIndex(
                name: "ix_analyses_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                newName: "ix_analysises_authorid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_analysises",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_assessments_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "sampleid");

            migrationBuilder.AddForeignKey(
                name: "fk_analysises_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_analysises_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "sampleid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "samples",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_analysises_techniques_techniqueid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "techniqueid",
                principalSchema: "decisoriscamaguey_domain",
                principalTable: "techniques",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_analysises_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "workplanid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "workplans",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "sampleid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "samples",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "workplanid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "workplans",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisreports_analysises_analysisid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisreports",
                column: "analysisid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "analysises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
