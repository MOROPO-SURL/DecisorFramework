using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class BrandRenameDomainSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehiclebrands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "vehiclebrands",
                schema: "decisorframework_domain");

            migrationBuilder.CreateTable(
                name: "brands",
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
                    table.PrimaryKey("pk_brands", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_brands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "brandid",
                principalSchema: "decisorframework_domain",
                principalTable: "brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_brands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "decisorframework_domain");

            migrationBuilder.CreateTable(
                name: "vehiclebrands",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiclebrands", x => x.id);
                });

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
    }
}
