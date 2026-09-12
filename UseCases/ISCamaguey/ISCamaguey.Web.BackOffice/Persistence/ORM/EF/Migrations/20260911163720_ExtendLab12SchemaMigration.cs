using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab12SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_analysisqualitychecks_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks");

            migrationBuilder.DropForeignKey(
                name: "fk_analysisqualitychecks_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks");

            migrationBuilder.DropForeignKey(
                name: "fk_assessments_documents_documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropIndex(
                name: "ix_analysisqualitychecks_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks");

            migrationBuilder.DropColumn(
                name: "workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks");

            migrationBuilder.RenameColumn(
                name: "sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                newName: "analysisid");

            migrationBuilder.RenameIndex(
                name: "ix_analysisqualitychecks_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                newName: "ix_analysisqualitychecks_analysisid");

            migrationBuilder.AlterColumn<Guid>(
                name: "documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_analysisqualitychecks_analyses_analysisid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                column: "analysisid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "analyses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_documents_documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_analysisqualitychecks_analyses_analysisid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks");

            migrationBuilder.DropForeignKey(
                name: "fk_assessments_documents_documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.RenameColumn(
                name: "analysisid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                newName: "sampleid");

            migrationBuilder.RenameIndex(
                name: "ix_analysisqualitychecks_analysisid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                newName: "ix_analysisqualitychecks_sampleid");

            migrationBuilder.AlterColumn<Guid>(
                name: "documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_analysisqualitychecks_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                column: "workplanid");

            migrationBuilder.AddForeignKey(
                name: "fk_analysisqualitychecks_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                column: "sampleid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "samples",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_analysisqualitychecks_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitychecks",
                column: "workplanid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "workplans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_documents_documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");
        }
    }
}
