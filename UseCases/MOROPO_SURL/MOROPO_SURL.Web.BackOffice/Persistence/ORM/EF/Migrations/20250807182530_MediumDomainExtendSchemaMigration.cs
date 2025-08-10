using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class MediumDomainExtendSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "assignment",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.CreateTable(
                name: "propertyareas",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    assignment = table.Column<int>(type: "integer", nullable: true),
                    propertyid = table.Column<Guid>(type: "uuid", nullable: false),
                    featureimageid = table.Column<Guid>(type: "uuid", nullable: true),
                    area = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyareas", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyareas_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_propertyareas_properties_propertyid",
                        column: x => x.propertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_propertyareas_featureimageid",
                schema: "decisorframework_domain",
                table: "propertyareas",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyareas_propertyid",
                schema: "decisorframework_domain",
                table: "propertyareas",
                column: "propertyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "propertyareas",
                schema: "decisorframework_domain");

            migrationBuilder.AddColumn<int>(
                name: "assignment",
                schema: "decisorframework_domain",
                table: "properties",
                type: "integer",
                nullable: true);
        }
    }
}
