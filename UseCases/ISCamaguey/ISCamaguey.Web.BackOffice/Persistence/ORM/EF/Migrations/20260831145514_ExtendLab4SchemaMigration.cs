using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_lab",
                table: "workplans");

            migrationBuilder.AddColumn<Guid>(
                name: "workinggroupid",
                schema: "decisoriscamaguey_lab",
                table: "workplans",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_workplans_workinggroupid",
                schema: "decisoriscamaguey_lab",
                table: "workplans",
                column: "workinggroupid");

            migrationBuilder.AddForeignKey(
                name: "fk_workplans_workinggroups_workinggroupid",
                schema: "decisoriscamaguey_lab",
                table: "workplans",
                column: "workinggroupid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "workinggroups",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_workplans_workinggroups_workinggroupid",
                schema: "decisoriscamaguey_lab",
                table: "workplans");

            migrationBuilder.DropIndex(
                name: "ix_workplans_workinggroupid",
                schema: "decisoriscamaguey_lab",
                table: "workplans");

            migrationBuilder.DropColumn(
                name: "workinggroupid",
                schema: "decisoriscamaguey_lab",
                table: "workplans");

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_lab",
                table: "workplans",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
