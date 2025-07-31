using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeaseOfferExtendSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "openat",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "approvationreference",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "authorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "decisorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "openat",
                schema: "decisorframework_production",
                table: "propertyleaseoffers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "approvationreference",
                schema: "decisorframework_production",
                table: "propertyleaseoffers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "authorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "decisorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseoffers_authorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseoffers_decisorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers",
                column: "decisorid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseoffers_authorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseoffers_decisorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers",
                column: "decisorid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseoffers_employees_authorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers",
                column: "authorid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseoffers_employees_decisorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers",
                column: "decisorid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseoffers_employees_authorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers",
                column: "authorid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseoffers_employees_decisorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers",
                column: "decisorid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employees",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseoffers_employees_authorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseoffers_employees_decisorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseoffers_employees_authorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseoffers_employees_decisorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleaseoffers_authorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleaseoffers_decisorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers");

            migrationBuilder.DropIndex(
                name: "ix_propertyleaseoffers_authorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers");

            migrationBuilder.DropIndex(
                name: "ix_propertyleaseoffers_decisorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers");

            migrationBuilder.DropColumn(
                name: "approvationreference",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers");

            migrationBuilder.DropColumn(
                name: "authorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers");

            migrationBuilder.DropColumn(
                name: "decisorid",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers");

            migrationBuilder.DropColumn(
                name: "approvationreference",
                schema: "decisorframework_production",
                table: "propertyleaseoffers");

            migrationBuilder.DropColumn(
                name: "authorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers");

            migrationBuilder.DropColumn(
                name: "decisorid",
                schema: "decisorframework_production",
                table: "propertyleaseoffers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "openat",
                schema: "decisorframework_production",
                table: "vehicleleaseoffers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "openat",
                schema: "decisorframework_production",
                table: "propertyleaseoffers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
