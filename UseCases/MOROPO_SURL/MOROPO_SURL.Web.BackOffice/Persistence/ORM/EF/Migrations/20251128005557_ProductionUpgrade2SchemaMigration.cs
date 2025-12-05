using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ProductionUpgrade2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "referenceamount",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "referencecurrencyid",
                schema: "decisorframework_production",
                table: "elaborations");

            migrationBuilder.AlterColumn<decimal>(
                name: "referenceamount",
                schema: "decisorframework_production",
                table: "elaborations",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }
    }
}
