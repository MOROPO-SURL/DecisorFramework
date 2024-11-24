using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendFinancialSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "defaultbankaccountid",
                schema: "decisorframework_finantial",
                table: "costcenters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "currencyid",
                schema: "decisorframework_finantial",
                table: "bankaccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "bankdebitcards",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    bankaccountid = table.Column<Guid>(type: "uuid", nullable: false),
                    expireon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bankdebitcards", x => x.id);
                    table.ForeignKey(
                        name: "fk_bankdebitcards_bankaccounts_bankaccountid",
                        column: x => x.bankaccountid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    symbol = table.Column<string>(type: "text", nullable: false),
                    useendsymbolpresentation = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currencies", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_costcenters_defaultbankaccountid",
                schema: "decisorframework_finantial",
                table: "costcenters",
                column: "defaultbankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_bankaccounts_currencyid",
                schema: "decisorframework_finantial",
                table: "bankaccounts",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "ix_bankdebitcards_bankaccountid",
                schema: "decisorframework_finantial",
                table: "bankdebitcards",
                column: "bankaccountid");

            migrationBuilder.AddForeignKey(
                name: "fk_bankaccounts_currencies_currencyid",
                schema: "decisorframework_finantial",
                table: "bankaccounts",
                column: "currencyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_costcenters_bankaccounts_defaultbankaccountid",
                schema: "decisorframework_finantial",
                table: "costcenters",
                column: "defaultbankaccountid",
                principalSchema: "decisorframework_finantial",
                principalTable: "bankaccounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bankaccounts_currencies_currencyid",
                schema: "decisorframework_finantial",
                table: "bankaccounts");

            migrationBuilder.DropForeignKey(
                name: "fk_costcenters_bankaccounts_defaultbankaccountid",
                schema: "decisorframework_finantial",
                table: "costcenters");

            migrationBuilder.DropTable(
                name: "bankdebitcards",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "currencies",
                schema: "decisorframework_finantial");

            migrationBuilder.DropIndex(
                name: "ix_costcenters_defaultbankaccountid",
                schema: "decisorframework_finantial",
                table: "costcenters");

            migrationBuilder.DropIndex(
                name: "ix_bankaccounts_currencyid",
                schema: "decisorframework_finantial",
                table: "bankaccounts");

            migrationBuilder.DropColumn(
                name: "defaultbankaccountid",
                schema: "decisorframework_finantial",
                table: "costcenters");

            migrationBuilder.DropColumn(
                name: "currencyid",
                schema: "decisorframework_finantial",
                table: "bankaccounts");
        }
    }
}
