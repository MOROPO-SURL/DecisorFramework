using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PropertyLeasingExtendSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "propertyspaceleasepropousals",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    propertyleasepropousalid = table.Column<Guid>(type: "uuid", nullable: false),
                    propertyspaceid = table.Column<Guid>(type: "uuid", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyspaceleasepropousals", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyspaceleasepropousals_propertyleasepropousals_proper~",
                        column: x => x.propertyleasepropousalid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasepropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyspaceleasepropousals_propertyspaces_propertyspaceid",
                        column: x => x.propertyspaceid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "propertyspaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_propertyspaceleasepropousals_propertyleasepropousalid_prope~",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals",
                columns: new[] { "propertyleasepropousalid", "propertyspaceid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_propertyspaceleasepropousals_propertyspaceid",
                schema: "decisorframework_leasing",
                table: "propertyspaceleasepropousals",
                column: "propertyspaceid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "propertyspaceleasepropousals",
                schema: "decisorframework_leasing");
        }
    }
}
