using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ProductionUpgrade3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_elaborations_currencies_referencecurrencyid",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.DropIndex(
                name: "ix_elaborations_referencecurrencyid",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.DropColumn(
                name: "referenceamount",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.DropColumn(
                name: "referencecurrencyid",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<decimal>(
                name: "referenceamount",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "referencecurrencyid",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_elaborations_referencecurrencyid",
                schema: "decisorframework_production",
                table: "elaborations",
                column: "referencecurrencyid");

            migrationBuilder.AddForeignKey(
                name: "fk_elaborations_currencies_referencecurrencyid",
                schema: "decisorframework_production",
                table: "elaborations",
                column: "referencecurrencyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id");
        }
    }
}
