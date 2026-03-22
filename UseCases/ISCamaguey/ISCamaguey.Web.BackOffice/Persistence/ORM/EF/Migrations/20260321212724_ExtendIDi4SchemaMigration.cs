using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendIDi4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "summary",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2550)",
                oldMaxLength: 2550);

            migrationBuilder.AlterColumn<string>(
                name: "problem",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5100)",
                oldMaxLength: 5100);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "mainobjetive",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(360)",
                oldMaxLength: 360);

            migrationBuilder.AlterColumn<string>(
                name: "context",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(500000)",
                maxLength: 500000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5100)",
                oldMaxLength: 5100);

            migrationBuilder.AlterColumn<string>(
                name: "beneficiary",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(5000)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2550)",
                oldMaxLength: 2550);

            migrationBuilder.CreateTable(
                name: "impactdimensions",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_impactdimensions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projectprogramexpectresultbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectprogramexpectresultbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_projectprogramexpectresultbridges_programexpectresults_ster~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "programexpectresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectprogramexpectresultbridges_projects_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectimpacts",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    dimensionid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true),
                    projectid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectimpacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_projectimpacts_impactdimensions_dimensionid",
                        column: x => x.dimensionid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "impactdimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectimpacts_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_projectimpacts_dimensionid",
                schema: "decisoriscamaguey_idi",
                table: "projectimpacts",
                column: "dimensionid");

            migrationBuilder.CreateIndex(
                name: "ix_projectimpacts_projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectimpacts",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_projectprogramexpectresultbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectprogramexpectresultbridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projectimpacts",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectprogramexpectresultbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "impactdimensions",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.AlterColumn<string>(
                name: "summary",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(2550)",
                maxLength: 2550,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5000)",
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<string>(
                name: "problem",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(5100)",
                maxLength: 5100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10000)",
                oldMaxLength: 10000);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "mainobjetive",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(360)",
                maxLength: 360,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "context",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(5100)",
                maxLength: 5100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500000)",
                oldMaxLength: 500000);

            migrationBuilder.AlterColumn<string>(
                name: "beneficiary",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                type: "character varying(2550)",
                maxLength: 2550,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5000)",
                oldMaxLength: 5000);
        }
    }
}
