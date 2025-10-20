using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade6SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "participatingorganizationresearchareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participatingorganizationresearchareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_participatingorganizationresearchareabridges_participatingo~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "participatingorganizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_participatingorganizationresearchareabridges_researchareas_~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_participatingorganizationresearchareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "participatingorganizationresearchareabridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "participatingorganizationresearchareabridges",
                schema: "decisoriscamaguey_idi");
        }
    }
}
