using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LinebaseUpdate2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "at",
                schema: "decisorframework_domain",
                table: "academicachievements",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "institution",
                schema: "decisorframework_domain",
                table: "academicachievements",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                schema: "decisorframework_domain",
                table: "academicachievements",
                type: "character varying(512)",
                maxLength: 512,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "at",
                schema: "decisorframework_domain",
                table: "academicachievements");

            migrationBuilder.DropColumn(
                name: "institution",
                schema: "decisorframework_domain",
                table: "academicachievements");

            migrationBuilder.DropColumn(
                name: "title",
                schema: "decisorframework_domain",
                table: "academicachievements");
        }
    }
}
