using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab9SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.AddColumn<Guid>(
                name: "documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_assessments_documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "documentid");

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_documents_documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_assessments_documents_documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropIndex(
                name: "ix_assessments_documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropColumn(
                name: "documentid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
