using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class OcupationCompleteSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "workforceid");

            migrationBuilder.AddForeignKey(
                name: "fk_ocupations_workforces_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "workforceid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_ocupations_workforces_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropIndex(
                name: "ix_ocupations_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations");

            migrationBuilder.DropColumn(
                name: "workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations");
        }
    }
}
