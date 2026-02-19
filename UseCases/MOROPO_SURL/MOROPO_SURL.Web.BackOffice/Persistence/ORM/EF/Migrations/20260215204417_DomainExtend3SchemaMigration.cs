using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainExtend3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizationalstructures_organizationalstructures_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationalstructures_organizationalunities_unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropIndex(
                name: "ix_organizationalstructures_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropIndex(
                name: "ix_organizationalstructures_unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropColumn(
                name: "parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropColumn(
                name: "reference",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropColumn(
                name: "unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "organizationalstructureunities",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organizationalstructureunities",
                schema: "decisorframework_domain");

            migrationBuilder.DropColumn(
                name: "name",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.AddColumn<Guid>(
                name: "parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reference",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructures_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructures_unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "unitid");

            migrationBuilder.AddForeignKey(
                name: "fk_organizationalstructures_organizationalstructures_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "parentid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalstructures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_organizationalstructures_organizationalunities_unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "unitid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
