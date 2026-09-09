using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab5SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_analysises_analysisorders_orderid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropTable(
                name: "analysisorders",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.RenameColumn(
                name: "orderid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                newName: "sampleid");

            migrationBuilder.RenameIndex(
                name: "ix_analysises_orderid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                newName: "ix_analysises_sampleid");

            migrationBuilder.AddColumn<Guid>(
                name: "workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_analysises_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "workplanid");

            migrationBuilder.AddForeignKey(
                name: "fk_analysises_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "sampleid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "samples",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_analysises_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "workplanid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "workplans",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_analysises_samples_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropForeignKey(
                name: "fk_analysises_workplans_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropIndex(
                name: "ix_analysises_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropColumn(
                name: "workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.RenameColumn(
                name: "sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                newName: "orderid");

            migrationBuilder.RenameIndex(
                name: "ix_analysises_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                newName: "ix_analysises_orderid");

            migrationBuilder.CreateTable(
                name: "analysisorders",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sampleid = table.Column<Guid>(type: "uuid", nullable: false),
                    techniqueid = table.Column<Guid>(type: "uuid", nullable: false),
                    workplanid = table.Column<Guid>(type: "uuid", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_analysisorders", x => x.id);
                    table.ForeignKey(
                        name: "fk_analysisorders_samples_sampleid",
                        column: x => x.sampleid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analysisorders_techniques_techniqueid",
                        column: x => x.techniqueid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analysisorders_workplans_workplanid",
                        column: x => x.workplanid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workplans",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_analysisorders_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysisorders",
                column: "sampleid");

            migrationBuilder.CreateIndex(
                name: "ix_analysisorders_techniqueid",
                schema: "decisoriscamaguey_lab",
                table: "analysisorders",
                column: "techniqueid");

            migrationBuilder.CreateIndex(
                name: "ix_analysisorders_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysisorders",
                column: "workplanid");

            migrationBuilder.AddForeignKey(
                name: "fk_analysises_analysisorders_orderid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "orderid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "analysisorders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
