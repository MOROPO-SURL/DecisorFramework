using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LegalSectionParentSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "parentid",
                schema: "decisorframework_legal",
                table: "sections",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_sections_parentid",
                schema: "decisorframework_legal",
                table: "sections",
                column: "parentid");

            migrationBuilder.AddForeignKey(
                name: "fk_sections_sections_parentid",
                schema: "decisorframework_legal",
                table: "sections",
                column: "parentid",
                principalSchema: "decisorframework_legal",
                principalTable: "sections",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sections_sections_parentid",
                schema: "decisorframework_legal",
                table: "sections");

            migrationBuilder.DropIndex(
                name: "ix_sections_parentid",
                schema: "decisorframework_legal",
                table: "sections");

            migrationBuilder.DropColumn(
                name: "parentid",
                schema: "decisorframework_legal",
                table: "sections");
        }
    }
}
