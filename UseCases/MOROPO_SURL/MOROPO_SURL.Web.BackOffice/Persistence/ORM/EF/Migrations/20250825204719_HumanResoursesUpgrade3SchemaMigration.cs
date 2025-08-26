using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResoursesUpgrade3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.AddColumn<Guid>(
                name: "admitionpropousalid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "interviewat",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_admitionpropousalid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "admitionpropousalid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "resolutionid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "responsibleid");

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_admitionpropousals_admitionpropousalid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "admitionpropousalid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "admitionpropousals",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_employees_responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "responsibleid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_resolutions_resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "resolutionid",
                principalTable: "resolutions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_admitionpropousals_admitionpropousalid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_employees_responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_resolutions_resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropIndex(
                name: "ix_employmentcontracts_admitionpropousalid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropIndex(
                name: "ix_employmentcontracts_resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropIndex(
                name: "ix_employmentcontracts_responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "admitionpropousalid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "discriminator",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "interviewat",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
