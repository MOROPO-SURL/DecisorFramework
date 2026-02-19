using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainExtend4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organizationalstructureunities",
                schema: "decisorframework_domain");

            migrationBuilder.AddColumn<Guid>(
                name: "structuringunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "organizationalstructuringunities",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    unitid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    reference = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalstructuringunities", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalstructuringunities_organizationalstructuringu~",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructuringunities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationalstructuringunities_organizationalunities_unit~",
                        column: x => x.unitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructures_structuringunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "structuringunitid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructuringunities_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructuringunities_unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities",
                column: "unitid");

            migrationBuilder.AddForeignKey(
                name: "fk_organizationalstructures_organizationalstructuringunities_s~",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "structuringunitid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalstructuringunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizationalstructures_organizationalstructuringunities_s~",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropTable(
                name: "organizationalstructuringunities",
                schema: "decisorframework_domain");

            migrationBuilder.DropIndex(
                name: "ix_organizationalstructures_structuringunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropColumn(
                name: "structuringunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.CreateTable(
                name: "organizationalstructureunities",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitid = table.Column<Guid>(type: "uuid", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalstructureunities", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalstructureunities_organizationalstructures_par~",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationalstructureunities_organizationalstructures_str~",
                        column: x => x.structureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationalstructureunities_organizationalstructureuniti~",
                        column: x => x.unitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructureunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructureunities_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructureunities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructureunities_structureid",
                schema: "decisorframework_domain",
                table: "organizationalstructureunities",
                column: "structureid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructureunities_unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructureunities",
                column: "unitid");
        }
    }
}
