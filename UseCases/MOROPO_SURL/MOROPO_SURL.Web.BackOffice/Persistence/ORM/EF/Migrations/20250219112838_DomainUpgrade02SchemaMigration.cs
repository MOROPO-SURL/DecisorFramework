using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade02SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "brandid",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "model",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reference",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "year",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "vehiclebrands",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiclebrands", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_brandid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "brandid");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehiclebrands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "brandid",
                principalSchema: "decisorframework_domain",
                principalTable: "vehiclebrands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehiclebrands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "vehiclebrands",
                schema: "decisorframework_domain");

            migrationBuilder.DropIndex(
                name: "ix_vehicles_brandid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "brandid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "model",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "reference",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "year",
                schema: "decisorframework_domain",
                table: "vehicles");
        }
    }
}
