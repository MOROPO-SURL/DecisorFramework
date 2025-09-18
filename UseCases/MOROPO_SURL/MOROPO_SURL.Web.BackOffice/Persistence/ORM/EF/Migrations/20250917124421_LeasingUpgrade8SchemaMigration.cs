using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade8SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "leasedat",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "leasedat",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                type: "timestamp without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "leasedat",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropColumn(
                name: "leasedat",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");
        }
    }
}
