using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.CITMACamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LinebaseUpdate2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "workingdaycount",
                schema: "decisorframework_humanresources",
                table: "staffs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "skinkind",
                schema: "decisorframework_domain",
                table: "personcontacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "workingdaycount",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.DropColumn(
                name: "skinkind",
                schema: "decisorframework_domain",
                table: "personcontacts");
        }
    }
}
