using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab10SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "workplanid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_assessments_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "workplanid");

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "workplanid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "workplans",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_assessments_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropIndex(
                name: "ix_assessments_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropColumn(
                name: "workplanid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");
        }
    }
}
