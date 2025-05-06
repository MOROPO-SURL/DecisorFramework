using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class VehicleCategoryToKindSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehiclecategories_categoryid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "vehiclecategories",
                schema: "decisorframework_domain");

            migrationBuilder.DropIndex(
                name: "ix_vehicles_categoryid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "categoryid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.AddColumn<Guid>(
                name: "kindid",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "vehiclekinds",
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
                    table.PrimaryKey("pk_vehiclekinds", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_kindid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "kindid");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehiclekinds_kindid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "kindid",
                principalSchema: "decisorframework_domain",
                principalTable: "vehiclekinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehiclekinds_kindid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "vehiclekinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropIndex(
                name: "ix_vehicles_kindid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "kindid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.AddColumn<int>(
                name: "categoryid",
                schema: "decisorframework_domain",
                table: "vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "vehiclecategories",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parentid = table.Column<int>(type: "integer", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiclecategories", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehiclecategories_vehiclecategories_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehiclecategories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_categoryid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_vehiclecategories_parentid",
                schema: "decisorframework_domain",
                table: "vehiclecategories",
                column: "parentid");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehiclecategories_categoryid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "categoryid",
                principalSchema: "decisorframework_domain",
                principalTable: "vehiclecategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
