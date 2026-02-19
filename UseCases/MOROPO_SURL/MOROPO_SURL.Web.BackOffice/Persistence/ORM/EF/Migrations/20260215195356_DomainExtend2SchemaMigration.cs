using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainExtend2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_costcenters_structures_structureid",
                schema: "decisorframework_finantial",
                table: "costcenters");

            migrationBuilder.DropForeignKey(
                name: "fk_decisionmakinggroups_structures_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_structures_structureid",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_staffs_structures_structureid",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.DropForeignKey(
                name: "fk_structureorganizationalunitybridges_structures_prowid",
                schema: "decisorframework_domain",
                table: "structureorganizationalunitybridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_structures_structureid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "structures",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "structurekinds",
                schema: "decisorframework_domain");

            migrationBuilder.RenameColumn(
                name: "structureid",
                schema: "decisorframework_domain",
                table: "vehicles",
                newName: "administrativeentityid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicles_structureid",
                schema: "decisorframework_domain",
                table: "vehicles",
                newName: "ix_vehicles_administrativeentityid");

            migrationBuilder.RenameColumn(
                name: "structureid",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "administrativeentityid");

            migrationBuilder.RenameIndex(
                name: "ix_properties_structureid",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "ix_properties_administrativeentityid");

            migrationBuilder.CreateTable(
                name: "administrativeentitykinds",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_administrativeentitykinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organizationalstructures",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true),
                    unitid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalstructures", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalstructures_organizationalstructures_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationalstructures_organizationalunities_unitid",
                        column: x => x.unitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "administrativeentities",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    socialpropertyid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_administrativeentities", x => x.id);
                    table.ForeignKey(
                        name: "fk_administrativeentities_administrativeentities_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "administrativeentities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_administrativeentities_administrativeentitykinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "administrativeentitykinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_administrativeentities_organizationidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_administrativeentities_properties_socialpropertyid",
                        column: x => x.socialpropertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_administrativeentities_identityid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "identityid");

            migrationBuilder.CreateIndex(
                name: "ix_administrativeentities_kindid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_administrativeentities_parentid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_administrativeentities_socialpropertyid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "socialpropertyid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructures_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructures_unitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "unitid");

            migrationBuilder.AddForeignKey(
                name: "fk_costcenters_administrativeentities_structureid",
                schema: "decisorframework_finantial",
                table: "costcenters",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_decisionmakinggroups_administrativeentities_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_properties_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "administrativeentityid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_staffs_administrativeentities_structureid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_structureorganizationalunitybridges_administrativeentities_~",
                schema: "decisorframework_domain",
                table: "structureorganizationalunitybridges",
                column: "prowid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "administrativeentityid",
                principalSchema: "decisorframework_domain",
                principalTable: "administrativeentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_costcenters_administrativeentities_structureid",
                schema: "decisorframework_finantial",
                table: "costcenters");

            migrationBuilder.DropForeignKey(
                name: "fk_decisionmakinggroups_administrativeentities_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_staffs_administrativeentities_structureid",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.DropForeignKey(
                name: "fk_structureorganizationalunitybridges_administrativeentities_~",
                schema: "decisorframework_domain",
                table: "structureorganizationalunitybridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_administrativeentities_administrativeentityid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "administrativeentities",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "organizationalstructures",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "administrativeentitykinds",
                schema: "decisorframework_domain");

            migrationBuilder.RenameColumn(
                name: "administrativeentityid",
                schema: "decisorframework_domain",
                table: "vehicles",
                newName: "structureid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicles_administrativeentityid",
                schema: "decisorframework_domain",
                table: "vehicles",
                newName: "ix_vehicles_structureid");

            migrationBuilder.RenameColumn(
                name: "administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "structureid");

            migrationBuilder.RenameIndex(
                name: "ix_properties_administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties",
                newName: "ix_properties_structureid");

            migrationBuilder.CreateTable(
                name: "structurekinds",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_structurekinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "structures",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    socialpropertyid = table.Column<Guid>(type: "uuid", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_structures", x => x.id);
                    table.ForeignKey(
                        name: "fk_structures_organizationidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_structures_properties_socialpropertyid",
                        column: x => x.socialpropertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_structures_structurekinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structurekinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_structures_structures_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_structures_identityid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "identityid");

            migrationBuilder.CreateIndex(
                name: "ix_structures_kindid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_structures_parentid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_structures_socialpropertyid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "socialpropertyid");

            migrationBuilder.AddForeignKey(
                name: "fk_costcenters_structures_structureid",
                schema: "decisorframework_finantial",
                table: "costcenters",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_decisionmakinggroups_structures_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_properties_structures_structureid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_staffs_structures_structureid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_structureorganizationalunitybridges_structures_prowid",
                schema: "decisorframework_domain",
                table: "structureorganizationalunitybridges",
                column: "prowid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_structures_structureid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
