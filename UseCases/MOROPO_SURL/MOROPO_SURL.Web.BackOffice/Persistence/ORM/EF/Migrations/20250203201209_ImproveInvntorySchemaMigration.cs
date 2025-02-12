using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ImproveInvntorySchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_batches_warehouses_warehouseid",
                schema: "decisorframework_inventory",
                table: "batches");

            migrationBuilder.DropForeignKey(
                name: "fk_products_categories_categoryid",
                schema: "decisorframework_inventory",
                table: "products");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "decisorframework_inventory");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                schema: "decisorframework_inventory",
                table: "products",
                newName: "familyid");

            migrationBuilder.RenameIndex(
                name: "ix_products_categoryid",
                schema: "decisorframework_inventory",
                table: "products",
                newName: "ix_products_familyid");

            migrationBuilder.RenameColumn(
                name: "warehouseid",
                schema: "decisorframework_inventory",
                table: "batches",
                newName: "warehousingareaid");

            migrationBuilder.RenameIndex(
                name: "ix_batches_warehouseid",
                schema: "decisorframework_inventory",
                table: "batches",
                newName: "ix_batches_warehousingareaid");

            migrationBuilder.AddColumn<int>(
                name: "kind",
                schema: "decisorframework_inventory",
                table: "warehouses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "expirationtime",
                schema: "decisorframework_inventory",
                table: "products",
                type: "interval",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "families",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    parentid = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_families", x => x.id);
                    table.ForeignKey(
                        name: "fk_families_families_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "families",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "warehousingareas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    warehouseid = table.Column<Guid>(type: "uuid", nullable: false),
                    capacity = table.Column<double>(type: "double precision", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    familyid = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_warehousingareas", x => x.id);
                    table.ForeignKey(
                        name: "fk_warehousingareas_families_familyid",
                        column: x => x.familyid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "families",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_warehousingareas_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_warehousingareas_warehouses_warehouseid",
                        column: x => x.warehouseid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "warehouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_families_parentid",
                schema: "decisorframework_inventory",
                table: "families",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_warehousingareas_familyid",
                table: "warehousingareas",
                column: "familyid");

            migrationBuilder.CreateIndex(
                name: "ix_warehousingareas_unitmeasurementid",
                table: "warehousingareas",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_warehousingareas_warehouseid",
                table: "warehousingareas",
                column: "warehouseid");

            migrationBuilder.AddForeignKey(
                name: "fk_batches_warehousingareas_warehousingareaid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "warehousingareaid",
                principalTable: "warehousingareas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_families_familyid",
                schema: "decisorframework_inventory",
                table: "products",
                column: "familyid",
                principalSchema: "decisorframework_inventory",
                principalTable: "families",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_batches_warehousingareas_warehousingareaid",
                schema: "decisorframework_inventory",
                table: "batches");

            migrationBuilder.DropForeignKey(
                name: "fk_products_families_familyid",
                schema: "decisorframework_inventory",
                table: "products");

            migrationBuilder.DropTable(
                name: "warehousingareas");

            migrationBuilder.DropTable(
                name: "families",
                schema: "decisorframework_inventory");

            migrationBuilder.DropColumn(
                name: "kind",
                schema: "decisorframework_inventory",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "expirationtime",
                schema: "decisorframework_inventory",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "familyid",
                schema: "decisorframework_inventory",
                table: "products",
                newName: "categoryid");

            migrationBuilder.RenameIndex(
                name: "ix_products_familyid",
                schema: "decisorframework_inventory",
                table: "products",
                newName: "ix_products_categoryid");

            migrationBuilder.RenameColumn(
                name: "warehousingareaid",
                schema: "decisorframework_inventory",
                table: "batches",
                newName: "warehouseid");

            migrationBuilder.RenameIndex(
                name: "ix_batches_warehousingareaid",
                schema: "decisorframework_inventory",
                table: "batches",
                newName: "ix_batches_warehouseid");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "decisorframework_inventory",
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
                    table.PrimaryKey("pk_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_categories_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_parentid",
                schema: "decisorframework_inventory",
                table: "categories",
                column: "parentid");

            migrationBuilder.AddForeignKey(
                name: "fk_batches_warehouses_warehouseid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "warehouseid",
                principalSchema: "decisorframework_inventory",
                principalTable: "warehouses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_categories_categoryid",
                schema: "decisorframework_inventory",
                table: "products",
                column: "categoryid",
                principalSchema: "decisorframework_inventory",
                principalTable: "categories",
                principalColumn: "id");
        }
    }
}
