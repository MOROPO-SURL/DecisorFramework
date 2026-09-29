using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendServicing1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_awardresults_awardkinds_kindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.RenameColumn(
                name: "kindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                newName: "receptorid");

            migrationBuilder.RenameIndex(
                name: "ix_awardresults_kindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                newName: "ix_awardresults_receptorid");

            migrationBuilder.AddColumn<Guid>(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresults",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "awardkindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "awardmodality",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_trainingresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresults",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_newtechniqueresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_awardresults_awardkindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                column: "awardkindid");

            migrationBuilder.CreateIndex(
                name: "ix_awardresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                column: "projectid");

            migrationBuilder.AddForeignKey(
                name: "fk_awardresults_awardkinds_awardkindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                column: "awardkindid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "awardkinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_awardresults_employees_receptorid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                column: "receptorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_awardresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                column: "projectid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "projects",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_newtechniqueresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults",
                column: "projectid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "projects",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_trainingresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresults",
                column: "projectid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "projects",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_awardresults_awardkinds_awardkindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.DropForeignKey(
                name: "fk_awardresults_employees_receptorid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.DropForeignKey(
                name: "fk_awardresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.DropForeignKey(
                name: "fk_newtechniqueresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults");

            migrationBuilder.DropForeignKey(
                name: "fk_trainingresults_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresults");

            migrationBuilder.DropIndex(
                name: "ix_trainingresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresults");

            migrationBuilder.DropIndex(
                name: "ix_newtechniqueresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults");

            migrationBuilder.DropIndex(
                name: "ix_awardresults_awardkindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.DropIndex(
                name: "ix_awardresults_projectid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.DropColumn(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresults");

            migrationBuilder.DropColumn(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults");

            migrationBuilder.DropColumn(
                name: "awardkindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.DropColumn(
                name: "awardmodality",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.DropColumn(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.DropColumn(
                name: "title",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.RenameColumn(
                name: "receptorid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                newName: "kindid");

            migrationBuilder.RenameIndex(
                name: "ix_awardresults_receptorid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                newName: "ix_awardresults_kindid");

            migrationBuilder.AddForeignKey(
                name: "fk_awardresults_awardkinds_kindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                column: "kindid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "awardkinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
