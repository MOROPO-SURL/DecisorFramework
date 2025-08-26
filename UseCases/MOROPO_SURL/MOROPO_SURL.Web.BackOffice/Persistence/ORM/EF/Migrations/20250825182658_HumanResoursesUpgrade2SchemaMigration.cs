using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResoursesUpgrade2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_ocupations_ocupationid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_ocupations_employees_employeeid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropForeignKey(
                name: "fk_ocupations_workforces_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropIndex(
                name: "ix_ocupations_employeeid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropIndex(
                name: "ix_ocupations_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_employmentcontracts",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "employeeid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropColumn(
                name: "workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.RenameColumn(
                name: "number",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "number",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "number",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "number",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ocupationid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "vacantid");

            migrationBuilder.RenameColumn(
                name: "number",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ix_employmentcontracts_ocupationid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "ix_employmentcontracts_vacantid");

            migrationBuilder.AddColumn<int>(
                name: "contractid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "staffid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "pk_employmentcontracts",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_contractid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "contractid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_id_year",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                columns: new[] { "id", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_staffid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "staffid");

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_employees_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "employeeid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_staffs_staffid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staffs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_vacants_vacantid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_ocupations_employmentcontracts_contractid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "contractid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employmentcontracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_employees_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_staffs_staffid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_vacants_vacantid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_ocupations_employmentcontracts_contractid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropIndex(
                name: "ix_ocupations_contractid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_employmentcontracts",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropIndex(
                name: "ix_employmentcontracts_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropIndex(
                name: "ix_employmentcontracts_id_year",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropIndex(
                name: "ix_employmentcontracts_staffid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "contractid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropColumn(
                name: "employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "staffid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "vacantid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "ocupationid");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "number");

            migrationBuilder.RenameIndex(
                name: "ix_employmentcontracts_vacantid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "ix_employmentcontracts_ocupationid");

            migrationBuilder.AddColumn<Guid>(
                name: "employeeid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "number",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_employmentcontracts",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                columns: new[] { "number", "year" });

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_employeeid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "workforceid");

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_ocupations_ocupationid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "ocupationid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "ocupations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_ocupations_employees_employeeid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "employeeid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_ocupations_workforces_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "workforceid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
