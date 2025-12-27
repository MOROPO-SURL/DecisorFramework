using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IDiUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "decisoriscamaguey_idi",
                table: "projectspecificobjectives",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisoriscamaguey_idi",
                table: "projectspecificobjectives",
                type: "character varying(2550)",
                maxLength: 2550,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "summary",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(2550)",
                maxLength: 2550,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "problem",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(5100)",
                maxLength: 5100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "mainobjetive",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "context",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(5100)",
                maxLength: 5100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "beneficiary",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(2550)",
                maxLength: 2550,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "documentid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                type: "character varying(5100)",
                maxLength: 5100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "programid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_projects_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_projectproposals_callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "callforpropousalid");

            migrationBuilder.CreateIndex(
                name: "ix_projectproposals_programid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "programid");

            migrationBuilder.AddForeignKey(
                name: "fk_projectproposals_callforpropousals_callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "callforpropousalid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "callforpropousals",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_projectproposals_programs_programid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "programid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "programs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_projects_documents_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "documentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projectproposals_callforpropousals_callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals");

            migrationBuilder.DropForeignKey(
                name: "fk_projectproposals_programs_programid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals");

            migrationBuilder.DropForeignKey(
                name: "fk_projects_documents_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "ix_projects_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "ix_projectproposals_callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals");

            migrationBuilder.DropIndex(
                name: "ix_projectproposals_programid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals");

            migrationBuilder.DropColumn(
                name: "documentid",
                schema: "decisoriscamaguey_idi",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals");

            migrationBuilder.DropColumn(
                name: "programid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "decisoriscamaguey_idi",
                table: "projectspecificobjectives",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisoriscamaguey_idi",
                table: "projectspecificobjectives",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2550)",
                oldMaxLength: 2550,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "summary",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2550)",
                oldMaxLength: 2550);

            migrationBuilder.AlterColumn<string>(
                name: "problem",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5100)",
                oldMaxLength: 5100);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "mainobjetive",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "context",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5100)",
                oldMaxLength: 5100);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "beneficiary",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2550)",
                oldMaxLength: 2550);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5100)",
                oldMaxLength: 5100,
                oldNullable: true);
        }
    }
}
