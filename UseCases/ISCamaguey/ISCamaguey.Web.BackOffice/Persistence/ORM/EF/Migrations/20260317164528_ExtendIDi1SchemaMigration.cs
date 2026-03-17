using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendIDi1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "mainobjetive",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(360)",
                maxLength: 360,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "alias",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                type: "character varying(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "alias",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alias",
                schema: "decisoriscamaguey_idi",
                table: "projects");

            migrationBuilder.AlterColumn<string>(
                name: "mainobjetive",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(360)",
                oldMaxLength: 360);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(320)",
                oldMaxLength: 320);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "alias",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60,
                oldNullable: true);
        }
    }
}
