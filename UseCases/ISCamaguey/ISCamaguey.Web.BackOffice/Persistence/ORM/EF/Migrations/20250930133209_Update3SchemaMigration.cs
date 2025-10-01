using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class Update3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projects_projectproposals_proposalid",
                schema: "decisoriscamaguey_idi",
                table: "projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "proposalid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "alias",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "chiefid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "managerid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_programs_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                column: "chiefid");

            migrationBuilder.CreateIndex(
                name: "ix_programs_managerid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                column: "managerid");

            migrationBuilder.AddForeignKey(
                name: "fk_programs_organizationcontacts_managerid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                column: "managerid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_programs_personcontacts_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                column: "chiefid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_projects_projectproposals_proposalid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "proposalid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "projectproposals",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_programs_organizationcontacts_managerid",
                schema: "decisoriscamaguey_idi",
                table: "programs");

            migrationBuilder.DropForeignKey(
                name: "fk_programs_personcontacts_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "programs");

            migrationBuilder.DropForeignKey(
                name: "fk_projects_projectproposals_proposalid",
                schema: "decisoriscamaguey_idi",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "ix_programs_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "programs");

            migrationBuilder.DropIndex(
                name: "ix_programs_managerid",
                schema: "decisoriscamaguey_idi",
                table: "programs");

            migrationBuilder.DropColumn(
                name: "alias",
                schema: "decisoriscamaguey_idi",
                table: "programs");

            migrationBuilder.DropColumn(
                name: "chiefid",
                schema: "decisoriscamaguey_idi",
                table: "programs");

            migrationBuilder.DropColumn(
                name: "managerid",
                schema: "decisoriscamaguey_idi",
                table: "programs");

            migrationBuilder.AlterColumn<Guid>(
                name: "proposalid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_projects_projectproposals_proposalid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "proposalid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "projectproposals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
