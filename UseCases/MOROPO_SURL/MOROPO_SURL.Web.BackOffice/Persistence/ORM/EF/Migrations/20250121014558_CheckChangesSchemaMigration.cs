using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class CheckChangesSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_personidentities_identityid",
                schema: "decisorframework_humanresources",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviders_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropIndex(
                name: "ix_naturalproviders_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropColumn(
                name: "personalidentificationnumber",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropColumn(
                name: "personalidentificationnumber",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropColumn(
                name: "personalidentificationnumber",
                schema: "decisorframework_humanresources",
                table: "employees");

            migrationBuilder.RenameTable(
                name: "naturalbusinesskinds",
                schema: "decisorframework_commercial",
                newName: "naturalbusinesskinds",
                newSchema: "decisorframework_domain");

            migrationBuilder.RenameTable(
                name: "legalbusinesskinds",
                schema: "decisorframework_commercial",
                newName: "legalbusinesskinds",
                newSchema: "decisorframework_domain");

            migrationBuilder.RenameTable(
                name: "contacts",
                schema: "decisorframework_commercial",
                newName: "contacts",
                newSchema: "decisorframework_domain");

            migrationBuilder.RenameColumn(
                name: "identityid",
                schema: "decisorframework_humanresources",
                table: "employees",
                newName: "contactid");

            migrationBuilder.RenameIndex(
                name: "ix_employees_identityid",
                schema: "decisorframework_humanresources",
                table: "employees",
                newName: "ix_employees_contactid");

            migrationBuilder.AddColumn<string>(
                name: "personalidentificationnumber",
                schema: "decisorframework_domain",
                table: "contacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_employees_contacts_contactid",
                schema: "decisorframework_humanresources",
                table: "employees",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_contacts_contactid",
                schema: "decisorframework_humanresources",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "personalidentificationnumber",
                schema: "decisorframework_domain",
                table: "contacts");

            migrationBuilder.RenameTable(
                name: "naturalbusinesskinds",
                schema: "decisorframework_domain",
                newName: "naturalbusinesskinds",
                newSchema: "decisorframework_commercial");

            migrationBuilder.RenameTable(
                name: "legalbusinesskinds",
                schema: "decisorframework_domain",
                newName: "legalbusinesskinds",
                newSchema: "decisorframework_commercial");

            migrationBuilder.RenameTable(
                name: "contacts",
                schema: "decisorframework_domain",
                newName: "contacts",
                newSchema: "decisorframework_commercial");

            migrationBuilder.RenameColumn(
                name: "contactid",
                schema: "decisorframework_humanresources",
                table: "employees",
                newName: "identityid");

            migrationBuilder.RenameIndex(
                name: "ix_employees_contactid",
                schema: "decisorframework_humanresources",
                table: "employees",
                newName: "ix_employees_identityid");

            migrationBuilder.AddColumn<Guid>(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "personalidentificationnumber",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "personalidentificationnumber",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "personalidentificationnumber",
                schema: "decisorframework_humanresources",
                table: "employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviders_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "businesskindid");

            migrationBuilder.AddForeignKey(
                name: "fk_employees_personidentities_identityid",
                schema: "decisorframework_humanresources",
                table: "employees",
                column: "identityid",
                principalSchema: "guamaframework_identity",
                principalTable: "personidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviders_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "businesskindid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
