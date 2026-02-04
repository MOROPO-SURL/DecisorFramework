using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingExtend4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "drivelicenceidentifier",
                schema: "decisorframework_leasing",
                table: "natclientvehleaspersoncontactbridges",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "drivelicenceidentifier",
                schema: "decisorframework_leasing",
                table: "legclientvehleaspersoncontactbridges",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "drivelicenceidentifier",
                schema: "decisorframework_leasing",
                table: "natclientvehleaspersoncontactbridges");

            migrationBuilder.DropColumn(
                name: "drivelicenceidentifier",
                schema: "decisorframework_leasing",
                table: "legclientvehleaspersoncontactbridges");
        }
    }
}
