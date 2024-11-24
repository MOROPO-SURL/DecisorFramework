using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class EvolutionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_advances_employees_responsibleid",
                schema: "decisorframework_finantial",
                table: "advances");

            migrationBuilder.DropIndex(
                name: "ix_advances_responsibleid",
                schema: "decisorframework_finantial",
                table: "advances");

            migrationBuilder.DropColumn(
                name: "responsibleid",
                schema: "decisorframework_finantial",
                table: "advances");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_humanresources");

            migrationBuilder.RenameTable(
                name: "unitmeasurements",
                schema: "decisorframework_essential",
                newName: "unitmeasurements",
                newSchema: "decisorframework_inventory");

            migrationBuilder.RenameTable(
                name: "unitmeasurementconversionbridges",
                schema: "decisorframework_essential",
                newName: "unitmeasurementconversionbridges",
                newSchema: "decisorframework_inventory");

            migrationBuilder.RenameTable(
                name: "employmentcontracts",
                schema: "decisorframework_essential",
                newName: "employmentcontracts",
                newSchema: "decisorframework_humanresources");

            migrationBuilder.RenameTable(
                name: "employees",
                schema: "decisorframework_essential",
                newName: "employees",
                newSchema: "decisorframework_humanresources");

            migrationBuilder.RenameTable(
                name: "bankbranches",
                schema: "decisorframework_essential",
                newName: "bankbranches",
                newSchema: "decisorframework_finantial");

            migrationBuilder.RenameTable(
                name: "bankagencies",
                schema: "decisorframework_essential",
                newName: "bankagencies",
                newSchema: "decisorframework_finantial");

            migrationBuilder.RenameTable(
                name: "bankaccounts",
                schema: "decisorframework_essential",
                newName: "bankaccounts",
                newSchema: "decisorframework_finantial");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_purchasing",
                table: "naturalproviderpurchasingcontracts",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_sales",
                table: "naturalclientsalecontracts",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_purchasing",
                table: "legalproviderpurchasingcontracts",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_sales",
                table: "legalclientsalecontracts",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "responsibleid",
                schema: "decisorframework_purchasing",
                table: "advances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_advances_responsibleid",
                schema: "decisorframework_purchasing",
                table: "advances",
                column: "responsibleid");

            migrationBuilder.AddForeignKey(
                name: "fk_advances_employees_responsibleid",
                schema: "decisorframework_purchasing",
                table: "advances",
                column: "responsibleid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_advances_employees_responsibleid",
                schema: "decisorframework_purchasing",
                table: "advances");

            migrationBuilder.DropIndex(
                name: "ix_advances_responsibleid",
                schema: "decisorframework_purchasing",
                table: "advances");

            migrationBuilder.DropColumn(
                name: "responsibleid",
                schema: "decisorframework_purchasing",
                table: "advances");

            migrationBuilder.RenameTable(
                name: "unitmeasurements",
                schema: "decisorframework_inventory",
                newName: "unitmeasurements",
                newSchema: "decisorframework_essential");

            migrationBuilder.RenameTable(
                name: "unitmeasurementconversionbridges",
                schema: "decisorframework_inventory",
                newName: "unitmeasurementconversionbridges",
                newSchema: "decisorframework_essential");

            migrationBuilder.RenameTable(
                name: "employmentcontracts",
                schema: "decisorframework_humanresources",
                newName: "employmentcontracts",
                newSchema: "decisorframework_essential");

            migrationBuilder.RenameTable(
                name: "employees",
                schema: "decisorframework_humanresources",
                newName: "employees",
                newSchema: "decisorframework_essential");

            migrationBuilder.RenameTable(
                name: "bankbranches",
                schema: "decisorframework_finantial",
                newName: "bankbranches",
                newSchema: "decisorframework_essential");

            migrationBuilder.RenameTable(
                name: "bankagencies",
                schema: "decisorframework_finantial",
                newName: "bankagencies",
                newSchema: "decisorframework_essential");

            migrationBuilder.RenameTable(
                name: "bankaccounts",
                schema: "decisorframework_finantial",
                newName: "bankaccounts",
                newSchema: "decisorframework_essential");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_purchasing",
                table: "naturalproviderpurchasingcontracts",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_sales",
                table: "naturalclientsalecontracts",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_purchasing",
                table: "legalproviderpurchasingcontracts",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_sales",
                table: "legalclientsalecontracts",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AddColumn<Guid>(
                name: "responsibleid",
                schema: "decisorframework_finantial",
                table: "advances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "duration",
                schema: "decisorframework_essential",
                table: "employmentcontracts",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.CreateIndex(
                name: "ix_advances_responsibleid",
                schema: "decisorframework_finantial",
                table: "advances",
                column: "responsibleid");

            migrationBuilder.AddForeignKey(
                name: "fk_advances_employees_responsibleid",
                schema: "decisorframework_finantial",
                table: "advances",
                column: "responsibleid",
                principalSchema: "decisorframework_essential",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
