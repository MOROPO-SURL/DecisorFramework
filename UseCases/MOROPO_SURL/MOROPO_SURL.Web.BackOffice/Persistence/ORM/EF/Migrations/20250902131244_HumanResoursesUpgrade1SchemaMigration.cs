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
                name: "candidateid",
                table: "resolutions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_candidateid",
                table: "resolutions",
                column: "candidateid");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_ocupationcandidates_candidateid",
                table: "resolutions",
                column: "candidateid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "ocupationcandidates",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_ocupationcandidates_candidateid",
                table: "resolutions");

            migrationBuilder.DropIndex(
                name: "ix_resolutions_candidateid",
                table: "resolutions");

            migrationBuilder.DropColumn(
                name: "candidateid",
                table: "resolutions");
        }
    }
}
