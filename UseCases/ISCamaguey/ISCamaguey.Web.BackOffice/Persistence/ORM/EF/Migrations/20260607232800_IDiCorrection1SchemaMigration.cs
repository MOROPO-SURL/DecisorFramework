using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IDiCorrection1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projectbudgetfunancings_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings");

            migrationBuilder.AlterColumn<Guid>(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_projectbudgetfunancings_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                column: "projectid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projectbudgetfunancings_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings");

            migrationBuilder.AlterColumn<Guid>(
                name: "projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_projectbudgetfunancings_projects_projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                column: "projectid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "projects",
                principalColumn: "id");
        }
    }
}
