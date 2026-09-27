using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendServicing4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "trainingresults");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "trainingresults");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "awardresults");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "trainingresults",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "trainingresults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "thesisresults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
