using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PaymentTermInclusionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "paymentterms",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    term = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paymentterms", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviders_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "defaultpaymenttermid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclients_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "defaultpaymenttermid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviders_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                column: "defaultpaymenttermid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclients_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "defaultpaymenttermid");

            migrationBuilder.AddForeignKey(
                name: "fk_legalclients_paymentterms_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "defaultpaymenttermid",
                principalSchema: "decisorframework_commercial",
                principalTable: "paymentterms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviders_paymentterms_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                column: "defaultpaymenttermid",
                principalSchema: "decisorframework_commercial",
                principalTable: "paymentterms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalclients_paymentterms_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "defaultpaymenttermid",
                principalSchema: "decisorframework_commercial",
                principalTable: "paymentterms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviders_paymentterms_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "defaultpaymenttermid",
                principalSchema: "decisorframework_commercial",
                principalTable: "paymentterms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_legalclients_paymentterms_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviders_paymentterms_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalclients_paymentterms_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviders_paymentterms_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropTable(
                name: "paymentterms",
                schema: "decisorframework_commercial");

            migrationBuilder.DropIndex(
                name: "ix_naturalproviders_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropIndex(
                name: "ix_naturalclients_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropIndex(
                name: "ix_legalproviders_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropIndex(
                name: "ix_legalclients_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.DropColumn(
                name: "defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropColumn(
                name: "defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropColumn(
                name: "defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropColumn(
                name: "defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalclients");
        }
    }
}
