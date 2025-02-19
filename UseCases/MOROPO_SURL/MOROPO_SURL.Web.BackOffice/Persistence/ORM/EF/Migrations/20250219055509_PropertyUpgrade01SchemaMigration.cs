using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PropertyUpgrade01SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "propertyrecordidentifier",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "reference");

            migrationBuilder.RenameIndex(
                name: "ix_properties_propertyrecordidentifier",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "ix_properties_reference");

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "decisorframework_domain",
                table: "properties",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.RenameColumn(
                name: "reference",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "propertyrecordidentifier");

            migrationBuilder.RenameIndex(
                name: "ix_properties_reference",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "ix_properties_propertyrecordidentifier");
        }
    }
}
