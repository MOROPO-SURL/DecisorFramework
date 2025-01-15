using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendHumanResources03SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "staffid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "staffs",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    mainworkforceid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_staffs", x => x.id);
                    table.ForeignKey(
                        name: "fk_staffs_structures_structureid",
                        column: x => x.structureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_staffs_workforces_mainworkforceid",
                        column: x => x.mainworkforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffworkforcebridges",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_staffworkforcebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_staffworkforcebridges_staffs_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_staffworkforcebridges_workforces_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_staffid_vacantid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                columns: new[] { "staffid", "vacantid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_staffs_mainworkforceid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "mainworkforceid");

            migrationBuilder.CreateIndex(
                name: "ix_staffs_structureid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "structureid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_staffworkforcebridges_sternid",
                schema: "decisorframework_humanresources",
                table: "staffworkforcebridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_ocupations_staffs_staffid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staffs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_ocupations_staffs_staffid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropTable(
                name: "staffworkforcebridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "staffs",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropIndex(
                name: "ix_ocupations_staffid_vacantid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropColumn(
                name: "staffid",
                schema: "decisorframework_humanresources",
                table: "ocupations");
        }
    }
}
