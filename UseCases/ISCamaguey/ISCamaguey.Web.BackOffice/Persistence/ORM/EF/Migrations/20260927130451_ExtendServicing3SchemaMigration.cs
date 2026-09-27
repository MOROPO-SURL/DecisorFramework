using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendServicing3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_thesisresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_scientifictechnicalresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_publicationresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                column: "projectid");

            migrationBuilder.AddForeignKey(
                name: "fk_publicationresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                column: "projectid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "projects",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_scientifictechnicalresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults",
                column: "projectid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "projects",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_thesisresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults",
                column: "projectid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "projects",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_publicationresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults");

            migrationBuilder.DropForeignKey(
                name: "fk_scientifictechnicalresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults");

            migrationBuilder.DropForeignKey(
                name: "fk_thesisresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults");

            migrationBuilder.DropIndex(
                name: "ix_thesisresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults");

            migrationBuilder.DropIndex(
                name: "ix_scientifictechnicalresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults");

            migrationBuilder.DropIndex(
                name: "ix_publicationresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults");

            migrationBuilder.DropColumn(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults");

            migrationBuilder.DropColumn(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults");

            migrationBuilder.DropColumn(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults");
        }
    }
}
