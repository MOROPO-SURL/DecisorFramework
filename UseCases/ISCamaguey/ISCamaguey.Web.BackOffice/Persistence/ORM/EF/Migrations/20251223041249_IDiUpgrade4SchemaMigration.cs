using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IDiUpgrade4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projectproposals_documents_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals");

            migrationBuilder.AlterColumn<Guid>(
                name: "documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_projectproposals_documents_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projectproposals_documents_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals");

            migrationBuilder.AlterColumn<Guid>(
                name: "documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_projectproposals_documents_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
