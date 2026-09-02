using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "workplanproductionsamplebridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workplanproductionsamplebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workplanproductionsamplebridges_samples_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workplanproductionsamplebridges_workplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workplanresearchsamplebridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workplanresearchsamplebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workplanresearchsamplebridges_samples_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workplanresearchsamplebridges_workplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workplanserviceordersamplebridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workplanserviceordersamplebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workplanserviceordersamplebridges_samples_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workplanserviceordersamplebridges_workplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_workplanproductionsamplebridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "workplanproductionsamplebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_workplanresearchsamplebridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "workplanresearchsamplebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_workplanserviceordersamplebridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "workplanserviceordersamplebridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workplanproductionsamplebridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workplanresearchsamplebridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workplanserviceordersamplebridges",
                schema: "decisoriscamaguey_lab");
        }
    }
}
