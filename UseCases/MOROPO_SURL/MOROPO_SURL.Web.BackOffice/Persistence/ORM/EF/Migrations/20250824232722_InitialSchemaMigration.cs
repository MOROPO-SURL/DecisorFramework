using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
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
                name: "decisorframework_sales");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_humanresources");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_governance");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_finantial");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_inventory");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_domain");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_legal");

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
                name: "guamaframework_core_security_common");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_leasing");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_security_personal");

            migrationBuilder.CreateTable(
                name: "brands",
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
                    table.PrimaryKey("pk_brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clauses",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
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
                name: "families",
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
                    table.PrimaryKey("pk_families", x => x.id);
                    table.ForeignKey(
                        name: "fk_families_families_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "families",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "legalbusinesskinds",
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
                    table.PrimaryKey("pk_legalbusinesskinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "naturalbusinesskinds",
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
                    table.PrimaryKey("pk_naturalbusinesskinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organizationalunities",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalunities", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalunities_organizationalunities_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "paymentterms",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    term = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paymentterms", x => x.id);
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
                name: "proclamationkinds",
                schema: "decisorframework_legal",
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
                    table.PrimaryKey("pk_proclamationkinds", x => x.id);
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
                name: "regulationkinds",
                schema: "decisorframework_legal",
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
                    table.PrimaryKey("pk_regulationkinds", x => x.id);
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
                name: "salarystandards",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    fee = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_salarystandards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schoolings",
                schema: "decisorframework_humanresources",
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
                    table.PrimaryKey("pk_schoolings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sections",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    parentid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sections", x => x.id);
                    table.ForeignKey(
                        name: "fk_sections_sections_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "sections",
                        principalColumn: "id");
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
                name: "vehiclekinds",
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
                    table.PrimaryKey("pk_vehiclekinds", x => x.id);
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
                    kind = table.Column<int>(type: "integer", nullable: false),
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
                name: "workpositionkinds",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shortname = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workpositionkinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clausetagbridges",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clausetagbridges", x => new { x.prowid, x.sternid });
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
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    currencyid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchasezonespentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchasezonespentbridges_currencies_currencyid",
                        column: x => x.currencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "warehousingareas",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    warehouseid = table.Column<Guid>(type: "uuid", nullable: false),
                    capacity = table.Column<double>(type: "double precision", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    familyid = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_warehousingareas", x => x.id);
                    table.ForeignKey(
                        name: "fk_warehousingareas_families_familyid",
                        column: x => x.familyid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "families",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_warehousingareas_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_warehousingareas_warehouses_warehouseid",
                        column: x => x.warehouseid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "warehouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workpositions",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    schoolingid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workpositions", x => x.id);
                    table.ForeignKey(
                        name: "fk_workpositions_schoolings_schoolingid",
                        column: x => x.schoolingid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "schoolings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workpositions_workpositionkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositionkinds",
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
                name: "proclamations",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    releasedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proclamations", x => x.id);
                    table.ForeignKey(
                        name: "fk_proclamations_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_proclamations_proclamationkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proclamationkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    description = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    editedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    cacheddocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    cacheddocumentat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    rawdocumentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proformas", x => x.id);
                    table.ForeignKey(
                        name: "fk_proformas_documents_cacheddocumentid",
                        column: x => x.cacheddocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_proformas_documents_rawdocumentid",
                        column: x => x.rawdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
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
                    alias = table.Column<string>(type: "text", nullable: true),
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
                    alias = table.Column<string>(type: "text", nullable: true),
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
                    sex = table.Column<int>(type: "integer", nullable: false),
                    civilstatus = table.Column<int>(type: "integer", nullable: false),
                    imageid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    alias = table.Column<string>(type: "text", nullable: true),
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
                    familyid = table.Column<int>(type: "integer", nullable: true),
                    expirationtime = table.Column<TimeSpan>(type: "interval", nullable: true),
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
                        name: "fk_products_families_familyid",
                        column: x => x.familyid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "families",
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
                name: "provisionableservices",
                schema: "decisorframework_commercial",
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
                    table.PrimaryKey("pk_provisionableservices", x => x.id);
                    table.ForeignKey(
                        name: "fk_provisionableservices_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "requestableservices",
                schema: "decisorframework_commercial",
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
                    table.PrimaryKey("pk_requestableservices", x => x.id);
                    table.ForeignKey(
                        name: "fk_requestableservices_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "workpositionresponsabilities",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    workpositionid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workpositionresponsabilities", x => x.id);
                    table.ForeignKey(
                        name: "fk_workpositionresponsabilities_workpositions_workpositionid",
                        column: x => x.workpositionid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "proformasectionclausebridges",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    sectionid = table.Column<int>(type: "integer", nullable: false),
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
                name: "centralstatestructures",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_centralstatestructures", x => x.id);
                    table.ForeignKey(
                        name: "fk_centralstatestructures_organizationidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
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
                name: "colaborators",
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
                    table.PrimaryKey("pk_colaborators", x => x.id);
                    table.ForeignKey(
                        name: "fk_colaborators_personidentities_identityid",
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
                name: "productvaluepropositions",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    evaluation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productvaluepropositions", x => x.id);
                    table.ForeignKey(
                        name: "fk_productvaluepropositions_products_productid",
                        column: x => x.productid,
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
                name: "servicevaluepropositions",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    evaluation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicevaluepropositions", x => x.id);
                    table.ForeignKey(
                        name: "fk_servicevaluepropositions_requestableservices_serviceid",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "requestableservices",
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
                name: "regulations",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    proclamationid = table.Column<Guid>(type: "uuid", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_regulations_centralstatestructures_structureid",
                        column: x => x.structureid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "centralstatestructures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_regulations_proclamations_proclamationid",
                        column: x => x.proclamationid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proclamations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_regulations_regulationkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "regulationkinds",
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
                name: "elaborations",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificcationid = table.Column<Guid>(type: "uuid", nullable: true),
                    referenceamount = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    minperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    maxperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborations", x => x.id);
                    table.ForeignKey(
                        name: "fk_elaborations_classifications_classificcationid",
                        column: x => x.classificcationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_elaborations_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productvaluepropositionimagebridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productvaluepropositionimagebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productvaluepropositionimagebridges_images_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productvaluepropositionimagebridges_productvalueproposition~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "productvaluepropositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productvaluepropositionrates",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    propositionid = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    regularcost = table.Column<double>(type: "double precision", nullable: false),
                    minimumcost = table.Column<double>(type: "double precision", nullable: true),
                    maximumcost = table.Column<double>(type: "double precision", nullable: true),
                    currencyid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productvaluepropositionrates", x => x.id);
                    table.ForeignKey(
                        name: "fk_productvaluepropositionrates_currencies_currencyid",
                        column: x => x.currencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_productvaluepropositionrates_productvaluepropositions_propo~",
                        column: x => x.propositionid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "productvaluepropositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicevaluepropositionimagebridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicevaluepropositionimagebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_servicevaluepropositionimagebridges_images_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_servicevaluepropositionimagebridges_servicevalueproposition~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "servicevaluepropositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicevaluepropositionrates",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    propositionid = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    regularcost = table.Column<double>(type: "double precision", nullable: false),
                    minimumcost = table.Column<double>(type: "double precision", nullable: true),
                    maximumcost = table.Column<double>(type: "double precision", nullable: true),
                    currencyid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicevaluepropositionrates", x => x.id);
                    table.ForeignKey(
                        name: "fk_servicevaluepropositionrates_currencies_currencyid",
                        column: x => x.currencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_servicevaluepropositionrates_servicevaluepropositions_propo~",
                        column: x => x.propositionid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "servicevaluepropositions",
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
                name: "dispositions",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    regulationid = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    segment = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dispositions", x => x.id);
                    table.ForeignKey(
                        name: "fk_dispositions_regulations_regulationid",
                        column: x => x.regulationid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "regulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationinputproductbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationinputproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationinputproductbridges_elaborations_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationinputproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationinputproductclassificationbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationinputproductclassificationbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationinputproductclassificationbridges_classification~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationinputproductclassificationbridges_elaborations_p~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationoutputproductbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    minperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    maxperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationoutputproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductbridges_elaborations_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationsteps",
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
                    table.PrimaryKey("pk_elaborationsteps", x => x.id);
                    table.ForeignKey(
                        name: "fk_elaborationsteps_elaborations_elaborationid",
                        column: x => x.elaborationid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
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
                name: "dispositiontagbridges",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dispositiontagbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_dispositiontagbridges_clausetags_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clausetags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dispositiontagbridges_dispositions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "dispositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationstepworkpositionbridges",
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
                    table.PrimaryKey("pk_elaborationstepworkpositionbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationstepworkpositionbridges_elaborationsteps_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationstepworkpositionbridges_workpositions_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "personcontacts",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false),
                    personalidentificationnumber = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<string>(type: "text", nullable: true),
                    businesskindid = table.Column<Guid>(type: "uuid", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    mainpostalcontactid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personcontacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_personcontacts_naturalbusinesskinds_businesskindid",
                        column: x => x.businesskindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "naturalbusinesskinds",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_personcontacts_personidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_personcontacts_postalcontactitems_mainpostalcontactid",
                        column: x => x.mainpostalcontactid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "postalcontactitems",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_personcontacts_users_userid",
                        column: x => x.userid,
                        principalSchema: "guamaframework_security_personal",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
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
                name: "employees",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                    table.ForeignKey(
                        name: "fk_employees_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    defaultpaymenttermid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclients", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclients_paymentterms_defaultpaymenttermid",
                        column: x => x.defaultpaymenttermid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "paymentterms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclients_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviders",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    defaultpaymenttermid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviders", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalproviders_paymentterms_defaultpaymenttermid",
                        column: x => x.defaultpaymenttermid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "paymentterms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviders_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizationcontacts",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false),
                    businesskindid = table.Column<Guid>(type: "uuid", nullable: false),
                    centralstatestructureid = table.Column<Guid>(type: "uuid", nullable: true),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: true),
                    stateidentificationcode = table.Column<string>(type: "text", nullable: true),
                    representativeid = table.Column<Guid>(type: "uuid", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    mainpostalcontactid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationcontacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationcontacts_centralstatestructures_centralstatestr~",
                        column: x => x.centralstatestructureid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "centralstatestructures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationcontacts_legalbusinesskinds_businesskindid",
                        column: x => x.businesskindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "legalbusinesskinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationcontacts_organizationidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationcontacts_personcontacts_representativeid",
                        column: x => x.representativeid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationcontacts_postalcontactitems_mainpostalcontactid",
                        column: x => x.mainpostalcontactid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "postalcontactitems",
                        principalColumn: "id");
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
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionorders",
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
                    requestedfor = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    approvedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    decisorid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionorders", x => x.id);
                    table.ForeignKey(
                        name: "fk_productionorders_elaborations_elaborationid",
                        column: x => x.elaborationid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionorders_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionorders_employees_decisorid",
                        column: x => x.decisorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionorders_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
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
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplans_employees_plannerid",
                        column: x => x.plannerid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplans_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
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
                name: "naturalclientbankaccountbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientbankaccountbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalclientbankaccountbridges_bankaccounts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbankaccountbridges_naturalclients_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientdocumentbridge",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientdocumentbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalclientdocumentbridge_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientdocumentbridge_naturalclients_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
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
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    proformaid = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "naturalproviderbankaccountbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderbankaccountbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalproviderbankaccountbridges_bankaccounts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbankaccountbridges_naturalproviders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderdocumentbridge",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderdocumentbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalproviderdocumentbridge_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderdocumentbridge_naturalproviders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
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
                        name: "fk_abstractbudget_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abstractbudget_organizationcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_abstractbudget_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id");
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
                    defaultpaymenttermid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclients", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclients_organizationcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclients_paymentterms_defaultpaymenttermid",
                        column: x => x.defaultpaymenttermid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "paymentterms",
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
                    defaultpaymenttermid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviders", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalproviders_organizationcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviders_paymentterms_defaultpaymenttermid",
                        column: x => x.defaultpaymenttermid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "paymentterms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productions",
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
                    table.PrimaryKey("pk_productions", x => x.id);
                    table.ForeignKey(
                        name: "fk_productions_productionorders_planid",
                        column: x => x.planid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productionorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productions_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
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
                        principalSchema: "decisorframework_domain",
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
                        principalSchema: "decisorframework_domain",
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
                        name: "fk_budgetservicebridges_provisionableservices_serviceid",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "provisionableservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientbankaccountbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientbankaccountbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalclientbankaccountbridges_bankaccounts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbankaccountbridges_legalclients_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientdocumentbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalclientdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientdocumentbridges_legalclients_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    proformaid = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "legalproviderbankaccountbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderbankaccountbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalproviderbankaccountbridges_bankaccounts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbankaccountbridges_legalproviders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviderdocumentbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalproviderdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderdocumentbridges_legalproviders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
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
                        name: "fk_departures_productions_productionid",
                        column: x => x.productionid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "productioncolaboratorbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    stepid = table.Column<Guid>(type: "uuid", nullable: false),
                    workpositionid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productioncolaboratorbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_colaborators_sternid",
                        column: x => x.sternid,
                        principalTable: "colaborators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_elaborationsteps_stepid",
                        column: x => x.stepid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_productions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productioncolaboratorbridges_workpositions_workpositionid",
                        column: x => x.workpositionid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionemployeebridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    stepid = table.Column<Guid>(type: "uuid", nullable: false),
                    workpositionid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_elaborationsteps_stepid",
                        column: x => x.stepid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_productions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionemployeebridges_workpositions_workpositionid",
                        column: x => x.workpositionid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionproductbridges",
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
                    table.PrimaryKey("pk_productionproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productionproductbridges_productions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionproductbridges_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "fk_purchasecolaboratorbridges_colaborators_sternid",
                        column: x => x.sternid,
                        principalTable: "colaborators",
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
                        principalSchema: "decisorframework_domain",
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
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    warehouseid = table.Column<Guid>(type: "uuid", nullable: true),
                    productionid = table.Column<Guid>(type: "uuid", nullable: true),
                    purchaseid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receptions", x => x.id);
                    table.ForeignKey(
                        name: "fk_receptions_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_receptions_productions_productionid",
                        column: x => x.productionid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_receptions_purchases_purchaseid",
                        column: x => x.purchaseid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchases",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_receptions_warehouses_warehouseid",
                        column: x => x.warehouseid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "warehouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "abstractsale",
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
                    table.PrimaryKey("pk_abstractsale", x => x.id);
                    table.ForeignKey(
                        name: "fk_abstractsale_abstractbudget_budgetnumber_budgetyear",
                        columns: x => new { x.budgetnumber, x.budgetyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "abstractbudget",
                        principalColumns: new[] { "number", "year" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abstractsale_employees_sellerid",
                        column: x => x.sellerid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abstractsale_legalclientsalecontracts_contractnumber_contra~",
                        columns: x => new { x.contractnumber, x.contractyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclientsalecontracts",
                        principalColumns: new[] { "number", "year" });
                    table.ForeignKey(
                        name: "fk_abstractsale_naturalclientsalecontracts_contractnumber_cont~",
                        columns: x => new { x.contractnumber, x.contractyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclientsalecontracts",
                        principalColumns: new[] { "number", "year" });
                    table.ForeignKey(
                        name: "fk_abstractsale_personidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "admitionpropousals",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ocupationcandidateid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admitionpropousals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agreements",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    meetingid = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agreements", x => x.id);
                    table.ForeignKey(
                        name: "fk_agreements_personcontacts_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "batches",
                schema: "decisorframework_inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    externalreference = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    warehousingareaid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalTable: "receptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_batches_warehousingareas_warehousingareaid",
                        column: x => x.warehousingareaid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "warehousingareas",
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
                        principalTable: "receptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "decisionmakinggroupcontactbridges",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_decisionmakinggroupcontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_decisionmakinggroupcontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "decisionmakinggroupemployeebridges",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_decisionmakinggroupemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_decisionmakinggroupemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "decisionmakinggroups",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    leaderid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_decisionmakinggroups", x => x.id);
                    table.ForeignKey(
                        name: "fk_decisionmakinggroups_personcontacts_leaderid",
                        column: x => x.leaderid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meetings",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    decisionmakinggroupid = table.Column<Guid>(type: "uuid", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    summary = table.Column<string>(type: "text", nullable: true),
                    rapporteurship = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meetings", x => x.id);
                    table.ForeignKey(
                        name: "fk_meetings_decisionmakinggroups_decisionmakinggroupid",
                        column: x => x.decisionmakinggroupid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "decisionmakinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_meetings_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meetingcontactbridges",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meetingcontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_meetingcontactbridges_meetings_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "meetings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_meetingcontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meetingdocumentbridges",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meetingdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_meetingdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_meetingdocumentbridges_meetings_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "meetings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meetingemployeebridges",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meetingemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_meetingemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_meetingemployeebridges_meetings_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "meetings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "statements",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    meetingid = table.Column<Guid>(type: "uuid", nullable: false),
                    rapporteurship = table.Column<string>(type: "text", nullable: true),
                    contactid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_statements", x => x.id);
                    table.ForeignKey(
                        name: "fk_statements_meetings_meetingid",
                        column: x => x.meetingid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "meetings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_statements_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "employmentcontracts",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    ocupationid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employmentcontracts", x => new { x.number, x.year });
                });

            migrationBuilder.CreateTable(
                name: "ocupationcandidates",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    interviewat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    postulationid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    medicalcheckat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    rawmedicalcheckdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    physicologicalcheckat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    physicologicalcheckdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    defensestatuscheckat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    rawdefensestatuscheckdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    researchrequestat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    researchresultat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    rawresearchresultdocumentid = table.Column<Guid>(type: "uuid", nullable: true),
                    rawmodeldocumentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ocupationcandidates", x => x.id);
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_documents_physicologicalcheckdocumentid",
                        column: x => x.physicologicalcheckdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_documents_rawdefensestatuscheckdocument~",
                        column: x => x.rawdefensestatuscheckdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_documents_rawmedicalcheckdocumentid",
                        column: x => x.rawmedicalcheckdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_documents_rawmodeldocumentid",
                        column: x => x.rawmodeldocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_documents_rawresearchresultdocumentid",
                        column: x => x.rawresearchresultdocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_ocupationcandidates_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ocupations",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    staffid = table.Column<Guid>(type: "uuid", nullable: false),
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
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
                    name = table.Column<string>(type: "text", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    postalcontactid = table.Column<Guid>(type: "uuid", nullable: false),
                    featureimageid = table.Column<Guid>(type: "uuid", nullable: true),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: false),
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
                        principalColumn: "id");
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
                name: "propertyleasepropousals",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    propertyid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasepropousals", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleasepropousals_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasepropousals_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasepropousals_properties_propertyid",
                        column: x => x.propertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyspaces",
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
                    table.PrimaryKey("pk_propertyspaces", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyspaces_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_propertyspaces_properties_propertyid",
                        column: x => x.propertyid,
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
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    socialpropertyid = table.Column<Guid>(type: "uuid", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "propertyleaseoffers",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    propousalid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    openat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    closedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseoffers", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleaseoffers_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseoffers_propertyleasepropousals_propousalid",
                        column: x => x.propousalid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasepropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "structureorganizationalunitybridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_structureorganizationalunitybridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_structureorganizationalunitybridges_organizationalunities_s~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_structureorganizationalunitybridges_structures_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    assignment = table.Column<int>(type: "integer", nullable: true),
                    featureimageid = table.Column<Guid>(type: "uuid", nullable: true),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    brandid = table.Column<Guid>(type: "uuid", nullable: false),
                    model = table.Column<string>(type: "text", nullable: true),
                    year = table.Column<int>(type: "integer", nullable: false),
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
                        name: "fk_vehicles_brands_brandid",
                        column: x => x.brandid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vehicles_structures_structureid",
                        column: x => x.structureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_vehicleenginekinds_enginekindid",
                        column: x => x.enginekindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehicleenginekinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_vehiclekinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehiclekinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleaseofferclausebridge",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseofferclausebridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseofferclausebridge_clauses_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clauses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferclausebridge_propertyleaseoffers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: false),
                    stateidentificationcode = table.Column<string>(type: "text", nullable: true),
                    argument = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseorganizationpostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleaseorganizationpostulations_organizationcontacts_~",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseorganizationpostulations_propertyleaseoffers_o~",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleasepersonpostulations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    businesskindid = table.Column<Guid>(type: "uuid", nullable: false),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasepersonpostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleasepersonpostulations_naturalbusinesskinds_busine~",
                        column: x => x.businesskindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "naturalbusinesskinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasepersonpostulations_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasepersonpostulations_propertyleaseoffers_offerid",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseoffers",
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

            migrationBuilder.CreateTable(
                name: "vehicleleasepropousals",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicleid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleasepropousals", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicleleasepropousals_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasepropousals_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasepropousals_vehicles_vehicleid",
                        column: x => x.vehicleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseorganizationpostulationdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseorganizationpostulationdocumentbridges_documen~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseorganizationpostulationdocumentbridges_propert~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseorganizationpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleaseorgpostulationspacepropousalbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseorgpostulationspacepropousalbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseorgpostulationspacepropousalbridges_propertyle~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseorganizationpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseorgpostulationspacepropousalbridges_propertysp~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyspaceleasepropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasepersonpostulationdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleasepersonpostulationdocumentbridges_documents_ste~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasepersonpostulationdocumentbridges_propertylease~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasepersonpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleaseperspostulationspacepropousalbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseperspostulationspacepropousalbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseperspostulationspacepropousalbridges_propertyl~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasepersonpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseperspostulationspacepropousalbridges_propertys~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyspaceleasepropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleaseoffers",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    propousalid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    openat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    closedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleaseoffers", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicleleaseoffers_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleaseoffers_vehicleleasepropousals_propousalid",
                        column: x => x.propousalid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleasepropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleaseofferclausebridge",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleaseofferclausebridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferclausebridge_clauses_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clauses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferclausebridge_vehicleleaseoffers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: false),
                    stateidentificationcode = table.Column<string>(type: "text", nullable: true),
                    argument = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleaseorganizationpostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicleleaseorganizationpostulations_organizationcontacts_c~",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleaseorganizationpostulations_vehicleleaseoffers_off~",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleasepersonpostulations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    businesskindid = table.Column<Guid>(type: "uuid", nullable: false),
                    taxidentificationnumber = table.Column<string>(type: "text", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleasepersonpostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicleleasepersonpostulations_naturalbusinesskinds_busines~",
                        column: x => x.businesskindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "naturalbusinesskinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasepersonpostulations_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasepersonpostulations_vehicleleaseoffers_offerid",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleaseorganizationpostulationdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleleaseorganizationpostulationdocumentbridges_document~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleaseorganizationpostulationdocumentbridges_vehiclel~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleaseorganizationpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleasepersonpostulationdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleleasepersonpostulationdocumentbridges_documents_ster~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasepersonpostulationdocumentbridges_vehicleleasepe~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleasepersonpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resolutions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    summary = table.Column<string>(type: "text", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: true),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: true),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: true),
                    ocupationid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_resolutions", x => x.id);
                    table.ForeignKey(
                        name: "fk_resolutions_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_resolutions_ocupations_ocupationid",
                        column: x => x.ocupationid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "ocupations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_resolutions_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    mainworkforceid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_staffs", x => x.id);
                    table.ForeignKey(
                        name: "fk_staffs_structures_structureid",
                        column: x => x.structureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffworkforcebridges",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_staffworkforcebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_staffworkforcebridges_staffs_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacantpostulationdocumentbridges",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacantpostulationdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vacantpostulationdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vacantpostulationocupations",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    postulationid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationname = table.Column<string>(type: "text", nullable: false),
                    organizationaddress = table.Column<string>(type: "text", nullable: true),
                    representativename = table.Column<string>(type: "text", nullable: true),
                    centralstatestructureid = table.Column<Guid>(type: "uuid", nullable: true),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacantpostulationocupations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacantpostulationocupations_centralstatestructures_centrals~",
                        column: x => x.centralstatestructureid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "centralstatestructures",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vacantpostulations",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    staffid = table.Column<Guid>(type: "uuid", nullable: false),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    officialpostalcontactitemid = table.Column<Guid>(type: "uuid", nullable: false),
                    alternativepostalcontactitemid = table.Column<Guid>(type: "uuid", nullable: true),
                    schoolingid = table.Column<Guid>(type: "uuid", nullable: false),
                    schoolingcomplement = table.Column<string>(type: "text", nullable: true),
                    maleparentname = table.Column<string>(type: "text", nullable: false),
                    femaleparentname = table.Column<string>(type: "text", nullable: false),
                    alignment = table.Column<string>(type: "text", nullable: true),
                    responsabilitycommitment = table.Column<string>(type: "text", nullable: false),
                    rawmodeldocumentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacantpostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacantpostulations_documents_rawmodeldocumentid",
                        column: x => x.rawmodeldocumentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vacantpostulations_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacantpostulations_postalcontactitems_alternativepostalcont~",
                        column: x => x.alternativepostalcontactitemid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "postalcontactitems",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_vacantpostulations_postalcontactitems_officialpostalcontact~",
                        column: x => x.officialpostalcontactitemid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "postalcontactitems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacantpostulations_schoolings_schoolingid",
                        column: x => x.schoolingid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "schoolings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacantpostulations_staffs_staffid",
                        column: x => x.staffid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "staffs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "fk_vacants_workpositions_workpositionid",
                        column: x => x.workpositionid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workforces",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    responsiblevacantid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforces", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforces_vacants_responsiblevacantid",
                        column: x => x.responsiblevacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunitybridges",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunitybridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunitybridges_organizationalunities_s~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunitybridges_workforces_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ix_abstractsale_budgetnumber_budgetyear",
                schema: "decisorframework_sales",
                table: "abstractsale",
                columns: new[] { "budgetnumber", "budgetyear" });

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_contractnumber_contractyear",
                schema: "decisorframework_sales",
                table: "abstractsale",
                columns: new[] { "contractnumber", "contractyear" });

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_identityid",
                schema: "decisorframework_sales",
                table: "abstractsale",
                column: "identityid");

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_sellerid",
                schema: "decisorframework_sales",
                table: "abstractsale",
                column: "sellerid");

            migrationBuilder.CreateIndex(
                name: "ix_admitionpropousals_agreementid",
                schema: "decisorframework_humanresources",
                table: "admitionpropousals",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_admitionpropousals_ocupationcandidateid",
                schema: "decisorframework_humanresources",
                table: "admitionpropousals",
                column: "ocupationcandidateid");

            migrationBuilder.CreateIndex(
                name: "ix_agreements_index_meetingid",
                schema: "decisorframework_governance",
                table: "agreements",
                columns: new[] { "index", "meetingid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_agreements_meetingid",
                schema: "decisorframework_governance",
                table: "agreements",
                column: "meetingid");

            migrationBuilder.CreateIndex(
                name: "ix_agreements_responsibleid",
                schema: "decisorframework_governance",
                table: "agreements",
                column: "responsibleid");

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
                name: "ix_batches_warehousingareaid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "warehousingareaid");

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
                name: "ix_centralstatestructures_identityid",
                schema: "decisorframework_legal",
                table: "centralstatestructures",
                column: "identityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_classifications_productid",
                schema: "decisorframework_inventory",
                table: "classifications",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_clausetagbridges_sternid",
                schema: "decisorframework_legal",
                table: "clausetagbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_colaborators_identityid",
                table: "colaborators",
                column: "identityid");

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
                name: "ix_decisionmakinggroupcontactbridges_sternid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroupcontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_decisionmakinggroupemployeebridges_sternid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroupemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_decisionmakinggroups_leaderid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                column: "leaderid");

            migrationBuilder.CreateIndex(
                name: "ix_decisionmakinggroups_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                column: "structureid");

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
                name: "ix_dispositions_regulationid",
                schema: "decisorframework_legal",
                table: "dispositions",
                column: "regulationid");

            migrationBuilder.CreateIndex(
                name: "ix_dispositiontagbridges_sternid",
                schema: "decisorframework_legal",
                table: "dispositiontagbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_documents_thumbnailid",
                schema: "guamaframework_media",
                table: "documents",
                column: "thumbnailid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductclassificationbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborations_classificcationid",
                schema: "decisorframework_production",
                table: "elaborations",
                column: "classificcationid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborations_productid",
                schema: "decisorframework_production",
                table: "elaborations",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationsteps_elaborationid",
                schema: "decisorframework_production",
                table: "elaborationsteps",
                column: "elaborationid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationstepworkpositionbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationstepworkpositionbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_employees_contactid",
                schema: "decisorframework_domain",
                table: "employees",
                column: "contactid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_ocupationid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "ocupationid");

            migrationBuilder.CreateIndex(
                name: "ix_families_parentid",
                schema: "decisorframework_inventory",
                table: "families",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_images_thumbnailid",
                schema: "guamaframework_media",
                table: "images",
                column: "thumbnailid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalclientbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientdocumentbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalclientdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclients_contactid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "contactid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_legalclients_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "defaultpaymenttermid");

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
                name: "ix_legalproviderbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalproviderbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderdocumentbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalproviderdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderpurchasezonebridges_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderpurchasezonebridges",
                column: "sternid");

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
                name: "ix_legalproviders_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                column: "defaultpaymenttermid");

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
                name: "ix_meetingcontactbridges_sternid",
                schema: "decisorframework_governance",
                table: "meetingcontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_meetingdocumentbridges_sternid",
                schema: "decisorframework_governance",
                table: "meetingdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_meetingemployeebridges_sternid",
                schema: "decisorframework_governance",
                table: "meetingemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_meetings_authorid",
                schema: "decisorframework_governance",
                table: "meetings",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_meetings_decisionmakinggroupid",
                schema: "decisorframework_governance",
                table: "meetings",
                column: "decisionmakinggroupid");

            migrationBuilder.CreateIndex(
                name: "ix_meetings_index_decisionmakinggroupid",
                schema: "decisorframework_governance",
                table: "meetings",
                columns: new[] { "index", "decisionmakinggroupid" },
                unique: true);

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
                name: "ix_naturalclientbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "naturalclientbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientdocumentbridge_sternid",
                schema: "decisorframework_commercial",
                table: "naturalclientdocumentbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclients_contactid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "contactid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_naturalclients_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "defaultpaymenttermid");

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
                name: "ix_naturalproviderbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "naturalproviderbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderdocumentbridge_sternid",
                schema: "decisorframework_commercial",
                table: "naturalproviderdocumentbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderpurchasezonebridges_sternid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderpurchasezonebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderpurchasingcontracts_providerid",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviders_contactid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "contactid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviders_defaultpaymenttermid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "defaultpaymenttermid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_physicologicalcheckdocumentid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "physicologicalcheckdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_postulationid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "postulationid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_rawdefensestatuscheckdocumentid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "rawdefensestatuscheckdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_rawmedicalcheckdocumentid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "rawmedicalcheckdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_rawmodeldocumentid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "rawmodeldocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_rawresearchresultdocumentid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "rawresearchresultdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupationcandidates_responsibleid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_employeeid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_staffid_vacantid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                columns: new[] { "staffid", "vacantid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_vacantid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "vacantid");

            migrationBuilder.CreateIndex(
                name: "ix_ocupations_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "workforceid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalunities_parentid",
                schema: "decisorframework_domain",
                table: "organizationalunities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_businesskindid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_centralstatestructureid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "centralstatestructureid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_identityid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "identityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "mainpostalcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "representativeid");

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
                name: "ix_personcontacts_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_personcontacts_identityid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "identityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_personcontacts_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "mainpostalcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_personcontacts_userid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "userid",
                unique: true);

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
                name: "ix_proclamations_documentid",
                schema: "decisorframework_legal",
                table: "proclamations",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_proclamations_kindid",
                schema: "decisorframework_legal",
                table: "proclamations",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_productcustomattributebridges_sternid",
                schema: "decisorframework_inventory",
                table: "productcustomattributebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridges_stepid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "stepid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridges_sternid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productioncolaboratorbridges_workpositionid",
                schema: "decisorframework_production",
                table: "productioncolaboratorbridges",
                column: "workpositionid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridges_stepid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "stepid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridges_sternid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionemployeebridges_workpositionid",
                schema: "decisorframework_production",
                table: "productionemployeebridges",
                column: "workpositionid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_authorid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_decisorid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "decisorid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_elaborationid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "elaborationid");

            migrationBuilder.CreateIndex(
                name: "ix_productionorders_responsibleid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_productionproductbridges_sternid",
                schema: "decisorframework_production",
                table: "productionproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionproductbridges_unitmeasurementid",
                schema: "decisorframework_production",
                table: "productionproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_productions_planid",
                schema: "decisorframework_production",
                table: "productions",
                column: "planid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productions_unitmeasurementid",
                schema: "decisorframework_production",
                table: "productions",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_products_defaultunitmeasurementid",
                schema: "decisorframework_inventory",
                table: "products",
                column: "defaultunitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_products_familyid",
                schema: "decisorframework_inventory",
                table: "products",
                column: "familyid");

            migrationBuilder.CreateIndex(
                name: "ix_products_featureimageid",
                schema: "decisorframework_inventory",
                table: "products",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_productvaluepropositionimagebridges_sternid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositionimagebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productvaluepropositionrates_currencyid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositionrates",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "ix_productvaluepropositionrates_propositionid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositionrates",
                column: "propositionid");

            migrationBuilder.CreateIndex(
                name: "ix_productvaluepropositions_productid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositions",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_productwarehousingdecreasekindbridges_productid",
                schema: "decisorframework_inventory",
                table: "productwarehousingdecreasekindbridges",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_proformas_cacheddocumentid",
                schema: "decisorframework_legal",
                table: "proformas",
                column: "cacheddocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_proformas_rawdocumentid",
                schema: "decisorframework_legal",
                table: "proformas",
                column: "rawdocumentid");

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
                name: "ix_properties_reference",
                schema: "decisorframework_domain",
                table: "properties",
                column: "reference",
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
                name: "ix_propertyleaseofferclausebridge_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferclausebridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseoffers_agreementid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseoffers_propousalid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "propousalid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseorganizationpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseorganizationpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseorganizationpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseorgpostulationspacepropousalbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorgpostulationspacepropousalbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepersonpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepersonpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepersonpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseperspostulationspacepropousalbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseperspostulationspacepropousalbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepropousals_agreementid",
                schema: "decisorframework_leasing",
                table: "propertyleasepropousals",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepropousals_authorid",
                schema: "decisorframework_leasing",
                table: "propertyleasepropousals",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepropousals_propertyid",
                schema: "decisorframework_leasing",
                table: "propertyleasepropousals",
                column: "propertyid");

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

            migrationBuilder.CreateIndex(
                name: "ix_propertyspaces_featureimageid",
                schema: "decisorframework_domain",
                table: "propertyspaces",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyspaces_propertyid",
                schema: "decisorframework_domain",
                table: "propertyspaces",
                column: "propertyid");

            migrationBuilder.CreateIndex(
                name: "ix_provisionableservices_featureimageid",
                schema: "decisorframework_commercial",
                table: "provisionableservices",
                column: "featureimageid");

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
                name: "ix_purchasezonespentbridges_currencyid",
                schema: "decisorframework_purchasing",
                table: "purchasezonespentbridges",
                column: "currencyid");

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
                name: "ix_receptions_productionid",
                table: "receptions",
                column: "productionid");

            migrationBuilder.CreateIndex(
                name: "ix_receptions_purchaseid",
                table: "receptions",
                column: "purchaseid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_receptions_responsibleid",
                table: "receptions",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_receptions_warehouseid",
                table: "receptions",
                column: "warehouseid");

            migrationBuilder.CreateIndex(
                name: "ix_regions_countryid",
                schema: "guamaframework_location",
                table: "regions",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "ix_regulations_kindid",
                schema: "decisorframework_legal",
                table: "regulations",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_regulations_proclamationid",
                schema: "decisorframework_legal",
                table: "regulations",
                column: "proclamationid");

            migrationBuilder.CreateIndex(
                name: "ix_regulations_structureid",
                schema: "decisorframework_legal",
                table: "regulations",
                column: "structureid");

            migrationBuilder.CreateIndex(
                name: "ix_requestableservices_featureimageid",
                schema: "decisorframework_commercial",
                table: "requestableservices",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_agreementid",
                table: "resolutions",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_contactid",
                table: "resolutions",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_ocupationid",
                table: "resolutions",
                column: "ocupationid");

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_vacantid",
                table: "resolutions",
                column: "vacantid");

            migrationBuilder.CreateIndex(
                name: "ix_rolepermissionbridges_sternid",
                schema: "guamaframework_core_security_common",
                table: "rolepermissionbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_sections_parentid",
                schema: "decisorframework_legal",
                table: "sections",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_servicevaluepropositionimagebridges_sternid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositionimagebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_servicevaluepropositionrates_currencyid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositionrates",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "ix_servicevaluepropositionrates_propositionid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositionrates",
                column: "propositionid");

            migrationBuilder.CreateIndex(
                name: "ix_servicevaluepropositions_serviceid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositions",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_staffs_mainworkforceid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "mainworkforceid");

            migrationBuilder.CreateIndex(
                name: "ix_staffs_structureid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "structureid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_staffworkforcebridges_sternid",
                schema: "decisorframework_humanresources",
                table: "staffworkforcebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_statements_contactid",
                schema: "decisorframework_governance",
                table: "statements",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_statements_meetingid",
                schema: "decisorframework_governance",
                table: "statements",
                column: "meetingid");

            migrationBuilder.CreateIndex(
                name: "ix_states_regionid",
                schema: "guamaframework_location",
                table: "states",
                column: "regionid");

            migrationBuilder.CreateIndex(
                name: "ix_structureorganizationalunitybridges_sternid",
                schema: "decisorframework_domain",
                table: "structureorganizationalunitybridges",
                column: "sternid");

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
                name: "ix_vacantpostulationdocumentbridges_sternid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulationdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulationocupations_centralstatestructureid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulationocupations",
                column: "centralstatestructureid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulationocupations_postulationid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulationocupations",
                column: "postulationid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_alternativepostalcontactitemid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "alternativepostalcontactitemid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_contactid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_officialpostalcontactitemid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "officialpostalcontactitemid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_rawmodeldocumentid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "rawmodeldocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "schoolingid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_staffid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "staffid");

            migrationBuilder.CreateIndex(
                name: "ix_vacantpostulations_vacantid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
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
                name: "ix_vehicleleaseofferclausebridge_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferclausebridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseoffers_agreementid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseoffers_propousalid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "propousalid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseorganizationpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseorganizationpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseorganizationpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepersonpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepersonpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepersonpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepropousals_agreementid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepropousals_authorid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepropousals_vehicleid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals",
                column: "vehicleid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_bodyidentifier",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "bodyidentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_brandid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "brandid");

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
                name: "ix_vehicles_kindid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "kindid");

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

            migrationBuilder.CreateIndex(
                name: "ix_warehousingareas_familyid",
                schema: "decisorframework_inventory",
                table: "warehousingareas",
                column: "familyid");

            migrationBuilder.CreateIndex(
                name: "ix_warehousingareas_unitmeasurementid",
                schema: "decisorframework_inventory",
                table: "warehousingareas",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_warehousingareas_warehouseid",
                schema: "decisorframework_inventory",
                table: "warehousingareas",
                column: "warehouseid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunitybridges_sternid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_workforces_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "responsiblevacantid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_workpositionresponsabilities_workpositionid",
                schema: "decisorframework_humanresources",
                table: "workpositionresponsabilities",
                column: "workpositionid");

            migrationBuilder.CreateIndex(
                name: "ix_workpositions_kindid",
                schema: "decisorframework_humanresources",
                table: "workpositions",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_workpositions_schoolingid",
                schema: "decisorframework_humanresources",
                table: "workpositions",
                column: "schoolingid");

            migrationBuilder.AddForeignKey(
                name: "fk_admitionpropousals_agreements_agreementid",
                schema: "decisorframework_humanresources",
                table: "admitionpropousals",
                column: "agreementid",
                principalSchema: "decisorframework_governance",
                principalTable: "agreements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_admitionpropousals_ocupationcandidates_ocupationcandidateid",
                schema: "decisorframework_humanresources",
                table: "admitionpropousals",
                column: "ocupationcandidateid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "ocupationcandidates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_agreements_meetings_meetingid",
                schema: "decisorframework_governance",
                table: "agreements",
                column: "meetingid",
                principalSchema: "decisorframework_governance",
                principalTable: "meetings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "fk_decisionmakinggroupcontactbridges_decisionmakinggroups_prow~",
                schema: "decisorframework_governance",
                table: "decisionmakinggroupcontactbridges",
                column: "prowid",
                principalSchema: "decisorframework_governance",
                principalTable: "decisionmakinggroups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_decisionmakinggroupemployeebridges_decisionmakinggroups_pro~",
                schema: "decisorframework_governance",
                table: "decisionmakinggroupemployeebridges",
                column: "prowid",
                principalSchema: "decisorframework_governance",
                principalTable: "decisionmakinggroups",
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
                name: "fk_employmentcontracts_ocupations_ocupationid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "ocupationid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "ocupations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_ocupationcandidates_vacantpostulations_postulationid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "postulationid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacantpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_ocupations_staffs_staffid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staffs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_ocupations_vacants_vacantid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_ocupations_workforces_workforceid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "workforceid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforces",
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
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_staffs_workforces_mainworkforceid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "mainworkforceid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_staffworkforcebridges_workforces_sternid",
                schema: "decisorframework_humanresources",
                table: "staffworkforcebridges",
                column: "sternid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vacantpostulationdocumentbridges_vacantpostulations_prowid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulationdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacantpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vacantpostulationocupations_vacantpostulations_postulationid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulationocupations",
                column: "postulationid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacantpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vacantpostulations_vacants_vacantid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vacants_workforces_workforceid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropForeignKey(
                name: "fk_vacants_workpositions_workpositionid",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropForeignKey(
                name: "fk_workforces_vacants_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropTable(
                name: "abstractsale",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "admitionpropousals",
                schema: "decisorframework_humanresources");

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
                name: "decisionmakinggroupcontactbridges",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "decisionmakinggroupemployeebridges",
                schema: "decisorframework_governance");

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
                name: "dispositiontagbridges",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "elaborationinputproductbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationinputproductclassificationbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationoutputproductbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationstepworkpositionbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "employmentcontracts",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "legalclientbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalclientdocumentbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalproviderbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalproviderdocumentbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalproviderpurchasezonebridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "legalproviderpurchasingcontracts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "meetingcontactbridges",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "meetingdocumentbridges",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "meetingemployeebridges",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "naturalclientbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalclientdocumentbridge",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderdocumentbridge",
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
                name: "productioncolaboratorbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionemployeebridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productionproductbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productvaluepropositionimagebridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "productvaluepropositionrates",
                schema: "decisorframework_commercial");

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
                name: "propertyleaseofferclausebridge",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleaseorgpostulationspacepropousalbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleaseperspostulationspacepropousalbridges",
                schema: "decisorframework_leasing");

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
                name: "resolutions");

            migrationBuilder.DropTable(
                name: "rolepermissionbridges",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "servicevaluepropositionimagebridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "servicevaluepropositionrates",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "staffworkforcebridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "statements",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "structureorganizationalunitybridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "traces");

            migrationBuilder.DropTable(
                name: "unitmeasurementconversionbridges",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "userrolebridges",
                schema: "guamaframework_security_personal");

            migrationBuilder.DropTable(
                name: "vacantpostulationdocumentbridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vacantpostulationocupations",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vehicleimagebridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "vehicleleaseofferclausebridge",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehicleleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehicleleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "videos",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunitybridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "workpositionresponsabilities",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "legalclientsalecontracts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalclientsalecontracts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "ocupationcandidates",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "abstractbudget",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "provisionableservices",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "departures",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "clausetags",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "dispositions",
                schema: "decisorframework_legal");

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
                name: "elaborationsteps",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productvaluepropositions",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "sections",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "propertyleaseorganizationpostulations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleasepersonpostulations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyspaceleasepropousals",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "colaborators");

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
                name: "purchasespents",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "batches",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "ocupations",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "servicevaluepropositions",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "clauses",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "vehicleleaseorganizationpostulations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehicleleasepersonpostulations",
                schema: "decisorframework_leasing");

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
                name: "vacantpostulations",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "regulations",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "propertyleaseoffers",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyspaces",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "costcenters",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "receptions");

            migrationBuilder.DropTable(
                name: "warehousingareas",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "requestableservices",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "vehicleleaseoffers",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "organizationcontacts",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "paymentterms",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "staffs",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "proclamations",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "regulationkinds",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "propertyleasepropousals",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "bankaccounts",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "productions",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "purchases",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "warehouses",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "vehicleleasepropousals",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "centralstatestructures",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "legalbusinesskinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "documents",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "proclamationkinds",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "bankbranches",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "currencies",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "productionorders",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "purchaseplans",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "agreements",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "vehicles",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "bankagencies",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "elaborations",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "purchasezones",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "meetings",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "vehicleenginekinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "vehiclekinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "classifications",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "decisionmakinggroups",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "employees",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "products",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "personcontacts",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "families",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "unitmeasurements",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "naturalbusinesskinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "users",
                schema: "guamaframework_security_personal");

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
                name: "properties",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "structurekinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "propertykinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "workpositions",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "schoolings",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "workpositionkinds",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vacants",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "organizationalunities",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "salarystandards",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "workforces",
                schema: "decisorframework_humanresources");
        }
    }
}
