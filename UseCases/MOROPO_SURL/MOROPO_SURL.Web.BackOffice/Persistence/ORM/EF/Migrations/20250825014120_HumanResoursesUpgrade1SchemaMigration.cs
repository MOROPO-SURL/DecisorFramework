using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResoursesUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "staffid",
                table: "resolutions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_staffid",
                table: "resolutions",
                column: "staffid");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions",
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
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions");

            migrationBuilder.DropIndex(
                name: "ix_resolutions_staffid",
                table: "resolutions");

            migrationBuilder.DropColumn(
                name: "staffid",
                table: "resolutions");
        }
    }
}
