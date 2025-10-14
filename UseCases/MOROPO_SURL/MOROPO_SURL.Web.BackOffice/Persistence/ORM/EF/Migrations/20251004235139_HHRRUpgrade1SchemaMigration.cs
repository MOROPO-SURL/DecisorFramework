using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HHRRUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_workforces_vacants_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropIndex(
                name: "ix_workforces_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropColumn(
                name: "responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.AddColumn<Guid>(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunitybridges_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges",
                column: "chiefvacantid");

            migrationBuilder.AddForeignKey(
                name: "fk_workforceorganizationalunitybridges_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges",
                column: "chiefvacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_workforceorganizationalunitybridges_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges");

            migrationBuilder.DropIndex(
                name: "ix_workforceorganizationalunitybridges_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges");

            migrationBuilder.DropColumn(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges");

            migrationBuilder.AddColumn<Guid>(
                name: "responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_workforces_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "responsiblevacantid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_workforces_vacants_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "responsiblevacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id");
        }
    }
}
