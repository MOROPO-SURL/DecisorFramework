using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IDiUpgrade3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projectproposals_callforpropousals_callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals");

            migrationBuilder.DropTable(
                name: "callforpropousaldocumentbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "callforpropousalresearchareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "callforpropousals",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                type: "character varying(5100)",
                maxLength: 5100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5100)",
                oldMaxLength: 5100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "callforproposals",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    financierid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforproposals", x => x.id);
                    table.ForeignKey(
                        name: "fk_callforproposals_financiers_financierid",
                        column: x => x.financierid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "callforproposaldocumentbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforproposaldocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_callforproposaldocumentbridges_callforproposals_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforproposals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_callforproposaldocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "callforproposalresearchareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforproposalresearchareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_callforproposalresearchareabridges_callforproposals_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforproposals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_callforproposalresearchareabridges_researchareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_callforproposaldocumentbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "callforproposaldocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_callforproposalresearchareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "callforproposalresearchareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_callforproposals_financierid",
                schema: "decisoriscamaguey_idi",
                table: "callforproposals",
                column: "financierid");

            migrationBuilder.AddForeignKey(
                name: "fk_projectproposals_callforproposals_callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "callforpropousalid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "callforproposals",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_projectproposals_callforproposals_callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals");

            migrationBuilder.DropTable(
                name: "callforproposaldocumentbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "callforproposalresearchareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "callforproposals",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                type: "character varying(5100)",
                maxLength: 5100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5100)",
                oldMaxLength: 5100);

            migrationBuilder.CreateTable(
                name: "callforpropousals",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    financierid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforpropousals", x => x.id);
                    table.ForeignKey(
                        name: "fk_callforpropousals_financiers_financierid",
                        column: x => x.financierid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "callforpropousaldocumentbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforpropousaldocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_callforpropousaldocumentbridges_callforpropousals_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforpropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_callforpropousaldocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "callforpropousalresearchareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforpropousalresearchareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_callforpropousalresearchareabridges_callforpropousals_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforpropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_callforpropousalresearchareabridges_researchareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_callforpropousaldocumentbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "callforpropousaldocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_callforpropousalresearchareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "callforpropousalresearchareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_callforpropousals_financierid",
                schema: "decisoriscamaguey_idi",
                table: "callforpropousals",
                column: "financierid");

            migrationBuilder.AddForeignKey(
                name: "fk_projectproposals_callforpropousals_callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "callforpropousalid",
                principalSchema: "decisoriscamaguey_idi",
                principalTable: "callforpropousals",
                principalColumn: "id");
        }
    }
}
