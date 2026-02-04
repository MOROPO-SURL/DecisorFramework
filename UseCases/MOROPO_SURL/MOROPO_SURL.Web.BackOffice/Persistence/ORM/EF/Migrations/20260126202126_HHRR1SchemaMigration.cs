using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HHRR1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vacants_workforceorganizationalunities_workforceorganizatio~",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.AddColumn<Guid>(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "workforceorganizationalunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "ix_workforces_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "chiefvacantid");

            migrationBuilder.AddForeignKey(
                name: "fk_vacants_workforceorganizationalunities_workforceorganizatio~",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceorganizationalunityid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforceorganizationalunities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_workforces_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "chiefvacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vacants_workforceorganizationalunities_workforceorganizatio~",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropForeignKey(
                name: "fk_workforces_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropIndex(
                name: "ix_workforces_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropColumn(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.AlterColumn<Guid>(
                name: "workforceorganizationalunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_vacants_workforceorganizationalunities_workforceorganizatio~",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceorganizationalunityid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforceorganizationalunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
