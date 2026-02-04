using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainExtend2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "changenotifications",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    reference = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_changenotifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "changenotificationuserbridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<string>(type: "text", nullable: false),
                    readedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_changenotificationuserbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_changenotificationuserbridges_changenotifications_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "changenotifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_changenotificationuserbridges_users_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_security_personal",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_changenotificationuserbridges_sternid",
                schema: "decisorframework_domain",
                table: "changenotificationuserbridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "changenotificationuserbridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "changenotifications",
                schema: "decisorframework_domain");
        }
    }
}
