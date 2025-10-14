using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collects",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    legalclientpropertyleasingid = table.Column<Guid>(type: "uuid", nullable: true),
                    legalclientvehicleleasingid = table.Column<Guid>(type: "uuid", nullable: true),
                    naturalclientpropertyleasingid = table.Column<Guid>(type: "uuid", nullable: true),
                    naturalclientvehicleleasingid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_collects", x => x.id);
                    table.ForeignKey(
                        name: "fk_collects_legalclientpropertyleasings_legalclientpropertylea~",
                        column: x => x.legalclientpropertyleasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_collects_legalclientvehicleleasings_legalclientvehicleleasi~",
                        column: x => x.legalclientvehicleleasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_collects_naturalclientpropertyleasings_naturalclientpropert~",
                        column: x => x.naturalclientpropertyleasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_collects_naturalclientvehicleleasings_naturalclientvehiclel~",
                        column: x => x.naturalclientvehicleleasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_collects_legalclientpropertyleasingid",
                schema: "decisorframework_finantial",
                table: "collects",
                column: "legalclientpropertyleasingid");

            migrationBuilder.CreateIndex(
                name: "ix_collects_legalclientvehicleleasingid",
                schema: "decisorframework_finantial",
                table: "collects",
                column: "legalclientvehicleleasingid");

            migrationBuilder.CreateIndex(
                name: "ix_collects_naturalclientpropertyleasingid",
                schema: "decisorframework_finantial",
                table: "collects",
                column: "naturalclientpropertyleasingid");

            migrationBuilder.CreateIndex(
                name: "ix_collects_naturalclientvehicleleasingid",
                schema: "decisorframework_finantial",
                table: "collects",
                column: "naturalclientvehicleleasingid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collects",
                schema: "decisorframework_finantial");
        }
    }
}
