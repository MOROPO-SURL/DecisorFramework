using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade9SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "documentid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "documentid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "documentid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "documentid",
                schema: "decisorframework_sales",
                table: "legalclientbudget",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgets_documentid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudget_documentid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgets_documentid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudget_documentid",
                schema: "decisorframework_sales",
                table: "legalclientbudget",
                column: "documentid");

            migrationBuilder.AddForeignKey(
                name: "fk_legalclientbudget_documents_documentid",
                schema: "decisorframework_sales",
                table: "legalclientbudget",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgets_documents_documentid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_naturalclientbudget_documents_documentid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgets_documents_documentid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_legalclientbudget_documents_documentid",
                schema: "decisorframework_sales",
                table: "legalclientbudget");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgets_documents_documentid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalclientbudget_documents_documentid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgets_documents_documentid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets");

            migrationBuilder.DropIndex(
                name: "ix_naturalproviderbudgets_documentid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets");

            migrationBuilder.DropIndex(
                name: "ix_naturalclientbudget_documentid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget");

            migrationBuilder.DropIndex(
                name: "ix_legalproviderbudgets_documentid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets");

            migrationBuilder.DropIndex(
                name: "ix_legalclientbudget_documentid",
                schema: "decisorframework_sales",
                table: "legalclientbudget");

            migrationBuilder.DropColumn(
                name: "documentid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets");

            migrationBuilder.DropColumn(
                name: "documentid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget");

            migrationBuilder.DropColumn(
                name: "documentid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets");

            migrationBuilder.DropColumn(
                name: "documentid",
                schema: "decisorframework_sales",
                table: "legalclientbudget");
        }
    }
}
