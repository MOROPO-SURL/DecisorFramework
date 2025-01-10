using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResourcesRedefine03SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_workforces_structures_structureid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropIndex(
                name: "ix_workforces_structureid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropColumn(
                name: "structureid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunitybridges",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunitybridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunitybridges_organizationalunities_s~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunitybridges_workforces_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunitybridges_sternid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workforceorganizationalunitybridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.AddColumn<Guid>(
                name: "structureid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_workforces_structureid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "structureid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_workforces_structures_structureid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
