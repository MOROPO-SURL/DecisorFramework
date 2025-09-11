using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientvehicleleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientpropertyleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasings",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientvehicleleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientpropertyleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasings",
                column: "agreementid");

            migrationBuilder.AddForeignKey(
                name: "fk_legalclientpropertyleasings_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasings",
                column: "agreementid",
                principalSchema: "decisorframework_governance",
                principalTable: "agreements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalclientvehicleleasings_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings",
                column: "agreementid",
                principalSchema: "decisorframework_governance",
                principalTable: "agreements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalclientpropertyleasings_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasings",
                column: "agreementid",
                principalSchema: "decisorframework_governance",
                principalTable: "agreements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalclientvehicleleasings_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings",
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
                name: "fk_legalclientpropertyleasings_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasings");

            migrationBuilder.DropForeignKey(
                name: "fk_legalclientvehicleleasings_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalclientpropertyleasings_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasings");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalclientvehicleleasings_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings");

            migrationBuilder.DropIndex(
                name: "ix_naturalclientvehicleleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings");

            migrationBuilder.DropIndex(
                name: "ix_naturalclientpropertyleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasings");

            migrationBuilder.DropIndex(
                name: "ix_legalclientvehicleleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings");

            migrationBuilder.DropIndex(
                name: "ix_legalclientpropertyleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasings");

            migrationBuilder.DropColumn(
                name: "agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings");

            migrationBuilder.DropColumn(
                name: "agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasings");

            migrationBuilder.DropColumn(
                name: "agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings");

            migrationBuilder.DropColumn(
                name: "agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasings");
        }
    }
}
