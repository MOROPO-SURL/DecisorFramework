using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class MediumLeasingUpgradeSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseoffers_employees_authorid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseoffers_employees_decisorid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseoffers_employees_authorid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseoffers_employees_decisorid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleaseoffers_decisorid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropIndex(
                name: "ix_propertyleaseoffers_decisorid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.DropColumn(
                name: "approvationreference",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropColumn(
                name: "decisorid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropColumn(
                name: "approvationreference",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.DropColumn(
                name: "decisorid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.RenameColumn(
                name: "authorid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                newName: "agreementid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseoffers_authorid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                newName: "ix_vehicleleaseoffers_agreementid");

            migrationBuilder.RenameColumn(
                name: "authorid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                newName: "agreementid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseoffers_authorid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                newName: "ix_propertyleaseoffers_agreementid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "openat",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "openat",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseoffers_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "agreementid",
                principalSchema: "decisorframework_governance",
                principalTable: "agreements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseoffers_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
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
                name: "fk_propertyleaseoffers_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseoffers_agreements_agreementid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.RenameColumn(
                name: "agreementid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                newName: "authorid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseoffers_agreementid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                newName: "ix_vehicleleaseoffers_authorid");

            migrationBuilder.RenameColumn(
                name: "agreementid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                newName: "authorid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseoffers_agreementid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                newName: "ix_propertyleaseoffers_authorid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "openat",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "approvationreference",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "decisorid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "openat",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "approvationreference",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "decisorid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseoffers_decisorid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "decisorid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseoffers_decisorid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "decisorid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseoffers_employees_authorid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "authorid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseoffers_employees_decisorid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "decisorid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseoffers_employees_authorid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "authorid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseoffers_employees_decisorid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "decisorid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employees",
                principalColumn: "id");
        }
    }
}
