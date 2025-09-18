using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade12SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_legalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_naturalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.RenameColumn(
                name: "clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                newName: "vehicleleasenaturalclientid");

            migrationBuilder.RenameIndex(
                name: "ix_leasecontracts_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                newName: "ix_leasecontracts_vehicleleasenaturalclientid");

            migrationBuilder.AddColumn<Guid>(
                name: "propertyleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "propertyleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "vehicleleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_propertyleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleaselegalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_propertyleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleasenaturalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_vehicleleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleaselegalclientid");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_legalclients_propertyleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleaselegalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalclients",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_legalclients_vehicleleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleaselegalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalclients",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_naturalclients_propertyleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleasenaturalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalclients",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_naturalclients_vehicleleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleasenaturalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalclients",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_legalclients_propertyleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_legalclients_vehicleleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_naturalclients_propertyleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_naturalclients_vehicleleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropIndex(
                name: "ix_leasecontracts_propertyleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropIndex(
                name: "ix_leasecontracts_propertyleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropIndex(
                name: "ix_leasecontracts_vehicleleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropColumn(
                name: "propertyleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropColumn(
                name: "propertyleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropColumn(
                name: "vehicleleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.RenameColumn(
                name: "vehicleleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                newName: "clientid");

            migrationBuilder.RenameIndex(
                name: "ix_leasecontracts_vehicleleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                newName: "ix_leasecontracts_clientid");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_legalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "clientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalclients",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_naturalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "clientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalclients",
                principalColumn: "id");
        }
    }
}
