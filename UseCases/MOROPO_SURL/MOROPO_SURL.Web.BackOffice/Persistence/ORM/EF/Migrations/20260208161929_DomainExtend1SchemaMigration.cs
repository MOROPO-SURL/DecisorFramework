using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainExtend1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "at",
                schema: "decisorframework_domain",
                table: "changenotifications");

            migrationBuilder.AddColumn<DateTime>(
                name: "at",
                schema: "decisorframework_domain",
                table: "changenotificationuserbridges",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "at",
                schema: "decisorframework_domain",
                table: "changenotificationuserbridges");

            migrationBuilder.AddColumn<DateTime>(
                name: "at",
                schema: "decisorframework_domain",
                table: "changenotifications",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
