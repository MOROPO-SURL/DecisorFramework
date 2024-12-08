using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class MinorChangesPurchaseSpentBridgeSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                schema: "decisorframework_purchasing",
                table: "purchasepurchasespentbridges");

            migrationBuilder.AddColumn<int>(
                name: "count",
                schema: "decisorframework_purchasing",
                table: "purchasepurchasespentbridges",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isregular",
                schema: "decisorframework_purchasing",
                table: "purchasepurchasespentbridges",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                schema: "decisorframework_purchasing",
                table: "purchasepurchasespentbridges");

            migrationBuilder.DropColumn(
                name: "isregular",
                schema: "decisorframework_purchasing",
                table: "purchasepurchasespentbridges");

            migrationBuilder.AddColumn<decimal>(
                name: "cost",
                schema: "decisorframework_purchasing",
                table: "purchasepurchasespentbridges",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
