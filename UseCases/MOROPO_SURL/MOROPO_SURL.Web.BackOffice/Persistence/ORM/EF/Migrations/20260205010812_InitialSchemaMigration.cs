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
                name: "decisorframework_leasing");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_identity");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_commercial");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_core_security_common");

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
                name: "knowledgeareas",
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
                    table.PrimaryKey("pk_knowledgeareas", x => x.id);
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
                schema: "decisorframework_domain",
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
                schema: "decisorframework_domain",
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
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_unitmeasurementconversionbridges_unitmeasurements_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
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
                        principalSchema: "decisorframework_domain",
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
                        principalSchema: "decisorframework_domain",
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
                schema: "decisorframework_domain",
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
                schema: "decisorframework_domain",
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
                        principalSchema: "decisorframework_domain",
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
                name: "changenotifications",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    kind = table.Column<int>(type: "integer", nullable: false),
                    changekind = table.Column<int>(type: "integer", nullable: false),
                    authorid = table.Column<string>(type: "text", nullable: false),
                    entityname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    cached = table.Column<string>(type: "character varying(10240)", maxLength: 10240, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_changenotifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_changenotifications_users_authorid",
                        column: x => x.authorid,
                        principalSchema: "guamaframework_security_personal",
                        principalTable: "users",
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
                    name = table.Column<string>(type: "text", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificcationid = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
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
                name: "changenotificationuserbridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<string>(type: "text", nullable: false),
                    readedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_changenotificationuserbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_changenotificationuserbridges_changenotifications_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "changenotifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_changenotificationuserbridges_users_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_security_personal",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationdocumentbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationdocumentbridges_elaborations_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
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
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
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
                    table.ForeignKey(
                        name: "fk_elaborationinputproductbridges_unitmeasurements_unitmeasure~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
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
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
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
                    table.ForeignKey(
                        name: "fk_elaborationinputproductclassificationbridges_unitmeasuremen~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
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
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductbridges_unitmeasurements_unitmeasur~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "elaborationoutputproductclassificationbridges",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    minperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    maxperformancecoefficient = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_elaborationoutputproductclassificationbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductclassificationbridges_classificatio~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductclassificationbridges_elaborations_~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_elaborationoutputproductclassificationbridges_unitmeasureme~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
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
                    description = table.Column<string>(type: "text", nullable: false),
                    mindecrease = table.Column<decimal>(type: "numeric", nullable: false),
                    maxdecrease = table.Column<decimal>(type: "numeric", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true)
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
                    table.ForeignKey(
                        name: "fk_elaborationsteps_elaborationsteps_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborationsteps",
                        principalColumn: "id");
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
                    participation = table.Column<decimal>(type: "numeric", nullable: true),
                    relative = table.Column<bool>(type: "boolean", nullable: false),
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
                    skinkind = table.Column<int>(type: "integer", nullable: false),
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
                name: "drivelicences",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    reference = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    releasedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expireat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    limitation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drivelicences", x => x.id);
                    table.ForeignKey(
                        name: "fk_drivelicences_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
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
                        principalSchema: "decisorframework_domain",
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
                name: "drivelicencevehiclekindbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    category = table.Column<int>(type: "integer", nullable: false),
                    specification = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    achievedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drivelicencevehiclekindbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_drivelicencevehiclekindbridges_drivelicences_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "drivelicences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_drivelicencevehiclekindbridges_vehiclekinds_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehiclekinds",
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
                name: "employeedailycheckings",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    employeeid = table.Column<Guid>(type: "uuid", nullable: false),
                    day = table.Column<int>(type: "integer", nullable: false),
                    month = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    checkin = table.Column<TimeSpan>(type: "interval", nullable: false),
                    partialcheckout = table.Column<TimeSpan>(type: "interval", nullable: true),
                    partialcheckin = table.Column<TimeSpan>(type: "interval", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "purchaserequests",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaserequests", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaserequests_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "supervisiongroups",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    representativeid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supervisiongroups", x => x.id);
                    table.ForeignKey(
                        name: "fk_supervisiongroups_employees_representativeid",
                        column: x => x.representativeid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
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
                name: "naturalclientbudget",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sharedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    confirmedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    commercialid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientbudget", x => new { x.number, x.year, x.clientid });
                    table.ForeignKey(
                        name: "fk_naturalclientbudget_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_naturalclientbudget_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbudget_naturalclients_clientid",
                        column: x => x.clientid,
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true),
                    proformaid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientsalecontracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclientsalecontracts_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
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
                name: "naturalproviderbudgets",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sharedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    confirmedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    commercialid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderbudgets", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgets_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgets_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgets_naturalproviders_providerid",
                        column: x => x.providerid,
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderpurchasingcontracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalproviderpurchasingcontracts_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_naturalproviderpurchasingcontracts_naturalproviders_provide~",
                        column: x => x.providerid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
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
                name: "purchaserequestexpectedproductadquisitions",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    requestid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaserequestexpectedproductadquisitions", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaserequestexpectedproductadquisitions_classifications_~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchaserequestexpectedproductadquisitions_products_product~",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaserequestexpectedproductadquisitions_purchaserequests~",
                        column: x => x.requestid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaserequests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaserequestexpectedproductadquisitions_unitmeasurements~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "supervisiongroupemployeebridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supervisiongroupemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_supervisiongroupemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_supervisiongroupemployeebridges_supervisiongroups_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientbudgetproductbridge",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientbudgetproductbridge", x => new { x.budgetnumber, x.budgetyear, x.clientid, x.productid, x.classificationid });
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetproductbridge_classifications_classifica~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetproductbridge_naturalclientbudget_budget~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.clientid },
                        principalSchema: "decisorframework_sales",
                        principalTable: "naturalclientbudget",
                        principalColumns: new[] { "number", "year", "clientid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetproductbridge_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetproductbridge_unitmeasurements_unitmeasu~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientbudgetservicebridge",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientbudgetservicebridge", x => new { x.budgetnumber, x.budgetyear, x.clientid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetservicebridge_naturalclientbudget_budget~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.clientid },
                        principalSchema: "decisorframework_sales",
                        principalTable: "naturalclientbudget",
                        principalColumns: new[] { "number", "year", "clientid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetservicebridge_provisionableservices_serv~",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "provisionableservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderbudgetproducts",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    budgetid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: true),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    currentyid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderbudgetproducts", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproducts_classifications_classificatio~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproducts_currencies_currentyid",
                        column: x => x.currentyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproducts_naturalproviderbudgets_budget~",
                        column: x => x.budgetid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "naturalproviderbudgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproducts_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproducts_unitmeasurements_unitmeasurem~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    currentyid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderbudgetservicebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetservicebridges_currencies_currentyid",
                        column: x => x.currentyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetservicebridges_naturalproviderbudgets_~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "naturalproviderbudgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetservicebridges_requestableservices_ste~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "requestableservices",
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
                name: "legalclientbudget",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sharedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    confirmedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    commercialid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientbudget", x => new { x.number, x.year, x.clientid });
                    table.ForeignKey(
                        name: "fk_legalclientbudget_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_legalclientbudget_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbudget_legalclients_clientid",
                        column: x => x.clientid,
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true),
                    proformaid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientsalecontracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclientsalecontracts_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
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
                name: "legalproviderbudgets",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sharedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    confirmedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    commercialid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderbudgets", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgets_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_legalproviderbudgets_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgets_legalproviders_providerid",
                        column: x => x.providerid,
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderpurchasingcontracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalproviderpurchasingcontracts_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_legalproviderpurchasingcontracts_legalproviders_providerid",
                        column: x => x.providerid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientbudgetproductbridge",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientbudgetproductbridge", x => new { x.budgetnumber, x.budgetyear, x.clientid, x.productid, x.classificationid });
                    table.ForeignKey(
                        name: "fk_legalclientbudgetproductbridge_classifications_classificati~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbudgetproductbridge_legalclientbudget_budgetnumb~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.clientid },
                        principalSchema: "decisorframework_sales",
                        principalTable: "legalclientbudget",
                        principalColumns: new[] { "number", "year", "clientid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbudgetproductbridge_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbudgetproductbridge_unitmeasurements_unitmeasure~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientbudgetservicebridge",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientbudgetservicebridge", x => new { x.budgetnumber, x.budgetyear, x.clientid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_legalclientbudgetservicebridge_legalclientbudget_budgetnumb~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.clientid },
                        principalSchema: "decisorframework_sales",
                        principalTable: "legalclientbudget",
                        principalColumns: new[] { "number", "year", "clientid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbudgetservicebridge_provisionableservices_servic~",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "provisionableservices",
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
                    legalclientsalecontractid = table.Column<Guid>(type: "uuid", nullable: true),
                    budgetnumber = table.Column<int>(type: "integer", nullable: true),
                    budgetyear = table.Column<int>(type: "integer", nullable: true),
                    naturalclientsalecontractid = table.Column<Guid>(type: "uuid", nullable: true),
                    identityid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abstractsale", x => x.id);
                    table.ForeignKey(
                        name: "fk_abstractsale_employees_sellerid",
                        column: x => x.sellerid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abstractsale_legalclientsalecontracts_legalclientsalecontra~",
                        column: x => x.legalclientsalecontractid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclientsalecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abstractsale_naturalclientsalecontracts_naturalclientsaleco~",
                        column: x => x.naturalclientsalecontractid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclientsalecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abstractsale_personidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "legalproviderbudgetproducts",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    budgetid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: true),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    currentyid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderbudgetproducts", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproducts_classifications_classificationid",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproducts_currencies_currentyid",
                        column: x => x.currentyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproducts_legalproviderbudgets_budgetid",
                        column: x => x.budgetid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "legalproviderbudgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproducts_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproducts_unitmeasurements_unitmeasuremen~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    currentyid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderbudgetservicebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetservicebridges_currencies_currentyid",
                        column: x => x.currentyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetservicebridges_legalproviderbudgets_prow~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "legalproviderbudgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetservicebridges_requestableservices_stern~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "requestableservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionorders", x => x.id);
                    table.ForeignKey(
                        name: "fk_productionorders_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionorders_elaborations_elaborationid",
                        column: x => x.elaborationid,
                        principalSchema: "decisorframework_production",
                        principalTable: "elaborations",
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
                name: "purchaseorders",
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
                    requestid = table.Column<Guid>(type: "uuid", nullable: true),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    zoneid = table.Column<Guid>(type: "uuid", nullable: false),
                    advancerequired = table.Column<float>(type: "real", nullable: true),
                    advancerequiredcurrencyid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorders", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaseorders_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorders_currencies_advancerequiredcurrencyid",
                        column: x => x.advancerequiredcurrencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchaseorders_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorders_purchaserequests_requestid",
                        column: x => x.requestid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaserequests",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchaseorders_purchasezones_zoneid",
                        column: x => x.zoneid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasezones",
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
                        principalSchema: "decisorframework_domain",
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
                    purchaseorderid = table.Column<Guid>(type: "uuid", nullable: true)
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
                        name: "fk_departures_purchaseorders_purchaseorderid",
                        column: x => x.purchaseorderid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchasecashadvances",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchaseorderid = table.Column<Guid>(type: "uuid", nullable: true),
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
                        name: "fk_purchasecashadvances_purchaseorders_purchaseorderid",
                        column: x => x.purchaseorderid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchaseorderexpectedproductresults",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderexpectedproductresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaseorderexpectedproductresults_classifications_classif~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchaseorderexpectedproductresults_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderexpectedproductresults_purchaseorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderexpectedproductresults_unitmeasurements_unitme~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseorderlegalproviderbudgetbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderlegalproviderbudgetbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseorderlegalproviderbudgetbridges_legalproviderbudget~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "legalproviderbudgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderlegalproviderbudgetbridges_purchaseorders_prow~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseordernaturalproviderbudgetbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseordernaturalproviderbudgetbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseordernaturalproviderbudgetbridges_naturalproviderbu~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "naturalproviderbudgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseordernaturalproviderbudgetbridges_purchaseorders_pr~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseorderplannedproductspents",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderplannedproductspents", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaseorderplannedproductspents_classifications_classific~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchaseorderplannedproductspents_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderplannedproductspents_purchaseorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderplannedproductspents_unitmeasurements_unitmeas~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
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
                    orderid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "fk_purchases_purchaseorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
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
                        principalSchema: "decisorframework_domain",
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
                        principalSchema: "decisorframework_domain",
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
                        principalSchema: "decisorframework_domain",
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
                name: "collects",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expectedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                        principalSchema: "decisorframework_domain",
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
                        principalSchema: "decisorframework_domain",
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
                        name: "fk_meetings_personcontacts_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    staffid = table.Column<Guid>(type: "uuid", nullable: false),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: false),
                    employeeid = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    admitionpropousalid = table.Column<Guid>(type: "uuid", nullable: true),
                    resolutionid = table.Column<Guid>(type: "uuid", nullable: true),
                    interviewat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    index = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employmentcontracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_employmentcontracts_admitionpropousals_admitionpropousalid",
                        column: x => x.admitionpropousalid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "admitionpropousals",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_employmentcontracts_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_employmentcontracts_employees_employeeid",
                        column: x => x.employeeid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_employmentcontracts_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "leasecontracts",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    feed = table.Column<double>(type: "double precision", nullable: false),
                    paymenttermid = table.Column<Guid>(type: "uuid", nullable: false),
                    bankaccountid = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    propertyleaselegalpostulationid = table.Column<Guid>(type: "uuid", nullable: true),
                    propertyleaselegalclientid = table.Column<Guid>(type: "uuid", nullable: true),
                    vehicleleaselegalpostulationid = table.Column<Guid>(type: "uuid", nullable: true),
                    vehicleleaselegalclientid = table.Column<Guid>(type: "uuid", nullable: true),
                    propertyleasenaturalpostulationid = table.Column<Guid>(type: "uuid", nullable: true),
                    propertyleasenaturalclientid = table.Column<Guid>(type: "uuid", nullable: true),
                    vehicleleasenaturalpostulationid = table.Column<Guid>(type: "uuid", nullable: true),
                    vehicleleasenaturalclientid = table.Column<Guid>(type: "uuid", nullable: true),
                    index = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_leasecontracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_leasecontracts_bankaccounts_bankaccountid",
                        column: x => x.bankaccountid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_leasecontracts_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_leasecontracts_legalclients_propertyleaselegalclientid",
                        column: x => x.propertyleaselegalclientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_leasecontracts_legalclients_vehicleleaselegalclientid",
                        column: x => x.vehicleleaselegalclientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_leasecontracts_naturalclients_propertyleasenaturalclientid",
                        column: x => x.propertyleasenaturalclientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_leasecontracts_naturalclients_vehicleleasenaturalclientid",
                        column: x => x.vehicleleasenaturalclientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_leasecontracts_paymentterms_paymenttermid",
                        column: x => x.paymenttermid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "paymentterms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientpropertyleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    costcenterid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientpropertyleasings", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclientpropertyleasings_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientpropertyleasings_costcenters_costcenterid",
                        column: x => x.costcenterid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "costcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientpropertyleasings_leasecontracts_contractid",
                        column: x => x.contractid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "leasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientvehicleleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    costcenterid = table.Column<Guid>(type: "uuid", nullable: false),
                    operativelicencecode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientvehicleleasings", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclientvehicleleasings_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientvehicleleasings_costcenters_costcenterid",
                        column: x => x.costcenterid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "costcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientvehicleleasings_leasecontracts_contractid",
                        column: x => x.contractid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "leasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientpropertyleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    costcenterid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientpropertyleasings", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclientpropertyleasings_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientpropertyleasings_costcenters_costcenterid",
                        column: x => x.costcenterid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "costcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientpropertyleasings_leasecontracts_contractid",
                        column: x => x.contractid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "leasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientvehicleleasings",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    costcenterid = table.Column<Guid>(type: "uuid", nullable: false),
                    operativelicencecode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientvehicleleasings", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclientvehicleleasings_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientvehicleleasings_costcenters_costcenterid",
                        column: x => x.costcenterid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "costcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientvehicleleasings_leasecontracts_contractid",
                        column: x => x.contractid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "leasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientpropertyleasingcompensations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientpropertyleasingcompensations", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclientpropertyleasingcompensations_agreements_agreemen~",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientpropertyleasingcompensations_legalclientproperty~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientpropleaspersoncontactbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientpropleaspersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientpropleaspersoncontactbridges_legalclientpropertyle~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientpropleaspersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientpropsupervcontrolactions",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientpropsupervcontrolactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_legclientpropsupervcontrolactions_legalclientpropertyleasin~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientpropsupervcontrolactions_supervisiongroups_supervi~",
                        column: x => x.supervisiongroupid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientvehicleleasingcompensations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientvehicleleasingcompensations", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclientvehicleleasingcompensations_agreements_agreement~",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientvehicleleasingcompensations_legalclientvehiclele~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientvehleasdrivlicbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientvehleasdrivlicbridges_drivelicences_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "drivelicences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientvehleasdrivlicbridges_legalclientvehicleleasings_p~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientvehsupervcontrolactions",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientvehsupervcontrolactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_legclientvehsupervcontrolactions_legalclientvehicleleasings~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientvehsupervcontrolactions_supervisiongroups_supervis~",
                        column: x => x.supervisiongroupid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientpropleaspersoncontactbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientpropleaspersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientpropleaspersoncontactbridges_naturalclientproperty~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientpropleaspersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientpropsupervcontrolactions",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientpropsupervcontrolactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_natclientpropsupervcontrolactions_naturalclientpropertyleas~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientpropsupervcontrolactions_supervisiongroups_supervi~",
                        column: x => x.supervisiongroupid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientpropertyleasingcompensations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientpropertyleasingcompensations", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclientpropertyleasingcompensations_agreements_agreem~",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientpropertyleasingcompensations_naturalclientprop~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientpropertyleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientvehleasdrivlicbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientvehleasdrivlicbridges_drivelicences_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "drivelicences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientvehleasdrivlicbridges_naturalclientvehicleleasings~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientvehsupervcontrolactions",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    supervisiongroupid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientvehsupervcontrolactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_natclientvehsupervcontrolactions_naturalclientvehicleleasin~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientvehsupervcontrolactions_supervisiongroups_supervis~",
                        column: x => x.supervisiongroupid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "supervisiongroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientvehicleleasingcompensations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leasingid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    discountfraction = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientvehicleleasingcompensations", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclientvehicleleasingcompensations_agreements_agreeme~",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientvehicleleasingcompensations_naturalclientvehic~",
                        column: x => x.leasingid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientpropleascompdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientpropleascompdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientpropleascompdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientpropleascompdocumentbridges_legalclientpropertylea~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientpropertyleasingcompensations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientvehleascompdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientvehleascompdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientvehleascompdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientvehleascompdocumentbridges_legalclientvehicleleasi~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasingcompensations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientpropleascompdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientpropleascompdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientpropleascompdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientpropleascompdocumentbridges_naturalclientpropertyl~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientpropertyleasingcompensations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientvehleascompdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientvehleascompdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientvehleascompdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientvehleascompdocumentbridges_naturalclientvehiclelea~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasingcompensations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientpropleascontractspacebridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientpropleascontractspacebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientpropleascontractspacebridges_leasecontracts_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "leasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientpropeleascontractspacebridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientpropeleascontractspacebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientpropeleascontractspacebridges_leasecontracts_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "leasecontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    staffid = table.Column<Guid>(type: "uuid", nullable: false),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: false),
                    contractid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ocupations", x => x.id);
                    table.ForeignKey(
                        name: "fk_ocupations_employmentcontracts_contractid",
                        column: x => x.contractid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employmentcontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    baselineamount = table.Column<decimal>(type: "numeric", nullable: false),
                    baselinecurrencyid = table.Column<Guid>(type: "uuid", nullable: false)
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
                        name: "fk_propertyleasepropousals_currencies_baselinecurrencyid",
                        column: x => x.baselinecurrencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
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
                    leasedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    baselineamount = table.Column<decimal>(type: "numeric", nullable: false),
                    baselinecurrencyid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "fk_propertyleaseoffers_currencies_baselinecurrencyid",
                        column: x => x.baselinecurrencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
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
                    operativelicencecode = table.Column<string>(type: "text", nullable: false),
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
                name: "propertyleaseofferspacespecifications",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    spaceid = table.Column<Guid>(type: "uuid", nullable: false),
                    baselineamount = table.Column<decimal>(type: "numeric", nullable: false),
                    baselinecurrencyid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseofferspacespecifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferspacespecifications_currencies_baselinecu~",
                        column: x => x.baselinecurrencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferspacespecifications_propertyleaseoffers_o~",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferspacespecifications_propertyspaces_spaceid",
                        column: x => x.spaceid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "propertyspaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propleasorgpostulations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: false),
                    bankaccountid = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propleasorgpostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_propleasorgpostulations_bankaccounts_bankaccountid",
                        column: x => x.bankaccountid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propleasorgpostulations_organizationcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propleasorgpostulations_propertyleaseoffers_offerid",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propleaspersonpostulations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: false),
                    bankaccountid = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propleaspersonpostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_propleaspersonpostulations_bankaccounts_bankaccountid",
                        column: x => x.bankaccountid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propleaspersonpostulations_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propleaspersonpostulations_propertyleaseoffers_offerid",
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
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    baselineamount = table.Column<decimal>(type: "numeric", nullable: false),
                    baselinecurrencyid = table.Column<Guid>(type: "uuid", nullable: false)
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
                        name: "fk_vehicleleasepropousals_currencies_baselinecurrencyid",
                        column: x => x.baselinecurrencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
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
                name: "propertyleaseofferspacespecificationclausebridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseofferspacespecificationclausebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseofferspacespecificationclausebridges_clauses_s~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clauses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferspacespecificationclausebridges_propertyl~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseofferspacespecifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propleaseorgpostspacepropousalbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propleaseorgpostspacepropousalbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propleaseorgpostspacepropousalbridges_propertyspaceleasepro~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyspaceleasepropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propleaseorgpostspacepropousalbridges_propleasorgpostulatio~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propleasorgpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propleasorgpostdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propleasorgpostdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propleasorgpostdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propleasorgpostdocumentbridges_propleasorgpostulations_prow~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propleasorgpostulations",
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
                        name: "fk_propertyleasepersonpostulationdocumentbridges_propleasperso~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propleaspersonpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propleasperspostspacepropbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propleasperspostspacepropbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propleasperspostspacepropbridges_propertyspaceleasepropousa~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyspaceleasepropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propleasperspostspacepropbridges_propleaspersonpostulations~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propleaspersonpostulations",
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
                    leasedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    baselineamount = table.Column<decimal>(type: "numeric", nullable: false),
                    baselinecurrencyid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "fk_vehicleleaseoffers_currencies_baselinecurrencyid",
                        column: x => x.baselinecurrencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
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
                name: "vehleasorgpostulations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: false),
                    bankaccountid = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehleasorgpostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehleasorgpostulations_bankaccounts_bankaccountid",
                        column: x => x.bankaccountid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehleasorgpostulations_organizationcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehleasorgpostulations_vehicleleaseoffers_offerid",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehleaspersonpostulations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    offerid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: false),
                    bankaccountid = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehleaspersonpostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehleaspersonpostulations_bankaccounts_bankaccountid",
                        column: x => x.bankaccountid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehleaspersonpostulations_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehleaspersonpostulations_vehicleleaseoffers_offerid",
                        column: x => x.offerid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehicleleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehleasorgpostdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehleasorgpostdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehleasorgpostdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehleasorgpostdocumentbridges_vehleasorgpostulations_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehleasorgpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehleaspersonpostdocumentbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehleaspersonpostdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehleaspersonpostdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehleaspersonpostdocumentbridges_vehleaspersonpostulations_~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "vehleaspersonpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resolutions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    summary = table.Column<string>(type: "text", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: true),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: true),
                    staffid = table.Column<Guid>(type: "uuid", nullable: true),
                    contactid = table.Column<Guid>(type: "uuid", nullable: true),
                    candidateid = table.Column<Guid>(type: "uuid", nullable: true),
                    concretedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
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
                        name: "fk_resolutions_ocupationcandidates_candidateid",
                        column: x => x.candidateid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "ocupationcandidates",
                        principalColumn: "id");
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
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    mainworkforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    workingdaycount = table.Column<int>(type: "integer", nullable: false)
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
                        principalSchema: "decisorframework_domain",
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
                    ocupationmode = table.Column<int>(type: "integer", nullable: false),
                    workpositionid = table.Column<Guid>(type: "uuid", nullable: false),
                    workforceorganizationalunityid = table.Column<Guid>(type: "uuid", nullable: true),
                    salarystandardid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacants", x => x.id);
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
                    chiefvacantid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforces", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforces_vacants_chiefvacantid",
                        column: x => x.chiefvacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunities",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationalunityid = table.Column<Guid>(type: "uuid", nullable: false),
                    chiefvacantid = table.Column<Guid>(type: "uuid", nullable: true),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunities", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_organizationalunities_organi~",
                        column: x => x.organizationalunityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_vacants_chiefvacantid",
                        column: x => x.chiefvacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_workforceorganizationaluniti~",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforceorganizationalunities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_workforces_workforceid",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_identityid",
                schema: "decisorframework_sales",
                table: "abstractsale",
                column: "identityid");

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_legalclientsalecontractid",
                schema: "decisorframework_sales",
                table: "abstractsale",
                column: "legalclientsalecontractid");

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_naturalclientsalecontractid",
                schema: "decisorframework_sales",
                table: "abstractsale",
                column: "naturalclientsalecontractid");

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
                name: "ix_centralstatestructures_identityid",
                schema: "decisorframework_domain",
                table: "centralstatestructures",
                column: "identityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_changenotifications_authorid",
                schema: "decisorframework_domain",
                table: "changenotifications",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_changenotificationuserbridges_sternid",
                schema: "decisorframework_domain",
                table: "changenotificationuserbridges",
                column: "sternid");

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
                schema: "decisorframework_domain",
                table: "colaborators",
                column: "identityid",
                unique: true);

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
                name: "ix_departures_purchaseorderid",
                schema: "decisorframework_purchasing",
                table: "departures",
                column: "purchaseorderid");

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
                name: "ix_drivelicences_contactid",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_drivelicencevehiclekindbridges_sternid",
                schema: "decisorframework_leasing",
                table: "drivelicencevehiclekindbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationdocumentbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductbridges_unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationinputproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductclassificationbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationinputproductclassificationbridges_unitmeasuremen~",
                schema: "decisorframework_production",
                table: "elaborationinputproductclassificationbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductbridges_unitmeasurementid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductclassificationbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationoutputproductclassificationbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationoutputproductclassificationbridges_unitmeasureme~",
                schema: "decisorframework_production",
                table: "elaborationoutputproductclassificationbridges",
                column: "unitmeasurementid");

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
                name: "ix_elaborationsteps_parentid",
                schema: "decisorframework_production",
                table: "elaborationsteps",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_elaborationstepworkpositionbridges_sternid",
                schema: "decisorframework_production",
                table: "elaborationstepworkpositionbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_employeedailycheckings_employeeid_day_month_year",
                schema: "decisorframework_humanresources",
                table: "employeedailycheckings",
                columns: new[] { "employeeid", "day", "month", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employees_contactid",
                schema: "decisorframework_domain",
                table: "employees",
                column: "contactid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_admitionpropousalid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "admitionpropousalid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_documentid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_index_year",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                columns: new[] { "index", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "resolutionid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_staffid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "staffid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_vacantid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "vacantid");

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
                name: "ix_leasecontracts_bankaccountid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "bankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_documentid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_index_year",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                columns: new[] { "index", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_paymenttermid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "paymenttermid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_propertyleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleaselegalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_propertyleaselegalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleaselegalpostulationid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_propertyleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleasenaturalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_propertyleasenaturalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleasenaturalpostulationid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_vehicleleaselegalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleaselegalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_vehicleleaselegalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleaselegalpostulationid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_vehicleleasenaturalclientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleasenaturalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_vehicleleasenaturalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleasenaturalpostulationid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalclientbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudget_clientid",
                schema: "decisorframework_sales",
                table: "legalclientbudget",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudget_commercialid",
                schema: "decisorframework_sales",
                table: "legalclientbudget",
                column: "commercialid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudget_documentid",
                schema: "decisorframework_sales",
                table: "legalclientbudget",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudgetproductbridge_classificationid",
                schema: "decisorframework_sales",
                table: "legalclientbudgetproductbridge",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudgetproductbridge_productid",
                schema: "decisorframework_sales",
                table: "legalclientbudgetproductbridge",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudgetproductbridge_unitmeasurementid",
                schema: "decisorframework_sales",
                table: "legalclientbudgetproductbridge",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudgetservicebridge_serviceid",
                schema: "decisorframework_sales",
                table: "legalclientbudgetservicebridge",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientdocumentbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalclientdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientpropertyleasingcompensations_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasingcompensations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientpropertyleasingcompensations_leasingid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasingcompensations",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientpropertyleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasings",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientpropertyleasings_contractid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasings",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientpropertyleasings_costcenterid",
                schema: "decisorframework_leasing",
                table: "legalclientpropertyleasings",
                column: "costcenterid");

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
                name: "ix_legalclientsalecontracts_documentid",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientsalecontracts_index_year",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                columns: new[] { "index", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_legalclientsalecontracts_proformaid",
                schema: "decisorframework_commercial",
                table: "legalclientsalecontracts",
                column: "proformaid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientvehicleleasingcompensations_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasingcompensations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientvehicleleasingcompensations_leasingid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasingcompensations",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientvehicleleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientvehicleleasings_contractid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientvehicleleasings_costcenterid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings",
                column: "costcenterid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalproviderbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproducts_budgetid_productid_classificati~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproducts",
                columns: new[] { "budgetid", "productid", "classificationid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproducts_classificationid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproducts",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproducts_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproducts",
                column: "currentyid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproducts_productid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproducts",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproducts_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproducts",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgets_commercialid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                column: "commercialid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgets_documentid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgets_number_year_providerid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                columns: new[] { "number", "year", "providerid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgets_providerid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetservicebridges_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges",
                column: "currentyid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetservicebridges_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges",
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
                name: "ix_legalproviderpurchasingcontracts_documentid",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderpurchasingcontracts_index_year",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                columns: new[] { "index", "year" },
                unique: true);

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
                name: "ix_legclientpropleascompdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientpropleascompdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientpropleascontractspacebridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientpropleascontractspacebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientpropleaspersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientpropleaspersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientpropsupervcontrolactions_leasingid",
                schema: "decisorframework_leasing",
                table: "legclientpropsupervcontrolactions",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientpropsupervcontrolactions_supervisiongroupid",
                schema: "decisorframework_leasing",
                table: "legclientpropsupervcontrolactions",
                column: "supervisiongroupid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehleascompdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientvehleascompdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehleasdrivlicbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientvehleasdrivlicbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehsupervcontrolactions_leasingid",
                schema: "decisorframework_leasing",
                table: "legclientvehsupervcontrolactions",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehsupervcontrolactions_supervisiongroupid",
                schema: "decisorframework_leasing",
                table: "legclientvehsupervcontrolactions",
                column: "supervisiongroupid");

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
                name: "ix_natclientpropeleascontractspacebridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientpropeleascontractspacebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientpropleascompdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientpropleascompdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientpropleaspersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientpropleaspersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientpropsupervcontrolactions_leasingid",
                schema: "decisorframework_leasing",
                table: "natclientpropsupervcontrolactions",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientpropsupervcontrolactions_supervisiongroupid",
                schema: "decisorframework_leasing",
                table: "natclientpropsupervcontrolactions",
                column: "supervisiongroupid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehleascompdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientvehleascompdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehleasdrivlicbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientvehleasdrivlicbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehsupervcontrolactions_leasingid",
                schema: "decisorframework_leasing",
                table: "natclientvehsupervcontrolactions",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehsupervcontrolactions_supervisiongroupid",
                schema: "decisorframework_leasing",
                table: "natclientvehsupervcontrolactions",
                column: "supervisiongroupid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "naturalclientbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudget_clientid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudget_commercialid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget",
                column: "commercialid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudget_documentid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudgetproductbridge_classificationid",
                schema: "decisorframework_sales",
                table: "naturalclientbudgetproductbridge",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudgetproductbridge_productid",
                schema: "decisorframework_sales",
                table: "naturalclientbudgetproductbridge",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudgetproductbridge_unitmeasurementid",
                schema: "decisorframework_sales",
                table: "naturalclientbudgetproductbridge",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudgetservicebridge_serviceid",
                schema: "decisorframework_sales",
                table: "naturalclientbudgetservicebridge",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientdocumentbridge_sternid",
                schema: "decisorframework_commercial",
                table: "naturalclientdocumentbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientpropertyleasingcompensations_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasingcompensations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientpropertyleasingcompensations_leasingid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasingcompensations",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientpropertyleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasings",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientpropertyleasings_contractid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasings",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientpropertyleasings_costcenterid",
                schema: "decisorframework_leasing",
                table: "naturalclientpropertyleasings",
                column: "costcenterid");

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
                name: "ix_naturalclientsalecontracts_documentid",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientsalecontracts_index_year",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                columns: new[] { "index", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientsalecontracts_proformaid",
                schema: "decisorframework_commercial",
                table: "naturalclientsalecontracts",
                column: "proformaid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientvehicleleasingcompensations_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasingcompensations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientvehicleleasingcompensations_leasingid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasingcompensations",
                column: "leasingid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientvehicleleasings_agreementid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientvehicleleasings_contractid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientvehicleleasings_costcenterid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings",
                column: "costcenterid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "naturalproviderbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproducts_budgetid_productid_classifica~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproducts",
                columns: new[] { "budgetid", "productid", "classificationid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproducts_classificationid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproducts",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproducts_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproducts",
                column: "currentyid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproducts_productid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproducts",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproducts_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproducts",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgets_commercialid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                column: "commercialid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgets_documentid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgets_number_year_providerid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                columns: new[] { "number", "year", "providerid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgets_providerid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetservicebridges_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                column: "currentyid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetservicebridges_sternid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
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
                name: "ix_naturalproviderpurchasingcontracts_documentid",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderpurchasingcontracts_index_year",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                columns: new[] { "index", "year" },
                unique: true);

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
                name: "ix_ocupations_contractid",
                schema: "decisorframework_humanresources",
                table: "ocupations",
                column: "contractid",
                unique: true);

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
                name: "ix_productionorders_agreementid",
                schema: "decisorframework_production",
                table: "productionorders",
                column: "agreementid");

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
                name: "ix_propertyleaseoffers_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "baselinecurrencyid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseoffers_propousalid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "propousalid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferspacespecificationclausebridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferspacespecificationclausebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferspacespecifications_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferspacespecifications",
                column: "baselinecurrencyid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferspacespecifications_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferspacespecifications",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferspacespecifications_spaceid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferspacespecifications",
                column: "spaceid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepersonpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges",
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
                name: "ix_propertyleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "propertyleasepropousals",
                column: "baselinecurrencyid");

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
                name: "ix_propleaseorgpostspacepropousalbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propleaseorgpostspacepropousalbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propleasorgpostdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propleasorgpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                column: "bankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_propleasorgpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_propleasorgpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_propleaspersonpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "bankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_propleaspersonpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_propleaspersonpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_propleasperspostspacepropbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propleasperspostspacepropbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_provisionableservices_featureimageid",
                schema: "decisorframework_commercial",
                table: "provisionableservices",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_purchasecashadvances_purchaseorderid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances",
                column: "purchaseorderid",
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
                name: "ix_purchaseorderexpectedproductresults_classificationid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderexpectedproductresults",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderexpectedproductresults_orderid_productid_class~",
                schema: "decisorframework_purchasing",
                table: "purchaseorderexpectedproductresults",
                columns: new[] { "orderid", "productid", "classificationid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderexpectedproductresults_productid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderexpectedproductresults",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderexpectedproductresults_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderexpectedproductresults",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderlegalproviderbudgetbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderlegalproviderbudgetbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseordernaturalproviderbudgetbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseordernaturalproviderbudgetbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderplannedproductspents_classificationid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderplannedproductspents",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderplannedproductspents_orderid_productid_classif~",
                schema: "decisorframework_purchasing",
                table: "purchaseorderplannedproductspents",
                columns: new[] { "orderid", "productid", "classificationid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderplannedproductspents_productid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderplannedproductspents",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderplannedproductspents_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderplannedproductspents",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorders_advancerequiredcurrencyid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "advancerequiredcurrencyid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorders_agreementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorders_requestid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "requestid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorders_responsibleid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorders_zoneid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
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
                name: "ix_purchaserequestexpectedproductadquisitions_classificationid",
                schema: "decisorframework_purchasing",
                table: "purchaserequestexpectedproductadquisitions",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequestexpectedproductadquisitions_productid",
                schema: "decisorframework_purchasing",
                table: "purchaserequestexpectedproductadquisitions",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequestexpectedproductadquisitions_requestid_produc~",
                schema: "decisorframework_purchasing",
                table: "purchaserequestexpectedproductadquisitions",
                columns: new[] { "requestid", "productid", "classificationid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequestexpectedproductadquisitions_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaserequestexpectedproductadquisitions",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequests_authorid",
                schema: "decisorframework_purchasing",
                table: "purchaserequests",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_purchases_orderid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "orderid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_purchases_purchaserid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "purchaserid");

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
                name: "ix_resolutions_candidateid",
                table: "resolutions",
                column: "candidateid");

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_contactid",
                table: "resolutions",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_index_year",
                table: "resolutions",
                columns: new[] { "index", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_ocupationid",
                table: "resolutions",
                column: "ocupationid");

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_staffid",
                table: "resolutions",
                column: "staffid");

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
                name: "ix_supervisiongroupemployeebridges_sternid",
                schema: "decisorframework_leasing",
                table: "supervisiongroupemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_supervisiongroups_representativeid",
                schema: "decisorframework_leasing",
                table: "supervisiongroups",
                column: "representativeid");

            migrationBuilder.CreateIndex(
                name: "ix_unitmeasurementconversionbridges_sternid",
                schema: "decisorframework_domain",
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
                name: "ix_vacants_salarystandardid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "salarystandardid");

            migrationBuilder.CreateIndex(
                name: "ix_vacants_workforceorganizationalunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceorganizationalunityid");

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
                name: "ix_vehicleleaseoffers_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "baselinecurrencyid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseoffers_propousalid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "propousalid");

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
                name: "ix_vehicleleasepropousals_baselinecurrencyid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepropousals",
                column: "baselinecurrencyid");

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
                name: "ix_vehleasorgpostdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehleasorgpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                column: "bankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_vehleasorgpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_vehleasorgpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                column: "offerid");

            migrationBuilder.CreateIndex(
                name: "ix_vehleaspersonpostdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehleaspersonpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "bankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_vehleaspersonpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_vehleaspersonpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "offerid");

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
                name: "ix_workforceorganizationalunities_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "chiefvacantid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_organizationalunityid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "organizationalunityid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_parentid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_workforceid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "workforceid");

            migrationBuilder.CreateIndex(
                name: "ix_workforces_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "chiefvacantid");

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
                name: "fk_collects_legalclientpropertyleasings_legalclientpropertylea~",
                schema: "decisorframework_finantial",
                table: "collects",
                column: "legalclientpropertyleasingid",
                principalSchema: "decisorframework_leasing",
                principalTable: "legalclientpropertyleasings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_collects_legalclientvehicleleasings_legalclientvehicleleasi~",
                schema: "decisorframework_finantial",
                table: "collects",
                column: "legalclientvehicleleasingid",
                principalSchema: "decisorframework_leasing",
                principalTable: "legalclientvehicleleasings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_collects_naturalclientpropertyleasings_naturalclientpropert~",
                schema: "decisorframework_finantial",
                table: "collects",
                column: "naturalclientpropertyleasingid",
                principalSchema: "decisorframework_leasing",
                principalTable: "naturalclientpropertyleasings",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_collects_naturalclientvehicleleasings_naturalclientvehiclel~",
                schema: "decisorframework_finantial",
                table: "collects",
                column: "naturalclientvehicleleasingid",
                principalSchema: "decisorframework_leasing",
                principalTable: "naturalclientvehicleleasings",
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
                name: "fk_employmentcontracts_resolutions_resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "resolutionid",
                principalTable: "resolutions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_staffs_staffid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staffs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_vacants_vacantid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_propleasorgpostulations_propertyleaselegalpo~",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleaselegalpostulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleasorgpostulations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_propleaspersonpostulations_propertyleasenatu~",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleasenaturalpostulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleaspersonpostulations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_vehleasorgpostulations_vehicleleaselegalpost~",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleaselegalpostulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehleasorgpostulations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_vehleaspersonpostulations_vehicleleasenatura~",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleasenaturalpostulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehleaspersonpostulations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_legclientpropleascontractspacebridges_propertyspaces_sternid",
                schema: "decisorframework_leasing",
                table: "legclientpropleascontractspacebridges",
                column: "sternid",
                principalSchema: "decisorframework_domain",
                principalTable: "propertyspaces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_natclientpropeleascontractspacebridges_propertyspaces_stern~",
                schema: "decisorframework_leasing",
                table: "natclientpropeleascontractspacebridges",
                column: "sternid",
                principalSchema: "decisorframework_domain",
                principalTable: "propertyspaces",
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
                name: "fk_properties_structures_structureid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "structureid",
                principalSchema: "decisorframework_domain",
                principalTable: "structures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staffs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id");

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
                name: "fk_vacants_workforceorganizationalunities_workforceorganizatio~",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceorganizationalunityid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforceorganizationalunities",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_employees_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_employees_responsibleid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_ocupationcandidates_employees_responsibleid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates");

            migrationBuilder.DropForeignKey(
                name: "fk_personcontacts_personidentities_identityid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropForeignKey(
                name: "fk_users_personidentities_identityid",
                schema: "guamaframework_security_personal",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "fk_admitionpropousals_agreements_agreementid",
                schema: "decisorframework_humanresources",
                table: "admitionpropousals");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_admitionpropousals_ocupationcandidates_ocupationcandidateid",
                schema: "decisorframework_humanresources",
                table: "admitionpropousals");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_ocupationcandidates_candidateid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions");

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
                name: "fk_staffs_structures_structureid",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.DropForeignKey(
                name: "fk_documents_thumbnails_thumbnailid",
                schema: "guamaframework_media",
                table: "documents");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_documents_documentid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_vacants_workpositions_workpositionid",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_admitionpropousals_admitionpropousalid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_resolutions_resolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_workforceorganizationalunities_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities");

            migrationBuilder.DropForeignKey(
                name: "fk_workforces_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropTable(
                name: "abstractsale",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "bankdebitcards",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "changenotificationuserbridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "clausetagbridges",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "collects",
                schema: "decisorframework_finantial");

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
                name: "drivelicencevehiclekindbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "elaborationdocumentbridges",
                schema: "decisorframework_production");

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
                name: "elaborationoutputproductclassificationbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "elaborationstepworkpositionbridges",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "employeedailycheckings",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "knowledgeareas",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "legalclientbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalclientbudgetproductbridge",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "legalclientbudgetservicebridge",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "legalclientdocumentbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalproviderbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalproviderbudgetproducts",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "legalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing");

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
                name: "legclientpropleascompdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientpropleascontractspacebridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientpropleaspersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientpropsupervcontrolactions",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientvehleascompdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientvehsupervcontrolactions",
                schema: "decisorframework_leasing");

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
                name: "natclientpropeleascontractspacebridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientpropleascompdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientpropleaspersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientpropsupervcontrolactions",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientvehleascompdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientvehsupervcontrolactions",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "naturalclientbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalclientbudgetproductbridge",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "naturalclientbudgetservicebridge",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "naturalclientdocumentbridge",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderbudgetproducts",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "naturalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing");

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
                name: "propertyleaseofferspacespecificationclausebridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propleaseorgpostspacepropousalbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propleasorgpostdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propleasperspostspacepropbridges",
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
                name: "purchaseorderexpectedproductresults",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseorderlegalproviderbudgetbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseordernaturalproviderbudgetbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseorderplannedproductspents",
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
                name: "purchaserequestexpectedproductadquisitions",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchasezonespentbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "receptionbatchbridges",
                schema: "decisorframework_inventory");

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
                name: "supervisiongroupemployeebridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "traces");

            migrationBuilder.DropTable(
                name: "unitmeasurementconversionbridges",
                schema: "decisorframework_domain");

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
                name: "vehleasorgpostdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehleaspersonpostdocumentbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "videos",
                schema: "guamaframework_media");

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
                name: "changenotifications",
                schema: "decisorframework_domain");

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
                name: "legalclientbudget",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "legalclientpropertyleasingcompensations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legalclientvehicleleasingcompensations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "naturalclientpropertyleasingcompensations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "naturalclientvehicleleasingcompensations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "drivelicences",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "naturalclientbudget",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "provisionableservices",
                schema: "decisorframework_commercial");

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
                name: "propertyleaseofferspacespecifications",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyspaceleasepropousals",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "colaborators",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "purchasingroles",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "legalproviderbudgets",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "naturalproviderbudgets",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchasespents",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "batches",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "servicevaluepropositions",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "supervisiongroups",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "clauses",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "proformas",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "regulations",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "legalclientpropertyleasings",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legalclientvehicleleasings",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "naturalclientpropertyleasings",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "naturalclientvehicleleasings",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyspaces",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "legalproviders",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviders",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "receptions");

            migrationBuilder.DropTable(
                name: "warehousingareas",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "requestableservices",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "proclamations",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "regulationkinds",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "costcenters",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "leasecontracts",
                schema: "decisorframework_leasing");

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
                name: "proclamationkinds",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "legalclients",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalclients",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "propleasorgpostulations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propleaspersonpostulations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehleasorgpostulations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehleaspersonpostulations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "productionorders",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "purchaseorders",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "paymentterms",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "propertyleaseoffers",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "organizationcontacts",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "bankaccounts",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "vehicleleaseoffers",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "elaborations",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "purchaserequests",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchasezones",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "propertyleasepropousals",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "centralstatestructures",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "legalbusinesskinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "bankbranches",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "vehicleleasepropousals",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "classifications",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "bankagencies",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "currencies",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "vehicles",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "products",
                schema: "decisorframework_inventory");

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
                name: "families",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "unitmeasurements",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "employees",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "personidentities",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "agreements",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "meetings",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "decisionmakinggroups",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "ocupationcandidates",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vacantpostulations",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "personcontacts",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "naturalbusinesskinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "users",
                schema: "guamaframework_security_personal");

            migrationBuilder.DropTable(
                name: "images",
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
                name: "thumbnails",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "documents",
                schema: "guamaframework_media");

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
                name: "admitionpropousals",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "resolutions");

            migrationBuilder.DropTable(
                name: "ocupations",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "employmentcontracts",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "staffs",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vacants",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "salarystandards",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunities",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "organizationalunities",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "workforces",
                schema: "decisorframework_humanresources");
        }
    }
}
