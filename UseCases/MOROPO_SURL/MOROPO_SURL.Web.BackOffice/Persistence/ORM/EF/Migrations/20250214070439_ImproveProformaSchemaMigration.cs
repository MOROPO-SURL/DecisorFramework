using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ImproveProformaSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "cacheddocumentat",
                schema: "decisorframework_legal",
                table: "proformas",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "cacheddocumentid",
                schema: "decisorframework_legal",
                table: "proformas",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdat",
                schema: "decisorframework_legal",
                table: "proformas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "editedat",
                schema: "decisorframework_legal",
                table: "proformas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "rawdocumentid",
                schema: "decisorframework_legal",
                table: "proformas",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_proformas_cacheddocumentid",
                schema: "decisorframework_legal",
                table: "proformas",
                column: "cacheddocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_proformas_rawdocumentid",
                schema: "decisorframework_legal",
                table: "proformas",
                column: "rawdocumentid");

            migrationBuilder.AddForeignKey(
                name: "fk_proformas_documents_cacheddocumentid",
                schema: "decisorframework_legal",
                table: "proformas",
                column: "cacheddocumentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_proformas_documents_rawdocumentid",
                schema: "decisorframework_legal",
                table: "proformas",
                column: "rawdocumentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_proformas_documents_cacheddocumentid",
                schema: "decisorframework_legal",
                table: "proformas");

            migrationBuilder.DropForeignKey(
                name: "fk_proformas_documents_rawdocumentid",
                schema: "decisorframework_legal",
                table: "proformas");

            migrationBuilder.DropIndex(
                name: "ix_proformas_cacheddocumentid",
                schema: "decisorframework_legal",
                table: "proformas");

            migrationBuilder.DropIndex(
                name: "ix_proformas_rawdocumentid",
                schema: "decisorframework_legal",
                table: "proformas");

            migrationBuilder.DropColumn(
                name: "cacheddocumentat",
                schema: "decisorframework_legal",
                table: "proformas");

            migrationBuilder.DropColumn(
                name: "cacheddocumentid",
                schema: "decisorframework_legal",
                table: "proformas");

            migrationBuilder.DropColumn(
                name: "createdat",
                schema: "decisorframework_legal",
                table: "proformas");

            migrationBuilder.DropColumn(
                name: "editedat",
                schema: "decisorframework_legal",
                table: "proformas");

            migrationBuilder.DropColumn(
                name: "rawdocumentid",
                schema: "decisorframework_legal",
                table: "proformas");
        }
    }
}
