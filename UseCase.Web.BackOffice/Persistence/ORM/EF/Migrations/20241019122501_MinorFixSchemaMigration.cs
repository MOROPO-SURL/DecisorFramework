using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class MinorFixSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "unitmeasurements");

            migrationBuilder.DropColumn(
                name: "iscontextual",
                table: "purchaseproductnaturalproviderbridges");

            migrationBuilder.AddColumn<string>(
                name: "symbol",
                table: "unitmeasurements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "costcenterid",
                table: "purchaseproductnaturalproviderbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_purchaseproductnaturalproviderbridges_costcenterid",
                table: "purchaseproductnaturalproviderbridges",
                column: "costcenterid");

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseproductnaturalproviderbridges_costcenters_costcente~",
                table: "purchaseproductnaturalproviderbridges",
                column: "costcenterid",
                principalTable: "costcenters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchaseproductnaturalproviderbridges_costcenters_costcente~",
                table: "purchaseproductnaturalproviderbridges");

            migrationBuilder.DropIndex(
                name: "ix_purchaseproductnaturalproviderbridges_costcenterid",
                table: "purchaseproductnaturalproviderbridges");

            migrationBuilder.DropColumn(
                name: "symbol",
                table: "unitmeasurements");

            migrationBuilder.DropColumn(
                name: "costcenterid",
                table: "purchaseproductnaturalproviderbridges");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "unitmeasurements",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "iscontextual",
                table: "purchaseproductnaturalproviderbridges",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
