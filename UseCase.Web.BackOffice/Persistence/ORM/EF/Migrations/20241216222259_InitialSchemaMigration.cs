using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "decisorframework_commercial");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_finantial");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_inventory");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_legal");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_essential");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_location");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_production");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_purchasing");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_media");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_identity");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_humanresources");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_core_security_common");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_domain");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_sales");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_servicing");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_security_personal");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    parentid = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_categories_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "clauses",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    body = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clauses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clausetags",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clausetags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "guamaframework_location",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    isocode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    symbol = table.Column<string>(type: "text", nullable: false),
                    useendsymbolpresentation = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customattributes",
                schema: "decisorframework_inventory",
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
                    table.PrimaryKey("pk_customattributes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "emailcontactitems",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    emailaddress = table.Column<string>(type: "text", nullable: false),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_emailcontactitems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "legalbusinesskinds",
                schema: "decisorframework_commercial",
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
                    table.PrimaryKey("pk_legalbusinesskinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "naturalbusinesskinds",
                schema: "decisorframework_commercial",
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
                    table.PrimaryKey("pk_naturalbusinesskinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "guamaframework_core_security_common",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    family = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "phonecontactitems",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    phonenumber = table.Column<string>(type: "text", nullable: false),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_phonecontactitems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productionrole",
                schema: "decisorframework_production",
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
                    table.PrimaryKey("pk_productionrole", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "proformas",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proformas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "propertykinds",
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
                    table.PrimaryKey("pk_propertykinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "purchasespents",
                schema: "decisorframework_purchasing",
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
                    table.PrimaryKey("pk_purchasespents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "purchasezones",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchasezones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "purchasingroles",
                schema: "decisorframework_purchasing",
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
                    table.PrimaryKey("pk_purchasingroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "guamaframework_core_security_common",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sections",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sections", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "socialcontactitems",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    socialid = table.Column<string>(type: "text", nullable: false),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_socialcontactitems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "structurekinds",
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
                    table.PrimaryKey("pk_structurekinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "thumbnails",
                schema: "guamaframework_media",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contenttype = table.Column<string>(type: "text", nullable: false),
                    length = table.Column<long>(type: "bigint", nullable: false),
                    about = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thumbnails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "traces",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    author = table.Column<string>(type: "text", nullable: true),
                    registered = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    entityname = table.Column<string>(type: "text", nullable: false),
                    beforedata = table.Column<string>(type: "text", nullable: false),
                    afterdata = table.Column<string>(type: "text", nullable: true),
                    nextid = table.Column<long>(type: "bigint", nullable: false),
                    signature = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_traces", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "unitmeasurements",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    symbol = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_unitmeasurements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehiclecategories",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    parentid = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiclecategories", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehiclecategories_vehiclecategories_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehiclecategories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vehicleenginekinds",
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
                    table.PrimaryKey("pk_vehicleenginekinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "warehouses",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_warehouses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "websitecontactitems",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_websitecontactitems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clausetagbridges",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<string>(type: "text", nullable: false),
                    clauseid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clausetagbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_clausetagbridges_clauses_clauseid",
                        column: x => x.clauseid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clauses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_clausetagbridges_clauses_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clauses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_clausetagbridges_clausetags_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clausetags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                schema: "guamaframework_location",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    countryid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regions", x => x.id);
                    table.ForeignKey(
                        name: "fk_regions_countries_countryid",
                        column: x => x.countryid,
                        principalSchema: "guamaframework_location",
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchasezonespentbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchasezonespentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchasezonespentbridges_purchasespents_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasespents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchasezonespentbridges_purchasezones_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasezones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rolepermissionbridges",
                schema: "guamaframework_core_security_common",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rolepermissionbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_rolepermissionbridges_permissions_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_core_security_common",
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rolepermissionbridges_roles_prowid",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_core_security_common",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proformasectionclausebridges",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    sectionid = table.Column<Guid>(type: "uuid", nullable: false),
                    proformaid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proformasectionclausebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_proformasectionclausebridges_clauses_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clauses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_proformasectionclausebridges_proformas_proformaid",
                        column: x => x.proformaid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proformas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_proformasectionclausebridges_proformas_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proformas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_proformasectionclausebridges_sections_sectionid",
                        column: x => x.sectionid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "sections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                schema: "guamaframework_media",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    contenttype = table.Column<string>(type: "text", nullable: false),
                    length = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    thumbnailid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_documents", x => x.id);
                    table.ForeignKey(
                        name: "fk_documents_thumbnails_thumbnailid",
                        column: x => x.thumbnailid,
                        principalSchema: "guamaframework_media",
                        principalTable: "thumbnails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "images",
                schema: "guamaframework_media",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    contenttype = table.Column<string>(type: "text", nullable: false),
                    length = table.Column<long>(type: "bigint", nullable: false),
                    about = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    height = table.Column<int>(type: "integer", nullable: false),
                    width = table.Column<int>(type: "integer", nullable: false),
                    thumbnailid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_images", x => x.id);
                    table.ForeignKey(
                        name: "fk_images_thumbnails_thumbnailid",
                        column: x => x.thumbnailid,
                        principalSchema: "guamaframework_media",
                        principalTable: "thumbnails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "videos",
                schema: "guamaframework_media",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    createat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    extension = table.Column<string>(type: "text", nullable: false),
                    length = table.Column<long>(type: "bigint", nullable: false),
                    about = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    format = table.Column<string>(type: "text", nullable: false),
                    framesize = table.Column<string>(type: "text", nullable: false),
                    colormodel = table.Column<string>(type: "text", nullable: false),
                    fps = table.Column<double>(type: "double precision", nullable: false),
                    audioformat = table.Column<string>(type: "text", nullable: false),
                    audiochanneloutput = table.Column<string>(type: "text", nullable: false),
                    thumbnailid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_videos", x => x.id);
                    table.ForeignKey(
                        name: "fk_videos_thumbnails_thumbnailid",
                        column: x => x.thumbnailid,
                        principalSchema: "guamaframework_media",
                        principalTable: "thumbnails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "unitmeasurementconversionbridges",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    convertion = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_unitmeasurementconversionbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_unitmeasurementconversionbridges_unitmeasurements_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_unitmeasurementconversionbridges_unitmeasurements_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "states",
                schema: "guamaframework_location",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    regionid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_states", x => x.id);
                    table.ForeignKey(
                        name: "fk_states_regions_regionid",
                        column: x => x.regionid,
                        principalSchema: "guamaframework_location",
                        principalTable: "regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bankagencies",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    imageid = table.Column<Guid>(type: "uuid", nullable: true),
                    about = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bankagencies", x => x.id);
                    table.ForeignKey(
                        name: "fk_bankagencies_images_imageid",
                        column: x => x.imageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "organizationidentities",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ownerid = table.Column<Guid>(type: "uuid", nullable: true),
                    imageid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    borndate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    about = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationidentities", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationidentities_images_imageid",
                        column: x => x.imageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationidentities_organizationidentities_ownerid",
                        column: x => x.ownerid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "personidentities",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    alias = table.Column<string>(type: "text", nullable: true),
                    sex = table.Column<int>(type: "integer", nullable: false),
                    civilstatus = table.Column<int>(type: "integer", nullable: false),
                    imageid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    borndate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    about = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personidentities", x => x.id);
                    table.ForeignKey(
                        name: "fk_personidentities_images_imageid",
                        column: x => x.imageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    defaultunitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    categoryid = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    featureimageid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_categoryid",
                        column: x => x.categoryid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_products_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_products_unitmeasurements_defaultunitmeasurementid",
                        column: x => x.defaultunitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                schema: "decisorframework_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    featureimageid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_services", x => x.id);
                    table.ForeignKey(
                        name: "fk_services_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "municipalities",
                schema: "guamaframework_location",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    stateid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_municipalities", x => x.id);
                    table.ForeignKey(
                        name: "fk_municipalities_states_stateid",
                        column: x => x.stateid,
                        principalSchema: "guamaframework_location",
                        principalTable: "states",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizationemailcontactitembridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationemailcontactitembridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_organizationemailcontactitembridges_emailcontactitems_stern~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "emailcontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationemailcontactitembridges_organizationidentities_~",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizationphonecontactitembridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationphonecontactitembridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_organizationphonecontactitembridges_organizationidentities_~",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationphonecontactitembridges_phonecontactitems_stern~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "phonecontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizationsocialcontactitembridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationsocialcontactitembridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_organizationsocialcontactitembridges_organizationidentities~",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationsocialcontactitembridges_socialcontactitems_ste~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "socialcontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizationwebsitecontactitembridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationwebsitecontactitembridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_organizationwebsitecontactitembridges_organizationidentitie~",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationwebsitecontactitembridges_websitecontactitems_s~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "websitecontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "colaborator",
                schema: "decisorframework_essential",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_colaborator", x => x.id);
                    table.ForeignKey(
                        name: "fk_colaborator_personidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: true),
                    businesskindid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_contacts_legalbusinesskinds_businesskindid",
                        column: x => x.businesskindid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalbusinesskinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contacts_naturalbusinesskinds_businesskindid",
                        column: x => x.businesskindid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalbusinesskinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contacts_organizationidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contacts_personidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false),
                    personalidentificationnumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                    table.ForeignKey(
                        name: "fk_employees_personidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizationpersonmembershipbridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationpersonmembershipbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_organizationpersonmembershipbridges_organizationidentities_~",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationpersonmembershipbridges_personidentities_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personemailcontactitembridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personemailcontactitembridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_personemailcontactitembridges_emailcontactitems_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "emailcontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_personemailcontactitembridges_personidentities_prowid",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personphonecontactitembridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personphonecontactitembridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_personphonecontactitembridges_personidentities_prowid",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_personphonecontactitembridges_phonecontactitems_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "phonecontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personsocialcontactitembridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personsocialcontactitembridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_personsocialcontactitembridges_personidentities_prowid",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_personsocialcontactitembridges_socialcontactitems_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "socialcontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personwebsitecontactitembridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personwebsitecontactitembridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_personwebsitecontactitembridges_personidentities_prowid",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_personwebsitecontactitembridges_websitecontactitems_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "websitecontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "guamaframework_security_personal",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    passwordchangerequired = table.Column<bool>(type: "boolean", nullable: false),
                    hasfullaccess = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastsessiondate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    failauthenticationcount = table.Column<int>(type: "integer", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false),
                    signature = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_personidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classifications",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_classifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_classifications_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaboration",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    minperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    maxperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaboration", x => x.id);
                    table.ForeignKey(
                        name: "fk_elaboration_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productcustomattributebridges",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productcustomattributebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productcustomattributebridges_customattributes_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "customattributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productcustomattributebridges_products_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productwarehousingdecreasekindbridges",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    kind = table.Column<int>(type: "integer", nullable: false),
                    mindecrease = table.Column<decimal>(type: "numeric", nullable: false),
                    maxdecrease = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productwarehousingdecreasekindbridges", x => new { x.kind, x.productid });
                    table.ForeignKey(
                        name: "fk_productwarehousingdecreasekindbridges_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "localities",
                schema: "guamaframework_location",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    municipalityid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_localities", x => x.id);
                    table.ForeignKey(
                        name: "fk_localities_municipalities_municipalityid",
                        column: x => x.municipalityid,
                        principalSchema: "guamaframework_location",
                        principalTable: "municipalities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contactproductbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    abstractcontactid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contactproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_contactproductbridges_contacts_abstractcontactid",
                        column: x => x.abstractcontactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_contactproductbridges_contacts_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contactproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contactservicebridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    abstractcontactid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contactservicebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_contactservicebridges_contacts_abstractcontactid",
                        column: x => x.abstractcontactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_contactservicebridges_contacts_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contactservicebridges_services_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_servicing",
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclients",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclients", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclients_contacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviders",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviders", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalproviders_contacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclients",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    personalidentificationnumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclients", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclients_contacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviders",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    businesskindid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    personalidentificationnumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviders", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalproviders_contacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviders_naturalbusinesskinds_businesskindid",
                        column: x => x.businesskindid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalbusinesskinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abstractbudget",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sharedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    confirmedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    commercialid = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abstractbudget", x => new { x.number, x.year });
                    table.ForeignKey(
                        name: "fk_abstractbudget_contacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_abstractbudget_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departures",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departures", x => x.id);
                    table.ForeignKey(
                        name: "fk_departures_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employmentcontracts",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    employeeid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    proformaid = table.Column<Guid>(type: "uuid", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employmentcontracts", x => new { x.number, x.year });
                    table.ForeignKey(
                        name: "fk_employmentcontracts_employees_employeeid",
                        column: x => x.employeeid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_employmentcontracts_proformas_proformaid",
                        column: x => x.proformaid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proformas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "namingresolutions",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    namedemployeeid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    summary = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_namingresolutions", x => x.id);
                    table.ForeignKey(
                        name: "fk_namingresolutions_employees_namedemployeeid",
                        column: x => x.namedemployeeid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseplans",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    plannedfor = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    approvedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    plannerid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    decisorid = table.Column<Guid>(type: "uuid", nullable: false),
                    zoneid = table.Column<Guid>(type: "uuid", nullable: false),
                    estimatedadvance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseplans", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaseplans_employees_decisorid",
                        column: x => x.decisorid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplans_employees_plannerid",
                        column: x => x.plannerid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplans_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplans_purchasezones_zoneid",
                        column: x => x.zoneid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasezones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receptions",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_receptions_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userrolebridges",
                schema: "guamaframework_security_personal",
                columns: table => new
                {
                    prowid = table.Column<string>(type: "text", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    signature = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userrolebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_userrolebridges_roles_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_core_security_common",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_userrolebridges_users_prowid",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_security_personal",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationinputproductbridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationinputproductbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationinputproductbridge_elaboration_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaboration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationinputproductbridge_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationoutputproductbridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    minperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    maxperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationoutputproductbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductbridge_elaboration_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaboration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductbridge_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationstep",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    elaborationid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    mindecrease = table.Column<decimal>(type: "numeric", nullable: false),
                    maxdecrease = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationstep", x => x.id);
                    table.ForeignKey(
                        name: "fk_elaborationstep_elaboration_elaborationid",
                        column: x => x.elaborationid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaboration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionplan",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    elaborationid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    plannedfor = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    approvedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    plannerid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    decisorid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionplan", x => x.id);
                    table.ForeignKey(
                        name: "fk_productionplan_elaboration_elaborationid",
                        column: x => x.elaborationid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaboration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionplan_employees_decisorid",
                        column: x => x.decisorid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionplan_employees_plannerid",
                        column: x => x.plannerid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionplan_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                schema: "guamaframework_location",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    localityid = table.Column<Guid>(type: "uuid", nullable: true),
                    municipalityid = table.Column<Guid>(type: "uuid", nullable: true),
                    stateid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locations", x => x.id);
                    table.ForeignKey(
                        name: "fk_locations_localities_localityid",
                        column: x => x.localityid,
                        principalSchema: "guamaframework_location",
                        principalTable: "localities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_locations_municipalities_municipalityid",
                        column: x => x.municipalityid,
                        principalSchema: "guamaframework_location",
                        principalTable: "municipalities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_locations_states_stateid",
                        column: x => x.stateid,
                        principalSchema: "guamaframework_location",
                        principalTable: "states",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "legalclientsalecontracts",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    proformaid = table.Column<Guid>(type: "uuid", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientsalecontracts", x => new { x.number, x.year });
                    table.ForeignKey(
                        name: "fk_legalclientsalecontracts_legalclients_clientid",
                        column: x => x.clientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientsalecontracts_proformas_proformaid",
                        column: x => x.proformaid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proformas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviderpurchasezonebridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderpurchasezonebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalproviderpurchasezonebridges_legalproviders_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderpurchasezonebridges_purchasezones_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasezones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviderpurchasingcontracts",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    proformaid = table.Column<Guid>(type: "uuid", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderpurchasingcontracts", x => new { x.number, x.year });
                    table.ForeignKey(
                        name: "fk_legalproviderpurchasingcontracts_legalproviders_providerid",
                        column: x => x.providerid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderpurchasingcontracts_proformas_proformaid",
                        column: x => x.proformaid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proformas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientsalecontracts",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    proformaid = table.Column<Guid>(type: "uuid", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientsalecontracts", x => new { x.number, x.year });
                    table.ForeignKey(
                        name: "fk_naturalclientsalecontracts_naturalclients_clientid",
                        column: x => x.clientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientsalecontracts_proformas_proformaid",
                        column: x => x.proformaid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proformas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderpurchasezonebridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderpurchasezonebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalproviderpurchasezonebridges_naturalproviders_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderpurchasezonebridges_purchasezones_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasezones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderpurchasingcontracts",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    proformaid = table.Column<Guid>(type: "uuid", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderpurchasingcontracts", x => new { x.number, x.year });
                    table.ForeignKey(
                        name: "fk_naturalproviderpurchasingcontracts_naturalproviders_provide~",
                        column: x => x.providerid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderpurchasingcontracts_proformas_proformaid",
                        column: x => x.proformaid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proformas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "budgetproductbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: true),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budgetproductbridges", x => new { x.budgetnumber, x.budgetyear, x.productid });
                    table.ForeignKey(
                        name: "fk_budgetproductbridges_abstractbudget_budgetnumber_budgetyear",
                        columns: x => new { x.budgetnumber, x.budgetyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "abstractbudget",
                        principalColumns: new[] { "number", "year" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_budgetproductbridges_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_budgetproductbridges_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "budgetservicebridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budgetservicebridges", x => new { x.budgetnumber, x.budgetyear, x.serviceid });
                    table.ForeignKey(
                        name: "fk_budgetservicebridges_abstractbudget_budgetnumber_budgetyear",
                        columns: x => new { x.budgetnumber, x.budgetyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "abstractbudget",
                        principalColumns: new[] { "number", "year" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_budgetservicebridges_services_serviceid",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_servicing",
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departures",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchaseplanid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departures", x => x.id);
                    table.ForeignKey(
                        name: "FK_departures_departures_id",
                        column: x => x.id,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "departures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_departures_purchaseplans_purchaseplanid",
                        column: x => x.purchaseplanid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseplans",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchasecashadvances",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchaseplanid = table.Column<Guid>(type: "uuid", nullable: true),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchasecashadvances", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchasecashadvances_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchasecashadvances_purchaseplans_purchaseplanid",
                        column: x => x.purchaseplanid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseplans",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchaseplaninputproductbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseplaninputproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseplaninputproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplaninputproductbridges_purchaseplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplaninputproductbridges_unitmeasurements_unitmeasur~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseplanlegalproviderbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    debt = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseplanlegalproviderbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseplanlegalproviderbridges_legalproviders_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplanlegalproviderbridges_purchaseplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseplannaturalproviderbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    debt = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseplannaturalproviderbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseplannaturalproviderbridges_naturalproviders_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplannaturalproviderbridges_purchaseplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseplanoutputproductbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseplanoutputproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseplanoutputproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplanoutputproductbridges_purchaseplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplanoutputproductbridges_unitmeasurements_unitmeasu~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchases",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    planid = table.Column<Guid>(type: "uuid", nullable: true),
                    zoneid = table.Column<Guid>(type: "uuid", nullable: true),
                    purchaserid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchases", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchases_employees_purchaserid",
                        column: x => x.purchaserid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchases_purchaseplans_planid",
                        column: x => x.planid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseplans",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchases_purchasezones_zoneid",
                        column: x => x.zoneid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasezones",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "elaborationstepproductionrolebridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    participation = table.Column<decimal>(type: "numeric", nullable: false),
                    linked = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationstepproductionrolebridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationstepproductionrolebridge_elaborationstep_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationstep",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationstepproductionrolebridge_productionrole_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productionrole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "production",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    planid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_production", x => x.id);
                    table.ForeignKey(
                        name: "fk_production_productionplan_planid",
                        column: x => x.planid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productionplan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_production_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "postalcontactitems",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    locationid = table.Column<Guid>(type: "uuid", nullable: true),
                    zipcode = table.Column<int>(type: "integer", nullable: false),
                    longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_postalcontactitems", x => x.id);
                    table.ForeignKey(
                        name: "fk_postalcontactitems_locations_locationid",
                        column: x => x.locationid,
                        principalSchema: "guamaframework_location",
                        principalTable: "locations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sales",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sellerid = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    contractnumber = table.Column<int>(type: "integer", nullable: true),
                    contractyear = table.Column<int>(type: "integer", nullable: true),
                    budgetnumber = table.Column<int>(type: "integer", nullable: true),
                    budgetyear = table.Column<int>(type: "integer", nullable: true),
                    identityid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sales", x => x.id);
                    table.ForeignKey(
                        name: "fk_sales_abstractbudget_budgetnumber_budgetyear",
                        columns: x => new { x.budgetnumber, x.budgetyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "abstractbudget",
                        principalColumns: new[] { "number", "year" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sales_employees_sellerid",
                        column: x => x.sellerid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sales_legalclientsalecontracts_contractnumber_contractyear",
                        columns: x => new { x.contractnumber, x.contractyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclientsalecontracts",
                        principalColumns: new[] { "number", "year" });
                    table.ForeignKey(
                        name: "fk_sales_naturalclientsalecontracts_contractnumber_contractyear",
                        columns: x => new { x.contractnumber, x.contractyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclientsalecontracts",
                        principalColumns: new[] { "number", "year" });
                    table.ForeignKey(
                        name: "fk_sales_personidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchasecolaboratorbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchasecolaboratorbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchasecolaboratorbridges_colaborator_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_essential",
                        principalTable: "colaborator",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchasecolaboratorbridges_purchases_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchasecolaboratorbridges_purchasingroles_roleid",
                        column: x => x.roleid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasingroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseemployeebridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseemployeebridges_purchases_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseemployeebridges_purchasingroles_roleid",
                        column: x => x.roleid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasingroles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receptions",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchaseid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_receptions_receptions_id",
                        column: x => x.id,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "receptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_receptions_purchases_purchaseid",
                        column: x => x.purchaseid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchases",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "departures",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    productionid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departures", x => x.id);
                    table.ForeignKey(
                        name: "FK_departures_departures_id",
                        column: x => x.id,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "departures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_departures_production_productionid",
                        column: x => x.productionid,
                        principalSchema: "decisorframework_production",
                        principalTable: "production",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "productioncolaboratorbridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    stepid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productioncolaboratorbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridge_colaborator_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_essential",
                        principalTable: "colaborator",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridge_elaborationstep_stepid",
                        column: x => x.stepid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationstep",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridge_production_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "production",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridge_productionrole_roleid",
                        column: x => x.roleid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productionrole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionemployeebridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    stepid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionemployeebridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productionemployeebridge_elaborationstep_stepid",
                        column: x => x.stepid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationstep",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridge_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridge_production_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "production",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridge_productionrole_roleid",
                        column: x => x.roleid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productionrole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionproductbridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionproductbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productionproductbridge_production_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "production",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionproductbridge_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionproductbridge_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receptions",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    productionid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_receptions_receptions_id",
                        column: x => x.id,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "receptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_receptions_production_productionid",
                        column: x => x.productionid,
                        principalSchema: "decisorframework_production",
                        principalTable: "production",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "bankbranches",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    agencyid = table.Column<Guid>(type: "uuid", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    postalcontactid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bankbranches", x => x.id);
                    table.ForeignKey(
                        name: "fk_bankbranches_bankagencies_agencyid",
                        column: x => x.agencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankagencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bankbranches_postalcontactitems_postalcontactid",
                        column: x => x.postalcontactid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "postalcontactitems",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "organizationpostalcontactitembridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationpostalcontactitembridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_organizationpostalcontactitembridges_organizationidentities~",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationpostalcontactitembridges_postalcontactitems_ste~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "postalcontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "personpostalcontactitembridges",
                schema: "guamaframework_identity",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personpostalcontactitembridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_personpostalcontactitembridges_personidentities_prowid",
                        column: x => x.prowid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_personpostalcontactitembridges_postalcontactitems_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "postalcontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bankaccounts",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    branchid = table.Column<Guid>(type: "uuid", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    holder = table.Column<string>(type: "text", nullable: false),
                    currencyid = table.Column<Guid>(type: "uuid", nullable: false),
                    external = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bankaccounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_bankaccounts_bankbranches_branchid",
                        column: x => x.branchid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankbranches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bankaccounts_currencies_currencyid",
                        column: x => x.currencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bankdebitcards",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    bankaccountid = table.Column<Guid>(type: "uuid", nullable: false),
                    expireon = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bankdebitcards", x => x.id);
                    table.ForeignKey(
                        name: "fk_bankdebitcards_bankaccounts_bankaccountid",
                        column: x => x.bankaccountid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "batches",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    externalreference = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    warehouseid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    receptionid = table.Column<Guid>(type: "uuid", nullable: false),
                    costcenterid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_batches", x => x.id);
                    table.ForeignKey(
                        name: "fk_batches_classifications_classificationid",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_batches_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_batches_receptions_receptionid",
                        column: x => x.receptionid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "receptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_batches_warehouses_warehouseid",
                        column: x => x.warehouseid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "warehouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departurebatchbridges",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departurebatchbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_departurebatchbridges_batches_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "batches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_departurebatchbridges_departures_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "departures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receptionbatchbridges",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receptionbatchbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_receptionbatchbridges_batches_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "batches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_receptionbatchbridges_receptions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "receptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "costcenters",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    about = table.Column<string>(type: "text", nullable: true),
                    defaultbankaccountid = table.Column<Guid>(type: "uuid", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_costcenters", x => x.id);
                    table.ForeignKey(
                        name: "fk_costcenters_bankaccounts_defaultbankaccountid",
                        column: x => x.defaultbankaccountid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseproductlegalproviderbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    purchaseid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    costcenterid = table.Column<Guid>(type: "uuid", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseproductlegalproviderbridges", x => new { x.purchaseid, x.providerid, x.productid, x.costcenterid });
                    table.ForeignKey(
                        name: "fk_purchaseproductlegalproviderbridges_costcenters_costcenterid",
                        column: x => x.costcenterid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "costcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseproductlegalproviderbridges_legalproviders_provider~",
                        column: x => x.providerid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseproductlegalproviderbridges_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseproductlegalproviderbridges_purchases_purchaseid",
                        column: x => x.purchaseid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseproductlegalproviderbridges_unitmeasurements_unitme~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseproductnaturalproviderbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    purchaseid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    costcenterid = table.Column<Guid>(type: "uuid", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseproductnaturalproviderbridges", x => new { x.purchaseid, x.providerid, x.productid, x.costcenterid });
                    table.ForeignKey(
                        name: "fk_purchaseproductnaturalproviderbridges_costcenters_costcente~",
                        column: x => x.costcenterid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "costcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseproductnaturalproviderbridges_naturalproviders_prov~",
                        column: x => x.providerid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseproductnaturalproviderbridges_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseproductnaturalproviderbridges_purchases_purchaseid",
                        column: x => x.purchaseid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseproductnaturalproviderbridges_unitmeasurements_unit~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchasepurchasespentbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    isregular = table.Column<bool>(type: "boolean", nullable: false),
                    costcenterid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchasepurchasespentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchasepurchasespentbridges_costcenters_costcenterid",
                        column: x => x.costcenterid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "costcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchasepurchasespentbridges_purchases_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchasepurchasespentbridges_purchasespents_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasespents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchasereceptionproductweightbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    receptionid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    costcenterid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    decrease = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchasereceptionproductweightbridges", x => new { x.receptionid, x.productid, x.costcenterid });
                    table.ForeignKey(
                        name: "fk_purchasereceptionproductweightbridges_costcenters_costcente~",
                        column: x => x.costcenterid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "costcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchasereceptionproductweightbridges_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchasereceptionproductweightbridges_receptions_receptionid",
                        column: x => x.receptionid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "receptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    postalcontactid = table.Column<Guid>(type: "uuid", nullable: false),
                    featureimageid = table.Column<Guid>(type: "uuid", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    propertyrecordidentifier = table.Column<string>(type: "text", nullable: false),
                    area = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_properties_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_properties_postalcontactitems_postalcontactid",
                        column: x => x.postalcontactid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "postalcontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_properties_propertykinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "propertykinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyimagebridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    propertyid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyimagebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyimagebridges_images_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyimagebridges_properties_propertyid",
                        column: x => x.propertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_propertyimagebridges_properties_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "structures",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false),
                    representativenamingresolutionnid = table.Column<long>(type: "bigint", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    socialpropertyid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_structures", x => x.id);
                    table.ForeignKey(
                        name: "fk_structures_namingresolutions_representativenamingresolution~",
                        column: x => x.representativenamingresolutionnid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "namingresolutions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "vehicles",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    categoryid = table.Column<int>(type: "integer", nullable: false),
                    featureimageid = table.Column<Guid>(type: "uuid", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    plate = table.Column<string>(type: "text", nullable: false),
                    trafficcirculationidentifier = table.Column<string>(type: "text", nullable: false),
                    bodyidentifier = table.Column<string>(type: "text", nullable: false),
                    engineidentifier = table.Column<string>(type: "text", nullable: false),
                    enginekindid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    seatcount = table.Column<int>(type: "integer", nullable: false),
                    loadcapacity = table.Column<double>(type: "double precision", nullable: false),
                    technicalavailabilityindex = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicles_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_structures_structureid",
                        column: x => x.structureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_vehiclecategories_categoryid",
                        column: x => x.categoryid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehiclecategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_vehicleenginekinds_enginekindid",
                        column: x => x.enginekindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehicleenginekinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleimagebridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicleid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleimagebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleimagebridges_images_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleimagebridges_vehicles_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleimagebridges_vehicles_vehicleid",
                        column: x => x.vehicleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_abstractbudget_commercialid",
                schema: "decisorframework_commercial",
                table: "abstractbudget",
                column: "commercialid");

            migrationBuilder.CreateIndex(
                name: "ix_abstractbudget_contactid",
                schema: "decisorframework_commercial",
                table: "abstractbudget",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_bankaccounts_branchid",
                schema: "decisorframework_finantial",
                table: "bankaccounts",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "ix_bankaccounts_currencyid",
                schema: "decisorframework_finantial",
                table: "bankaccounts",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "ix_bankagencies_imageid",
                schema: "decisorframework_finantial",
                table: "bankagencies",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "ix_bankbranches_agencyid",
                schema: "decisorframework_finantial",
                table: "bankbranches",
                column: "agencyid");

            migrationBuilder.CreateIndex(
                name: "ix_bankbranches_postalcontactid",
                schema: "decisorframework_finantial",
                table: "bankbranches",
                column: "postalcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_bankdebitcards_bankaccountid",
                schema: "decisorframework_finantial",
                table: "bankdebitcards",
                column: "bankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_batches_classificationid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_batches_costcenterid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "costcenterid");

            migrationBuilder.CreateIndex(
                name: "ix_batches_productid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_batches_receptionid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "receptionid");

            migrationBuilder.CreateIndex(
                name: "ix_batches_warehouseid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "warehouseid");

            migrationBuilder.CreateIndex(
                name: "ix_budgetproductbridges_productid",
                schema: "decisorframework_commercial",
                table: "budgetproductbridges",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_budgetproductbridges_unitmeasurementid",
                schema: "decisorframework_commercial",
                table: "budgetproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_budgetservicebridges_serviceid",
                schema: "decisorframework_commercial",
                table: "budgetservicebridges",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_categories_parentid",
                schema: "decisorframework_inventory",
                table: "categories",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_classifications_productid",
                schema: "decisorframework_inventory",
                table: "classifications",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_clausetagbridges_clauseid",
                schema: "decisorframework_legal",
                table: "clausetagbridges",
                column: "clauseid");

            migrationBuilder.CreateIndex(
                name: "ix_clausetagbridges_sternid",
                schema: "decisorframework_legal",
                table: "clausetagbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_colaborator_identityid",
                schema: "decisorframework_essential",
                table: "colaborator",
                column: "identityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_contactproductbridges_abstractcontactid",
                schema: "decisorframework_commercial",
                table: "contactproductbridges",
                column: "abstractcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_contactproductbridges_sternid",
                schema: "decisorframework_commercial",
                table: "contactproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_contacts_businesskindid",
                schema: "decisorframework_commercial",
                table: "contacts",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_contacts_identityid",
                schema: "decisorframework_commercial",
                table: "contacts",
                column: "identityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_contactservicebridges_abstractcontactid",
                schema: "decisorframework_commercial",
                table: "contactservicebridges",
                column: "abstractcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_contactservicebridges_sternid",
                schema: "decisorframework_commercial",
                table: "contactservicebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_costcenters_defaultbankaccountid",
                schema: "decisorframework_finantial",
                table: "costcenters",
                column: "defaultbankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_costcenters_structureid",
                schema: "decisorframework_finantial",
                table: "costcenters",
                column: "structureid");

            migrationBuilder.CreateIndex(
                name: "ix_countries_isocode",
                schema: "guamaframework_location",
                table: "countries",
                column: "isocode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_countries_name",
                schema: "guamaframework_location",
                table: "countries",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_departurebatchbridges_sternid",
                schema: "decisorframework_inventory",
                table: "departurebatchbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_departures_responsibleid",
                schema: "decisorframework_inventory",
                table: "departures",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_departures_productionid",
                schema: "decisorframework_production",
                table: "departures",
                column: "productionid");

            migrationBuilder.CreateIndex(
                name: "ix_departures_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "departures",
                column: "purchaseplanid");

            migrationBuilder.CreateIndex(
                name: "ix_documents_thumbnailid",
                schema: "guamaframework_media",
                table: "documents",
                column: "thumbnailid");

            migrationBuilder.CreateIndex(
                name: "ix_elaboration_productid",
                schema: "decisorframework_production",
                table: "elaboration",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductbridge_sternid",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductbridge_sternid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationstep_elaborationid",
                schema: "decisorframework_production",
                table: "elaborationstep",
                column: "elaborationid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationstepproductionrolebridge_sternid",
                schema: "decisorframework_production",
                table: "elaborationstepproductionrolebridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_employees_identityid",
                schema: "decisorframework_humanresources",
                table: "employees",
                column: "identityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_proformaid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "proformaid");

            migrationBuilder.CreateIndex(
                name: "ix_images_thumbnailid",
                schema: "guamaframework_media",
                table: "images",
                column: "thumbnailid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclients_contactid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "contactid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_legalclientsalecontracts_clientid",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientsalecontracts_proformaid",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                column: "proformaid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderpurchasezonebridges_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderpurchasezonebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderpurchasingcontracts_proformaid",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                column: "proformaid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderpurchasingcontracts_providerid",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviders_contactid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                column: "contactid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_localities_municipalityid",
                schema: "guamaframework_location",
                table: "localities",
                column: "municipalityid");

            migrationBuilder.CreateIndex(
                name: "ix_localities_name_municipalityid",
                schema: "guamaframework_location",
                table: "localities",
                columns: new[] { "name", "municipalityid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_locations_localityid",
                schema: "guamaframework_location",
                table: "locations",
                column: "localityid");

            migrationBuilder.CreateIndex(
                name: "ix_locations_municipalityid",
                schema: "guamaframework_location",
                table: "locations",
                column: "municipalityid");

            migrationBuilder.CreateIndex(
                name: "ix_locations_stateid",
                schema: "guamaframework_location",
                table: "locations",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "ix_municipalities_name_stateid",
                schema: "guamaframework_location",
                table: "municipalities",
                columns: new[] { "name", "stateid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_municipalities_stateid",
                schema: "guamaframework_location",
                table: "municipalities",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "ix_namingresolutions_namedemployeeid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                column: "namedemployeeid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclients_contactid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "contactid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientsalecontracts_clientid",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientsalecontracts_proformaid",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                column: "proformaid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderpurchasezonebridges_sternid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderpurchasezonebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderpurchasingcontracts_proformaid",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                column: "proformaid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderpurchasingcontracts_providerid",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviders_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviders_contactid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "contactid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_organizationemailcontactitembridges_sternid",
                schema: "guamaframework_identity",
                table: "organizationemailcontactitembridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationidentities_imageid",
                schema: "guamaframework_identity",
                table: "organizationidentities",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationidentities_ownerid",
                schema: "guamaframework_identity",
                table: "organizationidentities",
                column: "ownerid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationpersonmembershipbridges_sternid",
                schema: "guamaframework_identity",
                table: "organizationpersonmembershipbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationphonecontactitembridges_sternid",
                schema: "guamaframework_identity",
                table: "organizationphonecontactitembridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationpostalcontactitembridges_sternid",
                schema: "guamaframework_identity",
                table: "organizationpostalcontactitembridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationsocialcontactitembridges_sternid",
                schema: "guamaframework_identity",
                table: "organizationsocialcontactitembridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationwebsitecontactitembridges_sternid",
                schema: "guamaframework_identity",
                table: "organizationwebsitecontactitembridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_personemailcontactitembridges_sternid",
                schema: "guamaframework_identity",
                table: "personemailcontactitembridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_personidentities_imageid",
                schema: "guamaframework_identity",
                table: "personidentities",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "ix_personphonecontactitembridges_sternid",
                schema: "guamaframework_identity",
                table: "personphonecontactitembridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_personpostalcontactitembridges_sternid",
                schema: "guamaframework_identity",
                table: "personpostalcontactitembridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_personsocialcontactitembridges_sternid",
                schema: "guamaframework_identity",
                table: "personsocialcontactitembridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_personwebsitecontactitembridges_sternid",
                schema: "guamaframework_identity",
                table: "personwebsitecontactitembridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_postalcontactitems_locationid",
                schema: "guamaframework_identity",
                table: "postalcontactitems",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_productcustomattributebridges_sternid",
                schema: "decisorframework_inventory",
                table: "productcustomattributebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_production_planid",
                schema: "decisorframework_production",
                table: "production",
                column: "planid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_production_unitmeasurementid",
                schema: "decisorframework_production",
                table: "production",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridge_roleid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridge",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridge_stepid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridge",
                column: "stepid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridge_sternid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridge_roleid",
                schema: "decisorframework_production",
                table: "productionemployeebridge",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridge_stepid",
                schema: "decisorframework_production",
                table: "productionemployeebridge",
                column: "stepid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridge_sternid",
                schema: "decisorframework_production",
                table: "productionemployeebridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionplan_decisorid",
                schema: "decisorframework_production",
                table: "productionplan",
                column: "decisorid");

            migrationBuilder.CreateIndex(
                name: "ix_productionplan_elaborationid",
                schema: "decisorframework_production",
                table: "productionplan",
                column: "elaborationid");

            migrationBuilder.CreateIndex(
                name: "ix_productionplan_plannerid",
                schema: "decisorframework_production",
                table: "productionplan",
                column: "plannerid");

            migrationBuilder.CreateIndex(
                name: "ix_productionplan_responsibleid",
                schema: "decisorframework_production",
                table: "productionplan",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_productionproductbridge_sternid",
                schema: "decisorframework_production",
                table: "productionproductbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionproductbridge_unitmeasurementid",
                schema: "decisorframework_production",
                table: "productionproductbridge",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_products_categoryid",
                schema: "decisorframework_inventory",
                table: "products",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_products_defaultunitmeasurementid",
                schema: "decisorframework_inventory",
                table: "products",
                column: "defaultunitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_products_featureimageid",
                schema: "decisorframework_inventory",
                table: "products",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_productwarehousingdecreasekindbridges_productid",
                schema: "decisorframework_inventory",
                table: "productwarehousingdecreasekindbridges",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_proformasectionclausebridges_proformaid",
                schema: "decisorframework_legal",
                table: "proformasectionclausebridges",
                column: "proformaid");

            migrationBuilder.CreateIndex(
                name: "ix_proformasectionclausebridges_sectionid",
                schema: "decisorframework_legal",
                table: "proformasectionclausebridges",
                column: "sectionid");

            migrationBuilder.CreateIndex(
                name: "ix_proformasectionclausebridges_sternid",
                schema: "decisorframework_legal",
                table: "proformasectionclausebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_properties_featureimageid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_properties_kindid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_properties_postalcontactid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "postalcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_properties_propertyrecordidentifier",
                schema: "decisorframework_domain",
                table: "properties",
                column: "propertyrecordidentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_properties_structureid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "structureid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyimagebridges_propertyid",
                schema: "decisorframework_domain",
                table: "propertyimagebridges",
                column: "propertyid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyimagebridges_sternid",
                schema: "decisorframework_domain",
                table: "propertyimagebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchasecashadvances_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances",
                column: "purchaseplanid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_purchasecashadvances_responsibleid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_purchasecolaboratorbridges_roleid",
                schema: "decisorframework_purchasing",
                table: "purchasecolaboratorbridges",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "ix_purchasecolaboratorbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchasecolaboratorbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseemployeebridges_roleid",
                schema: "decisorframework_purchasing",
                table: "purchaseemployeebridges",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseemployeebridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplaninputproductbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseplaninputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplaninputproductbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseplaninputproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplanlegalproviderbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseplanlegalproviderbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplannaturalproviderbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseplannaturalproviderbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplanoutputproductbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseplanoutputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplanoutputproductbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseplanoutputproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplans_decisorid",
                schema: "decisorframework_purchasing",
                table: "purchaseplans",
                column: "decisorid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplans_plannerid",
                schema: "decisorframework_purchasing",
                table: "purchaseplans",
                column: "plannerid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplans_responsibleid",
                schema: "decisorframework_purchasing",
                table: "purchaseplans",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplans_zoneid",
                schema: "decisorframework_purchasing",
                table: "purchaseplans",
                column: "zoneid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseproductlegalproviderbridges_costcenterid",
                schema: "decisorframework_purchasing",
                table: "purchaseproductlegalproviderbridges",
                column: "costcenterid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseproductlegalproviderbridges_productid",
                schema: "decisorframework_purchasing",
                table: "purchaseproductlegalproviderbridges",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseproductlegalproviderbridges_providerid",
                schema: "decisorframework_purchasing",
                table: "purchaseproductlegalproviderbridges",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseproductlegalproviderbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseproductlegalproviderbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseproductnaturalproviderbridges_costcenterid",
                schema: "decisorframework_purchasing",
                table: "purchaseproductnaturalproviderbridges",
                column: "costcenterid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseproductnaturalproviderbridges_productid",
                schema: "decisorframework_purchasing",
                table: "purchaseproductnaturalproviderbridges",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseproductnaturalproviderbridges_providerid",
                schema: "decisorframework_purchasing",
                table: "purchaseproductnaturalproviderbridges",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseproductnaturalproviderbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseproductnaturalproviderbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchasepurchasespentbridges_costcenterid",
                schema: "decisorframework_purchasing",
                table: "purchasepurchasespentbridges",
                column: "costcenterid");

            migrationBuilder.CreateIndex(
                name: "ix_purchasepurchasespentbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchasepurchasespentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchasereceptionproductweightbridges_costcenterid",
                schema: "decisorframework_purchasing",
                table: "purchasereceptionproductweightbridges",
                column: "costcenterid");

            migrationBuilder.CreateIndex(
                name: "ix_purchasereceptionproductweightbridges_productid",
                schema: "decisorframework_purchasing",
                table: "purchasereceptionproductweightbridges",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchases_planid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "planid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_purchases_purchaserid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "purchaserid");

            migrationBuilder.CreateIndex(
                name: "ix_purchases_zoneid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "zoneid");

            migrationBuilder.CreateIndex(
                name: "ix_purchasezonespentbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchasezonespentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_receptionbatchbridges_sternid",
                schema: "decisorframework_inventory",
                table: "receptionbatchbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_receptions_responsibleid",
                schema: "decisorframework_inventory",
                table: "receptions",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_receptions_productionid",
                schema: "decisorframework_production",
                table: "receptions",
                column: "productionid");

            migrationBuilder.CreateIndex(
                name: "ix_receptions_purchaseid",
                schema: "decisorframework_purchasing",
                table: "receptions",
                column: "purchaseid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_regions_countryid",
                schema: "guamaframework_location",
                table: "regions",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "ix_rolepermissionbridges_sternid",
                schema: "guamaframework_core_security_common",
                table: "rolepermissionbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_sales_budgetnumber_budgetyear",
                schema: "decisorframework_sales",
                table: "sales",
                columns: new[] { "budgetnumber", "budgetyear" });

            migrationBuilder.CreateIndex(
                name: "ix_sales_contractnumber_contractyear",
                schema: "decisorframework_sales",
                table: "sales",
                columns: new[] { "contractnumber", "contractyear" });

            migrationBuilder.CreateIndex(
                name: "ix_sales_identityid",
                schema: "decisorframework_sales",
                table: "sales",
                column: "identityid");

            migrationBuilder.CreateIndex(
                name: "ix_sales_sellerid",
                schema: "decisorframework_sales",
                table: "sales",
                column: "sellerid");

            migrationBuilder.CreateIndex(
                name: "ix_services_featureimageid",
                schema: "decisorframework_servicing",
                table: "services",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_states_regionid",
                schema: "guamaframework_location",
                table: "states",
                column: "regionid");

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
                name: "ix_structures_representativenamingresolutionnid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "representativenamingresolutionnid");

            migrationBuilder.CreateIndex(
                name: "ix_structures_socialpropertyid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "socialpropertyid");

            migrationBuilder.CreateIndex(
                name: "ix_unitmeasurementconversionbridges_sternid",
                schema: "decisorframework_inventory",
                table: "unitmeasurementconversionbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_userrolebridges_sternid",
                schema: "guamaframework_security_personal",
                table: "userrolebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_users_identityid",
                schema: "guamaframework_security_personal",
                table: "users",
                column: "identityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehiclecategories_parentid",
                schema: "decisorframework_domain",
                table: "vehiclecategories",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleimagebridges_sternid",
                schema: "decisorframework_domain",
                table: "vehicleimagebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleimagebridges_vehicleid",
                schema: "decisorframework_domain",
                table: "vehicleimagebridges",
                column: "vehicleid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_bodyidentifier",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "bodyidentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_categoryid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_engineidentifier",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "engineidentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_enginekindid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "enginekindid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_featureimageid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_plate",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "plate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_structureid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "structureid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_trafficcirculationidentifier",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "trafficcirculationidentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_videos_thumbnailid",
                schema: "guamaframework_media",
                table: "videos",
                column: "thumbnailid");

            migrationBuilder.AddForeignKey(
                name: "fk_batches_costcenters_costcenterid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "costcenterid",
                principalSchema: "decisorframework_finantial",
                principalTable: "costcenters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "fk_properties_structures_structureid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_namingresolutions_employees_namedemployeeid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationidentities_images_imageid",
                schema: "guamaframework_identity",
                table: "organizationidentities");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_images_featureimageid",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_postalcontactitems_postalcontactid",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "fk_structures_organizationidentities_identityid",
                schema: "decisorframework_domain",
                table: "structures");

            migrationBuilder.DropForeignKey(
                name: "fk_properties_structures_structureid",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.DropTable(
                name: "bankdebitcards",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "budgetproductbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "budgetservicebridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "clausetagbridges",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "contactproductbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "contactservicebridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "departurebatchbridges",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "departures",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "departures",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "documents",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "elaborationinputproductbridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationoutputproductbridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationstepproductionrolebridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "employmentcontracts",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "legalproviderpurchasezonebridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "legalproviderpurchasingcontracts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderpurchasezonebridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "naturalproviderpurchasingcontracts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "organizationemailcontactitembridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "organizationpersonmembershipbridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "organizationphonecontactitembridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "organizationpostalcontactitembridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "organizationsocialcontactitembridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "organizationwebsitecontactitembridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "personemailcontactitembridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "personphonecontactitembridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "personpostalcontactitembridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "personsocialcontactitembridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "personwebsitecontactitembridges",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "productcustomattributebridges",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "productioncolaboratorbridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionemployeebridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionproductbridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productwarehousingdecreasekindbridges",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "proformasectionclausebridges",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "propertyimagebridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "purchasecashadvances",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchasecolaboratorbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseemployeebridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseplaninputproductbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseplanlegalproviderbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseplannaturalproviderbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseplanoutputproductbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseproductlegalproviderbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseproductnaturalproviderbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchasepurchasespentbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchasereceptionproductweightbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchasezonespentbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "receptionbatchbridges",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "receptions",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "rolepermissionbridges",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "sales",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "traces");

            migrationBuilder.DropTable(
                name: "unitmeasurementconversionbridges",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "userrolebridges",
                schema: "guamaframework_security_personal");

            migrationBuilder.DropTable(
                name: "vehicleimagebridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "videos",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "clausetags",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "services",
                schema: "decisorframework_servicing");

            migrationBuilder.DropTable(
                name: "departures",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "emailcontactitems",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "phonecontactitems",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "socialcontactitems",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "websitecontactitems",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "customattributes",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "elaborationstep",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionrole",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "clauses",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "sections",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "colaborator",
                schema: "decisorframework_essential");

            migrationBuilder.DropTable(
                name: "purchasingroles",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "legalproviders",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviders",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "receptions",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchasespents",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "batches",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "production",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "abstractbudget",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalclientsalecontracts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalclientsalecontracts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "users",
                schema: "guamaframework_security_personal");

            migrationBuilder.DropTable(
                name: "vehicles",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "purchases",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "classifications",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "costcenters",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "receptions",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "warehouses",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "productionplan",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "legalclients",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalclients",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "proformas",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "vehiclecategories",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "vehicleenginekinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "purchaseplans",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "bankaccounts",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "elaboration",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "contacts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "purchasezones",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "bankbranches",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "currencies",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "products",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "legalbusinesskinds",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalbusinesskinds",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "bankagencies",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "unitmeasurements",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "employees",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "personidentities",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "images",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "thumbnails",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "postalcontactitems",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "locations",
                schema: "guamaframework_location");

            migrationBuilder.DropTable(
                name: "localities",
                schema: "guamaframework_location");

            migrationBuilder.DropTable(
                name: "municipalities",
                schema: "guamaframework_location");

            migrationBuilder.DropTable(
                name: "states",
                schema: "guamaframework_location");

            migrationBuilder.DropTable(
                name: "regions",
                schema: "guamaframework_location");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "guamaframework_location");

            migrationBuilder.DropTable(
                name: "organizationidentities",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "structures",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "namingresolutions",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "properties",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "structurekinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "propertykinds",
                schema: "decisorframework_domain");
        }
    }
}
