using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ProductionUpgrade5SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productionorders_employees_authorid",
                schema: "decisorframework_production",
                table: "productionorders");

            migrationBuilder.DropForeignKey(
                name: "fk_productionorders_employees_decisorid",
                schema: "decisorframework_production",
                table: "productionorders");

            migrationBuilder.DropIndex(
                name: "ix_productionorders_authorid",
                schema: "decisorframework_production",
                table: "productionorders");

            migrationBuilder.DropColumn(
                name: "approvedat",
                schema: "decisorframework_production",
                table: "productionorders");

            migrationBuilder.DropColumn(
                name: "authorid",
                schema: "decisorframework_production",
                table: "productionorders");

            migrationBuilder.RenameColumn(
                name: "decisorid",
                schema: "decisorframework_production",
                table: "productionorders",
                newName: "agreementid");

            migrationBuilder.RenameIndex(
                name: "ix_productionorders_decisorid",
                schema: "decisorframework_production",
                table: "productionorders",
                newName: "ix_productionorders_agreementid");

            migrationBuilder.AddForeignKey(
                name: "fk_productionorders_agreements_agreementid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "agreementid",
                principalSchema: "decisorframework_governance",
                principalTable: "agreements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_productionorders_agreements_agreementid",
                schema: "decisorframework_production",
                table: "productionorders");

            migrationBuilder.RenameColumn(
                name: "agreementid",
                schema: "decisorframework_production",
                table: "productionorders",
                newName: "decisorid");

            migrationBuilder.RenameIndex(
                name: "ix_productionorders_agreementid",
                schema: "decisorframework_production",
                table: "productionorders",
                newName: "ix_productionorders_decisorid");

            migrationBuilder.AddColumn<DateTime>(
                name: "approvedat",
                schema: "decisorframework_production",
                table: "productionorders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "authorid",
                schema: "decisorframework_production",
                table: "productionorders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_authorid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "authorid");

            migrationBuilder.AddForeignKey(
                name: "fk_productionorders_employees_authorid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productionorders_employees_decisorid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "decisorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
