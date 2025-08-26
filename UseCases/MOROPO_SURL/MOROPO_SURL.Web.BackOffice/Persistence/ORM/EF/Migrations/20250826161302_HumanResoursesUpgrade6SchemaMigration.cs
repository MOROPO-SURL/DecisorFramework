using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResoursesUpgrade6SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duration",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts");

            migrationBuilder.DropColumn(
                name: "duration",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts");

            migrationBuilder.DropColumn(
                name: "duration",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts");

            migrationBuilder.DropColumn(
                name: "duration",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts");

            migrationBuilder.DropColumn(
                name: "duration",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.AddColumn<int>(
                name: "durationunitcount",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "durationunitmeasurekind",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "durationunitcount",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "durationunitmeasurekind",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "durationunitcount",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "durationunitmeasurekind",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "durationunitcount",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "durationunitmeasurekind",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "durationunitcount",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "durationunitmeasurekind",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "durationunitcount",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts");

            migrationBuilder.DropColumn(
                name: "durationunitmeasurekind",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts");

            migrationBuilder.DropColumn(
                name: "durationunitcount",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts");

            migrationBuilder.DropColumn(
                name: "durationunitmeasurekind",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts");

            migrationBuilder.DropColumn(
                name: "durationunitcount",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts");

            migrationBuilder.DropColumn(
                name: "durationunitmeasurekind",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts");

            migrationBuilder.DropColumn(
                name: "durationunitcount",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts");

            migrationBuilder.DropColumn(
                name: "durationunitmeasurekind",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts");

            migrationBuilder.DropColumn(
                name: "durationunitcount",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "durationunitmeasurekind",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
