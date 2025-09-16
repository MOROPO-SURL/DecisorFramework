using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade6SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_properties_propertyid",
                table: "leasecontracts");

            migrationBuilder.DropIndex(
                name: "ix_leasecontracts_propertyid",
                table: "leasecontracts");

            migrationBuilder.DropColumn(
                name: "propertyid",
                table: "leasecontracts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "propertyid",
                table: "leasecontracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_propertyid",
                table: "leasecontracts",
                column: "propertyid");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_properties_propertyid",
                table: "leasecontracts",
                column: "propertyid",
                principalSchema: "decisorframework_domain",
                principalTable: "properties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
