using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab7SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_analysises_analysises_predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropForeignKey(
                name: "fk_assessments_analysises_targetid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropIndex(
                name: "ix_analysises_predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropIndex(
                name: "ix_analysises_sampleid_predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropColumn(
                name: "predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.RenameColumn(
                name: "targetid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                newName: "sampleid");

            migrationBuilder.RenameIndex(
                name: "ix_assessments_targetid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                newName: "ix_assessments_sampleid");

            migrationBuilder.AddColumn<DateTime>(
                name: "assessmentat",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_analysises_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "sampleid");

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "sampleid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "samples",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_assessments_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropIndex(
                name: "ix_analysises_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropColumn(
                name: "assessmentat",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.RenameColumn(
                name: "sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                newName: "targetid");

            migrationBuilder.RenameIndex(
                name: "ix_assessments_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                newName: "ix_assessments_targetid");

            migrationBuilder.AddColumn<Guid>(
                name: "predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_analysises_predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "predecessorid");

            migrationBuilder.CreateIndex(
                name: "ix_analysises_sampleid_predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                columns: new[] { "sampleid", "predecessorid" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_analysises_analysises_predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "predecessorid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "analysises",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_analysises_targetid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "targetid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "analysises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
