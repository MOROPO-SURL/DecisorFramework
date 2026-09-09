using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab8SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_assessments_authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_analysises_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "authorid");

            migrationBuilder.AddForeignKey(
                name: "fk_analysises_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assessments_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_analysises_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropForeignKey(
                name: "fk_assessments_employees_authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropIndex(
                name: "ix_assessments_authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropIndex(
                name: "ix_analysises_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropColumn(
                name: "authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments");

            migrationBuilder.DropColumn(
                name: "authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");
        }
    }
}
