using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemakePurchasePlanAdvanceRelationSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_advances_purchases_purchaseid",
                schema: "decisorframework_purchasing",
                table: "advances");

            migrationBuilder.DropIndex(
                name: "ix_advances_purchaseid",
                schema: "decisorframework_purchasing",
                table: "advances");

            migrationBuilder.RenameColumn(
                name: "purchaseid",
                schema: "decisorframework_purchasing",
                table: "advances",
                newName: "purchaseplanid");

            migrationBuilder.AddColumn<decimal>(
                name: "estimatedadvance",
                schema: "decisorframework_purchasing",
                table: "purchaseplans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "ix_advances_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "advances",
                column: "purchaseplanid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_advances_purchaseplans_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "advances",
                column: "purchaseplanid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseplans",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_advances_purchaseplans_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "advances");

            migrationBuilder.DropIndex(
                name: "ix_advances_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "advances");

            migrationBuilder.DropColumn(
                name: "estimatedadvance",
                schema: "decisorframework_purchasing",
                table: "purchaseplans");

            migrationBuilder.RenameColumn(
                name: "purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "advances",
                newName: "purchaseid");

            migrationBuilder.CreateIndex(
                name: "ix_advances_purchaseid",
                schema: "decisorframework_purchasing",
                table: "advances",
                column: "purchaseid");

            migrationBuilder.AddForeignKey(
                name: "fk_advances_purchases_purchaseid",
                schema: "decisorframework_purchasing",
                table: "advances",
                column: "purchaseid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchases",
                principalColumn: "id");
        }
    }
}
