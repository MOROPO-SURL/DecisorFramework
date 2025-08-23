using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResourceExtend2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "alignment",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "text",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<Guid>(
                name: "staffid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_staffid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "staffid");

            migrationBuilder.AddForeignKey(
                name: "fk_vacantpostulations_staffs_staffid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staffs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vacantpostulations_staffs_staffid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.DropIndex(
                name: "ix_vacantpostulations_staffid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.DropColumn(
                name: "staffid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.AlterColumn<bool>(
                name: "alignment",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
