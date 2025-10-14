using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HHRRUpgrade4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_workforceorganizationalunities_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities");

            migrationBuilder.AlterColumn<Guid>(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_workforceorganizationalunities_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "chiefvacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_workforceorganizationalunities_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities");

            migrationBuilder.AlterColumn<Guid>(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_workforceorganizationalunities_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "chiefvacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
