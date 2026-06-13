using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IDiCorrection2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projectbudgetfunancings_currencies_financierid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings");

            migrationBuilder.CreateIndex(
                name: "ix_projectbudgetfunancings_currencyid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                column: "currencyid");

            migrationBuilder.AddForeignKey(
                name: "fk_projectbudgetfunancings_currencies_currencyid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                column: "currencyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projectbudgetfunancings_currencies_currencyid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings");

            migrationBuilder.DropIndex(
                name: "ix_projectbudgetfunancings_currencyid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings");

            migrationBuilder.AddForeignKey(
                name: "fk_projectbudgetfunancings_currencies_financierid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                column: "financierid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
