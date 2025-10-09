using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HHRRUpgrade2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_workforceorganizationalunitybridges_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges");

            migrationBuilder.DropIndex(
                name: "ix_workforceorganizationalunitybridges_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges");

            migrationBuilder.DropColumn(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges");

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunityvacantbridges",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationalunityid = table.Column<Guid>(type: "uuid", nullable: false),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunityvacantbridges", x => new { x.workforceid, x.organizationalunityid, x.vacantid });
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridges_organizationaluni~",
                        column: x => x.organizationalunityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridges_vacants_vacantid",
                        column: x => x.vacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridges_workforces_workfo~",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunityvacantbridges_organizationaluni~",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridges",
                column: "organizationalunityid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunityvacantbridges_vacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridges",
                column: "vacantid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workforceorganizationalunityvacantbridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.AddColumn<Guid>(
                name: "chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunitybridges_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges",
                column: "chiefvacantid");

            migrationBuilder.AddForeignKey(
                name: "fk_workforceorganizationalunitybridges_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges",
                column: "chiefvacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id");
        }
    }
}
