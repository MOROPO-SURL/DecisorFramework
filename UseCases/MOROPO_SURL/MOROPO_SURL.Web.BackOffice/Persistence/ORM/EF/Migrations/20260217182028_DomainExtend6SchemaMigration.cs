using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainExtend6SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizationalstructures_organizationalstructuringunities_s~",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationalstructuringunities_organizationalunities_unit~",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities");

            migrationBuilder.RenameColumn(
                name: "unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities",
                newName: "organizationalunityid");

            migrationBuilder.RenameIndex(
                name: "ix_organizationalstructuringunities_unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities",
                newName: "ix_organizationalstructuringunities_organizationalunityid");

            migrationBuilder.RenameColumn(
                name: "structuringunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                newName: "rootstructuringunityid");

            migrationBuilder.RenameIndex(
                name: "ix_organizationalstructures_structuringunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                newName: "ix_organizationalstructures_rootstructuringunityid");

            migrationBuilder.AddForeignKey(
                name: "fk_organizationalstructures_organizationalstructuringunities_r~",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "rootstructuringunityid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalstructuringunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationalstructuringunities_organizationalunities_orga~",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities",
                column: "organizationalunityid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizationalstructures_organizationalstructuringunities_r~",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationalstructuringunities_organizationalunities_orga~",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities");

            migrationBuilder.RenameColumn(
                name: "organizationalunityid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities",
                newName: "unitid");

            migrationBuilder.RenameIndex(
                name: "ix_organizationalstructuringunities_organizationalunityid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities",
                newName: "ix_organizationalstructuringunities_unitid");

            migrationBuilder.RenameColumn(
                name: "rootstructuringunityid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                newName: "structuringunitid");

            migrationBuilder.RenameIndex(
                name: "ix_organizationalstructures_rootstructuringunityid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                newName: "ix_organizationalstructures_structuringunitid");

            migrationBuilder.AddForeignKey(
                name: "fk_organizationalstructures_organizationalstructuringunities_s~",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "structuringunitid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalstructuringunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationalstructuringunities_organizationalunities_unit~",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities",
                column: "unitid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
