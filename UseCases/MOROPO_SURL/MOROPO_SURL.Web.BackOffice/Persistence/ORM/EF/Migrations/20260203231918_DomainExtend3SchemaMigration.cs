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
            migrationBuilder.DropColumn(
                name: "reference",
                schema: "decisorframework_domain",
                table: "changenotifications");

            migrationBuilder.AddColumn<string>(
                name: "cached",
                schema: "decisorframework_domain",
                table: "changenotifications",
                type: "character varying(10240)",
                maxLength: 10240,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "changekind",
                schema: "decisorframework_domain",
                table: "changenotifications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "entityname",
                schema: "decisorframework_domain",
                table: "changenotifications",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cached",
                schema: "decisorframework_domain",
                table: "changenotifications");

            migrationBuilder.DropColumn(
                name: "changekind",
                schema: "decisorframework_domain",
                table: "changenotifications");

            migrationBuilder.DropColumn(
                name: "entityname",
                schema: "decisorframework_domain",
                table: "changenotifications");

            migrationBuilder.AddColumn<string>(
                name: "reference",
                schema: "decisorframework_domain",
                table: "changenotifications",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
