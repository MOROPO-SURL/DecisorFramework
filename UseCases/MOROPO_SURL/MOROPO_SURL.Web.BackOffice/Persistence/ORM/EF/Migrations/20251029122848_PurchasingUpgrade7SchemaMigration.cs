using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade7SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetservicebridges_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                column: "currentyid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproductbridges_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "currentyid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetservicebridge_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                column: "currentyid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproductbridge_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "currentyid");

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetproductbridge_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "currentyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridge_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                column: "currentyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "currentyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetservicebridges_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                column: "currentyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetproductbridge_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetservicebridge_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetservicebridges_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropIndex(
                name: "ix_naturalproviderbudgetservicebridges_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropIndex(
                name: "ix_naturalproviderbudgetproductbridges_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropIndex(
                name: "ix_legalproviderbudgetservicebridge_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropIndex(
                name: "ix_legalproviderbudgetproductbridge_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropColumn(
                name: "currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropColumn(
                name: "currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropColumn(
                name: "currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropColumn(
                name: "currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");
        }
    }
}
