using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResourcesRedefine02SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_employees_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_namingresolutions_workpositions_ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunityvacantbridge",
                schema: "decisorframework_humanresources");

            migrationBuilder.RenameColumn(
                name: "ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                newName: "vacantid");

            migrationBuilder.RenameIndex(
                name: "ix_namingresolutions_ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                newName: "ix_namingresolutions_vacantid");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "ocupationid");

            migrationBuilder.RenameIndex(
                name: "ix_employmentcontracts_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "ix_employmentcontracts_ocupationid");

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "decisorframework_humanresources",
                table: "workforces",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "vacants",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    namingresolutionrequired = table.Column<bool>(type: "boolean", nullable: false),
                    workpositionid = table.Column<Guid>(type: "uuid", nullable: false),
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationunityid = table.Column<Guid>(type: "uuid", nullable: false),
                    salarystandardid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacants", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacants_organizationalunities_organizationunityid",
                        column: x => x.organizationunityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacants_salarystandards_salarystandardid",
                        column: x => x.salarystandardid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "salarystandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacants_workforces_workforceid",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacants_workpositions_workpositionid",
                        column: x => x.workpositionid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ocupations",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    employeeid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ocupations", x => x.id);
                    table.ForeignKey(
                        name: "fk_ocupations_employees_employeeid",
                        column: x => x.employeeid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_ocupations_vacants_vacantid",
                        column: x => x.vacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_employeeid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_vacantid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "vacantid");

            migrationBuilder.CreateIndex(
                name: "ix_vacants_organizationunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "organizationunityid");

            migrationBuilder.CreateIndex(
                name: "ix_vacants_salarystandardid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "salarystandardid");

            migrationBuilder.CreateIndex(
                name: "ix_vacants_workforceid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceid");

            migrationBuilder.CreateIndex(
                name: "ix_vacants_workpositionid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workpositionid");

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_ocupations_ocupationid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "ocupationid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "ocupations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_namingresolutions_vacants_vacantid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_ocupations_ocupationid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_namingresolutions_vacants_vacantid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions");

            migrationBuilder.DropTable(
                name: "ocupations",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vacants",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropColumn(
                name: "name",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.RenameColumn(
                name: "vacantid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                newName: "ocupationid");

            migrationBuilder.RenameIndex(
                name: "ix_namingresolutions_vacantid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                newName: "ix_namingresolutions_ocupationid");

            migrationBuilder.RenameColumn(
                name: "ocupationid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "employeeid");

            migrationBuilder.RenameIndex(
                name: "ix_employmentcontracts_ocupationid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                newName: "ix_employmentcontracts_employeeid");

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunityvacantbridge",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationunityid = table.Column<Guid>(type: "uuid", nullable: false),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: false),
                    salarystandardid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunityvacantbridge", x => new { x.workforceid, x.organizationunityid, x.vacantid });
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridge_organizationalunit~",
                        column: x => x.organizationunityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridge_salarystandards_sa~",
                        column: x => x.salarystandardid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "salarystandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridge_workforces_workfor~",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridge_workpositions_vaca~",
                        column: x => x.vacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunityvacantbridge_organizationunityid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridge",
                column: "organizationunityid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunityvacantbridge_salarystandardid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridge",
                column: "salarystandardid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunityvacantbridge_vacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridge",
                column: "vacantid");

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_employees_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "employeeid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_namingresolutions_workpositions_ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                column: "ocupationid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workpositions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
