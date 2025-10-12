using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HHRRUpgrade5SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeedailycheckings",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    employeeid = table.Column<Guid>(type: "uuid", nullable: false),
                    month = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    checkin = table.Column<TimeSpan>(type: "interval", nullable: false),
                    partialcheckout = table.Column<TimeSpan>(type: "interval", nullable: true),
                    partialchecin = table.Column<TimeSpan>(type: "interval", nullable: true),
                    checkout = table.Column<TimeSpan>(type: "interval", nullable: true),
                    extracheckin = table.Column<TimeSpan>(type: "interval", nullable: true),
                    extracheckout = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employeedailycheckings", x => x.id);
                    table.ForeignKey(
                        name: "fk_employeedailycheckings_employees_employeeid",
                        column: x => x.employeeid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_employeedailycheckings_employeeid",
                schema: "decisorframework_humanresources",
                table: "employeedailycheckings",
                column: "employeeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeedailycheckings",
                schema: "decisorframework_humanresources");
        }
    }
}
