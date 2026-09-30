using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendServicing3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresultintroductions");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresultintroductions");

            migrationBuilder.AddColumn<DateTime>(
                name: "at",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresultintroductions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "scientifictechnicalresultintroductionemployeebridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scientifictechnicalresultintroductionemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_scientifictechnicalresultintroductionemployeebridges_employ~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_scientifictechnicalresultintroductionemployeebridges_scient~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "scientifictechnicalresultintroductions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_scientifictechnicalresultintroductionemployeebridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresultintroductionemployeebridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scientifictechnicalresultintroductionemployeebridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropColumn(
                name: "at",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresultintroductions");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresultintroductions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresultintroductions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
