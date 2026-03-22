using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendIDi3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "kindid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "programkinds",
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
                    table.PrimaryKey("pk_programkinds", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_programs_kindid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                column: "kindid");

            migrationBuilder.AddForeignKey(
                name: "fk_programs_programkinds_kindid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                column: "kindid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "programkinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_programs_programkinds_kindid",
                schema: "decisoriscamaguey_idi",
                table: "programs");

            migrationBuilder.DropTable(
                name: "programkinds",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropIndex(
                name: "ix_programs_kindid",
                schema: "decisoriscamaguey_idi",
                table: "programs");

            migrationBuilder.DropColumn(
                name: "kindid",
                schema: "decisoriscamaguey_idi",
                table: "programs");
        }
    }
}
