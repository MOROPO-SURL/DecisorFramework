using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "decisorframework_domain");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_humanresources");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_governance");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_lab");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_idi");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_finantial");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_inventory");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_quality");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_legal");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_location");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_production");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_media");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_identity");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_servicing");

            migrationBuilder.EnsureSchema(
                name: "decisorframework_commercial");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_core_security_common");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_reporting");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_domain");

            migrationBuilder.EnsureSchema(
                name: "guamaframework_security_personal");

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
                name: "awardkinds",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_awardkinds", x => x.id);
                });

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
                name: "certifications",
                schema: "decisoriscamaguey_quality",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certifications", x => x.id);
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
                name: "cubanstandards",
                schema: "decisoriscamaguey_quality",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cubanstandards", x => x.id);
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
                name: "impactdimensions",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_impactdimensions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "isostandards",
                schema: "decisoriscamaguey_quality",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_isostandards", x => x.id);
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
                name: "organizationalunits",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalunits", x => x.id);
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
                name: "programkinds",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_programkinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projectcategories",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_projectcategories", x => x.id);
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
                name: "researchercategories",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_researchercategories", x => x.id);
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
                    fee = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_salarystandards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "samplekinds",
                schema: "decisoriscamaguey_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_samplekinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scientifictechnicalresultkinds",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scientifictechnicalresultkinds", x => x.id);
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
                name: "teachingcategories",
                schema: "decisoriscamaguey_idi",
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
                    table.PrimaryKey("pk_teachingcategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "techniques",
                schema: "decisoriscamaguey_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_techniques", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "thesisresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thesisresults", x => x.id);
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
                name: "trainingresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingresults", x => x.id);
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
                name: "awardresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_awardresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_awardresults_awardkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "awardkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "certificationcubanstandardbridges",
                schema: "decisoriscamaguey_quality",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certificationcubanstandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_certificationcubanstandardbridges_certifications_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "certifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_certificationcubanstandardbridges_cubanstandards_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "cubanstandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "certificationisostandardbridges",
                schema: "decisoriscamaguey_quality",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certificationisostandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_certificationisostandardbridges_certifications_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "certifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_certificationisostandardbridges_isostandards_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "isostandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizationalstructuringunits",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    kind = table.Column<int>(type: "integer", nullable: false),
                    organizationalunitid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    reference = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalstructuringunits", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalstructuringunits_organizationalstructuringuni~",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructuringunits",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationalstructuringunits_organizationalunits_organiza~",
                        column: x => x.organizationalunitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunits",
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
                name: "scientifictechnicalresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    registrationcode = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scientifictechnicalresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_scientifictechnicalresults_scientifictechnicalresultkinds_k~",
                        column: x => x.kindid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "scientifictechnicalresultkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "newtechniqueresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    resultingtechniqueid = table.Column<Guid>(type: "uuid", nullable: false),
                    predecessortechniqueid = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_newtechniqueresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_newtechniqueresults_techniques_predecessortechniqueid",
                        column: x => x.predecessortechniqueid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_newtechniqueresults_techniques_resultingtechniqueid",
                        column: x => x.resultingtechniqueid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "techniquecubanstandardbridges",
                schema: "decisoriscamaguey_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_techniquecubanstandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_techniquecubanstandardbridges_cubanstandards_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "cubanstandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_techniquecubanstandardbridges_techniques_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "techniqueisostandardbridges",
                schema: "decisoriscamaguey_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_techniqueisostandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_techniqueisostandardbridges_isostandards_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "isostandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_techniqueisostandardbridges_techniques_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
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
                    educationlevel = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workpositions", x => x.id);
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
                name: "organizationalstructures",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    rootstructuringunitid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalstructures", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalstructures_organizationalstructuringunits_roo~",
                        column: x => x.rootstructuringunitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructuringunits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scientifictechnicalresultintroductions",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    scenery = table.Column<string>(type: "text", nullable: false),
                    resultid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scientifictechnicalresultintroductions", x => x.id);
                    table.ForeignKey(
                        name: "fk_scientifictechnicalresultintroductions_scientifictechnicalr~",
                        column: x => x.resultid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "scientifictechnicalresults",
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
                name: "projectreports",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectreports", x => x.id);
                    table.ForeignKey(
                        name: "fk_projectreports_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "publicationresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publicationresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_publicationresults_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
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
                    organizationalstructureid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforces", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforces_organizationalstructures_organizationalstructure~",
                        column: x => x.organizationalstructureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructures",
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
                    kind = table.Column<int>(type: "integer", nullable: false),
                    authorid = table.Column<string>(type: "text", nullable: false),
                    changekind = table.Column<int>(type: "integer", nullable: false),
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
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                name: "academicachievements",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    academiclevel = table.Column<int>(type: "integer", nullable: false),
                    mainknowledgeareaid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    institution = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academicachievements", x => x.id);
                    table.ForeignKey(
                        name: "fk_academicachievements_knowledgeareas_mainknowledgeareaid",
                        column: x => x.mainknowledgeareaid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academicachievements_personcontacts_contactid",
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
                name: "oppositionreports",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    reportid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_oppositionreports", x => x.id);
                    table.ForeignKey(
                        name: "fk_oppositionreports_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_oppositionreports_personcontacts_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_oppositionreports_projectreports_reportid",
                        column: x => x.reportid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projectreports",
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
                name: "academicachievementknowledgeareabridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academicachievementknowledgeareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_academicachievementknowledgeareabridges_academicachievement~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "academicachievements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academicachievementknowledgeareabridges_knowledgeareas_ster~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
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
                name: "groundintegralstudyservices",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groundintegralstudyservices", x => x.id);
                    table.ForeignKey(
                        name: "fk_groundintegralstudyservices_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "internalresearchers",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employeeid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: true),
                    teachingcategoryid = table.Column<Guid>(type: "uuid", nullable: true),
                    timeavailability = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_internalresearchers", x => x.id);
                    table.ForeignKey(
                        name: "fk_internalresearchers_employees_employeeid",
                        column: x => x.employeeid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_internalresearchers_researchercategories_categoryid",
                        column: x => x.categoryid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchercategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_internalresearchers_teachingcategories_teachingcategoryid",
                        column: x => x.teachingcategoryid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "teachingcategories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sampleanalysisservices",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    samplekindid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisservices", x => x.id);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservices_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservices_samplekinds_samplekindid",
                        column: x => x.samplekindid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "samplekinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingservices",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingservices", x => x.id);
                    table.ForeignKey(
                        name: "fk_trainingservices_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workinggroups",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    chiefid = table.Column<Guid>(type: "uuid", nullable: false),
                    qualityspecialistid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workinggroups", x => x.id);
                    table.ForeignKey(
                        name: "fk_workinggroups_employees_chiefid",
                        column: x => x.chiefid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workinggroups_employees_qualityspecialistid",
                        column: x => x.qualityspecialistid,
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
                name: "financiers",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financiers", x => x.id);
                    table.ForeignKey(
                        name: "fk_financiers_organizationcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
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
                name: "participatingorganizations",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participatingorganizations", x => x.id);
                    table.ForeignKey(
                        name: "fk_participatingorganizations_organizationcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "programs",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    alias = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    code = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    chiefid = table.Column<Guid>(type: "uuid", nullable: false),
                    managerid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_programs", x => x.id);
                    table.ForeignKey(
                        name: "fk_programs_organizationcontacts_managerid",
                        column: x => x.managerid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_programs_personcontacts_chiefid",
                        column: x => x.chiefid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_programs_programkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "programkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groundintegralstudyservicedocumentbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groundintegralstudyservicedocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_groundintegralstudyservicedocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_groundintegralstudyservicedocumentbridges_groundintegralstu~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintegralstudyservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groundintegralstudyserviceemployeebridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groundintegralstudyserviceemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_groundintegralstudyserviceemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_groundintegralstudyserviceemployeebridges_groundintegralstu~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintegralstudyservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groundintstudyservsteps",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groundintstudyservsteps", x => x.id);
                    table.ForeignKey(
                        name: "fk_groundintstudyservsteps_groundintegralstudyservices_service~",
                        column: x => x.serviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintegralstudyservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_groundintstudyservsteps_groundintstudyservsteps_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintstudyservsteps",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "publicationresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    isprincipalauthor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publicationresultinternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_publicationresultinternalresearcherbridges_internalresearch~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_publicationresultinternalresearcherbridges_publicationresul~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "publicationresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thesisresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    isprincipalauthor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thesisresultinternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_thesisresultinternalresearcherbridges_internalresearchers_s~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_thesisresultinternalresearcherbridges_thesisresults_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "thesisresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingresultinternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingresultinternalresearcherbridges_internalresearchers~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingresultinternalresearcherbridges_trainingresults_pro~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "trainingresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sampanalservsteps",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampanalservsteps", x => x.id);
                    table.ForeignKey(
                        name: "fk_sampanalservsteps_sampanalservsteps_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampanalservsteps",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_sampanalservsteps_sampleanalysisservices_serviceid",
                        column: x => x.serviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sampleanalysisservicedocumentbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisservicedocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicedocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicedocumentbridges_sampleanalysisservices~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sampleanalysisserviceemployeebridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisserviceemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_sampleanalysisserviceemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisserviceemployeebridges_sampleanalysisservices~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingservicedocumentbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingservicedocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingservicedocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingservicedocumentbridges_trainingservices_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingserviceemployeebridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingserviceemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingserviceemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingserviceemployeebridges_trainingservices_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingservsteps",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingservsteps", x => x.id);
                    table.ForeignKey(
                        name: "fk_trainingservsteps_trainingservices_serviceid",
                        column: x => x.serviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingservsteps_trainingservsteps_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservsteps",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "workinggroupemployeebridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workinggroupemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workinggroupemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workinggroupemployeebridges_workinggroups_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workinggrouptechniquebridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workinggrouptechniquebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workinggrouptechniquebridges_techniques_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workinggrouptechniquebridges_workinggroups_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workplans",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    workinggroupid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workplans", x => x.id);
                    table.ForeignKey(
                        name: "fk_workplans_workinggroups_workinggroupid",
                        column: x => x.workinggroupid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "callforproposals",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    financierid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforproposals", x => x.id);
                    table.ForeignKey(
                        name: "fk_callforproposals_financiers_financierid",
                        column: x => x.financierid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "financierdocumentbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financierdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_financierdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_financierdocumentbridges_financiers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "financierknowledgeareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financierknowledgeareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_financierknowledgeareabridges_financiers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_financierknowledgeareabridges_knowledgeareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
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
                name: "servicingcontracts",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    paymenttermid = table.Column<Guid>(type: "uuid", nullable: false),
                    bankaccountid = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    servicinglegalclientid = table.Column<Guid>(type: "uuid", nullable: true),
                    servicingnaturalclientid = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("pk_servicingcontracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_servicingcontracts_bankaccounts_bankaccountid",
                        column: x => x.bankaccountid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_servicingcontracts_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_servicingcontracts_legalclients_servicinglegalclientid",
                        column: x => x.servicinglegalclientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_servicingcontracts_naturalclients_servicingnaturalclientid",
                        column: x => x.servicingnaturalclientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_servicingcontracts_paymentterms_paymenttermid",
                        column: x => x.paymenttermid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "paymentterms",
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
                name: "externalresearchers",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    participatingorganizationid = table.Column<Guid>(type: "uuid", nullable: false),
                    salary = table.Column<decimal>(type: "numeric", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: true),
                    teachingcategoryid = table.Column<Guid>(type: "uuid", nullable: true),
                    timeavailability = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_externalresearchers", x => x.id);
                    table.ForeignKey(
                        name: "fk_externalresearchers_participatingorganizations_participatin~",
                        column: x => x.participatingorganizationid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "participatingorganizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_externalresearchers_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_externalresearchers_researchercategories_categoryid",
                        column: x => x.categoryid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchercategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_externalresearchers_teachingcategories_teachingcategoryid",
                        column: x => x.teachingcategoryid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "teachingcategories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "participatingorganizationknowledgeareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participatingorganizationknowledgeareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_participatingorganizationknowledgeareabridges_knowledgearea~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_participatingorganizationknowledgeareabridges_participating~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "participatingorganizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "programexpectresults",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    programid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_programexpectresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_programexpectresults_programs_programid",
                        column: x => x.programid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "programs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groundintstudyservstepworkposbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    requiredtimingeffort = table.Column<decimal>(type: "numeric", nullable: false),
                    fixedparticipation = table.Column<decimal>(type: "numeric", nullable: false),
                    relativeparticipation = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groundintstudyservstepworkposbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_groundintstudyservstepworkposbridges_groundintstudyservstep~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintstudyservsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_groundintstudyservstepworkposbridges_workpositions_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sampanalservstepworkposbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    requiredtimingeffort = table.Column<decimal>(type: "numeric", nullable: false),
                    fixedparticipation = table.Column<decimal>(type: "numeric", nullable: false),
                    relativeparticipation = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampanalservstepworkposbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_sampanalservstepworkposbridges_sampanalservsteps_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampanalservsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampanalservstepworkposbridges_workpositions_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingservstepworkposbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    requiredtimingeffort = table.Column<decimal>(type: "numeric", nullable: false),
                    fixedparticipation = table.Column<decimal>(type: "numeric", nullable: false),
                    relativeparticipation = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingservstepworkposbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingservstepworkposbridges_trainingservsteps_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingservstepworkposbridges_workpositions_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "callforproposaldocumentbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforproposaldocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_callforproposaldocumentbridges_callforproposals_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforproposals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_callforproposaldocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "callforproposalknowledgeareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforproposalknowledgeareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_callforproposalknowledgeareabridges_callforproposals_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforproposals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_callforproposalknowledgeareabridges_knowledgeareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectproposals",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(5100)", maxLength: 5100, nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    programid = table.Column<Guid>(type: "uuid", nullable: true),
                    callforpropousalid = table.Column<Guid>(type: "uuid", nullable: true),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectproposals", x => x.id);
                    table.ForeignKey(
                        name: "fk_projectproposals_callforproposals_callforpropousalid",
                        column: x => x.callforpropousalid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforproposals",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_projectproposals_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_projectproposals_programs_programid",
                        column: x => x.programid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "programs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "serviceorders",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    sampleanalysisserviceid = table.Column<Guid>(type: "uuid", nullable: true),
                    requestedtechniqueid = table.Column<Guid>(type: "uuid", nullable: true),
                    samplereceptionat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    sampleanalysislegalclientcontractid = table.Column<Guid>(type: "uuid", nullable: true),
                    sampleanalysisnaturalclientcontractid = table.Column<Guid>(type: "uuid", nullable: true),
                    groundintegralstudylegalclientcontractid = table.Column<Guid>(type: "uuid", nullable: true),
                    groundintegralstudyserviceid = table.Column<Guid>(type: "uuid", nullable: true),
                    traininglegalclientcontractid = table.Column<Guid>(type: "uuid", nullable: true),
                    trainingserviceid = table.Column<Guid>(type: "uuid", nullable: true),
                    groundintegralstudynaturalclientcontractid = table.Column<Guid>(type: "uuid", nullable: true),
                    trainingnaturalclientcontractid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_serviceorders", x => x.id);
                    table.ForeignKey(
                        name: "fk_serviceorders_groundintegralstudyservices_groundintegralstu~",
                        column: x => x.groundintegralstudyserviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintegralstudyservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_sampleanalysisservices_sampleanalysisserviceid",
                        column: x => x.sampleanalysisserviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_servicingcontracts_groundintegralstudylegalcl~",
                        column: x => x.groundintegralstudylegalclientcontractid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "servicingcontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_servicingcontracts_groundintegralstudynatural~",
                        column: x => x.groundintegralstudynaturalclientcontractid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "servicingcontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_servicingcontracts_sampleanalysislegalclientc~",
                        column: x => x.sampleanalysislegalclientcontractid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "servicingcontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_servicingcontracts_sampleanalysisnaturalclien~",
                        column: x => x.sampleanalysisnaturalclientcontractid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "servicingcontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_servicingcontracts_traininglegalclientcontrac~",
                        column: x => x.traininglegalclientcontractid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "servicingcontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_servicingcontracts_trainingnaturalclientcontr~",
                        column: x => x.trainingnaturalclientcontractid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "servicingcontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_techniques_requestedtechniqueid",
                        column: x => x.requestedtechniqueid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_serviceorders_trainingservices_trainingserviceid",
                        column: x => x.trainingserviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicingcontractgroundintegralstudyservicebridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicingcontractgroundintegralstudyservicebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_servicingcontractgroundintegralstudyservicebridges_groundin~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintegralstudyservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_servicingcontractgroundintegralstudyservicebridges_servicin~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "servicingcontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicingcontractsampleanalysisservicebridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicingcontractsampleanalysisservicebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_servicingcontractsampleanalysisservicebridges_sampleanalysi~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_servicingcontractsampleanalysisservicebridges_servicingcont~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "servicingcontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicingcontracttrainingservicebridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicingcontracttrainingservicebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_servicingcontracttrainingservicebridges_servicingcontracts_~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "servicingcontracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_servicingcontracttrainingservicebridges_trainingservices_st~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "publicationresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    isprincipalauthor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publicationresultexternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_publicationresultexternalresearcherbridges_externalresearch~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "externalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_publicationresultexternalresearcherbridges_publicationresul~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "publicationresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thesisresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    isprincipalauthor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_thesisresultexternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_thesisresultexternalresearcherbridges_externalresearchers_s~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "externalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_thesisresultexternalresearcherbridges_thesisresults_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "thesisresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingresultexternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingresultexternalresearcherbridges_externalresearchers~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "externalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingresultexternalresearcherbridges_trainingresults_pro~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "trainingresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    code = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    alias = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    categoryid = table.Column<Guid>(type: "uuid", nullable: false),
                    summary = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    problem = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                    context = table.Column<string>(type: "character varying(500000)", maxLength: 500000, nullable: false),
                    beneficiary = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    mainobjetive = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    programid = table.Column<Guid>(type: "uuid", nullable: true),
                    proposalid = table.Column<Guid>(type: "uuid", nullable: true),
                    predecessorid = table.Column<Guid>(type: "uuid", nullable: true),
                    chiefid = table.Column<Guid>(type: "uuid", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projects", x => x.id);
                    table.ForeignKey(
                        name: "fk_projects_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projects_internalresearchers_chiefid",
                        column: x => x.chiefid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projects_programs_programid",
                        column: x => x.programid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "programs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_projects_projectcategories_categoryid",
                        column: x => x.categoryid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projectcategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projects_projectproposals_proposalid",
                        column: x => x.proposalid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projectproposals",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_projects_projects_predecessorid",
                        column: x => x.predecessorid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id");
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
                    orderid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_collects", x => x.id);
                    table.ForeignKey(
                        name: "fk_collects_serviceorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "extensions",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    projectid = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_extensions", x => x.id);
                    table.ForeignKey(
                        name: "fk_extensions_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "externalresearcherprojectparticipations",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    researcherid = table.Column<Guid>(type: "uuid", nullable: false),
                    projectid = table.Column<Guid>(type: "uuid", nullable: false),
                    timeavailability = table.Column<int>(type: "integer", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_externalresearcherprojectparticipations", x => x.id);
                    table.ForeignKey(
                        name: "fk_externalresearcherprojectparticipations_externalresearchers~",
                        column: x => x.researcherid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "externalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_externalresearcherprojectparticipations_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "internalresearcherprojectparticipations",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    researcherid = table.Column<Guid>(type: "uuid", nullable: false),
                    projectid = table.Column<Guid>(type: "uuid", nullable: false),
                    timeavailability = table.Column<int>(type: "integer", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_internalresearcherprojectparticipations", x => x.id);
                    table.ForeignKey(
                        name: "fk_internalresearcherprojectparticipations_internalresearchers~",
                        column: x => x.researcherid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_internalresearcherprojectparticipations_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectbudgetfunancings",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    projectid = table.Column<Guid>(type: "uuid", nullable: false),
                    financierid = table.Column<Guid>(type: "uuid", nullable: false),
                    currencyid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectbudgetfunancings", x => x.id);
                    table.ForeignKey(
                        name: "fk_projectbudgetfunancings_currencies_currencyid",
                        column: x => x.currencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectbudgetfunancings_financiers_financierid",
                        column: x => x.financierid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectbudgetfunancings_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectimpacts",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    dimensionid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true),
                    projectid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectimpacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_projectimpacts_impactdimensions_dimensionid",
                        column: x => x.dimensionid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "impactdimensions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectimpacts_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "projectparticipatingorganizationbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectparticipatingorganizationbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_projectparticipatingorganizationbridges_participatingorgani~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "participatingorganizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectparticipatingorganizationbridges_projects_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectprogramexpectresultbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectprogramexpectresultbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_projectprogramexpectresultbridges_programexpectresults_ster~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "programexpectresults",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectprogramexpectresultbridges_projects_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectspecificobjectives",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(2550)", maxLength: 2550, nullable: true),
                    projectid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectspecificobjectives", x => x.id);
                    table.ForeignKey(
                        name: "fk_projectspecificobjectives_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
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
                    socialpropertyid = table.Column<Guid>(type: "uuid", nullable: true),
                    organizationalstructureid = table.Column<Guid>(type: "uuid", nullable: false)
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
                        name: "fk_administrativeentities_organizationalstructures_organizatio~",
                        column: x => x.organizationalstructureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_administrativeentities_organizationidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
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
                        name: "fk_costcenters_administrativeentities_structureid",
                        column: x => x.structureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "administrativeentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_costcenters_bankaccounts_defaultbankaccountid",
                        column: x => x.defaultbankaccountid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
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
                    administrativeentityid = table.Column<Guid>(type: "uuid", nullable: false),
                    leaderid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_decisionmakinggroups", x => x.id);
                    table.ForeignKey(
                        name: "fk_decisionmakinggroups_administrativeentities_administrativee~",
                        column: x => x.administrativeentityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "administrativeentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_decisionmakinggroups_personcontacts_leaderid",
                        column: x => x.leaderid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
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
                    administrativeentityid = table.Column<Guid>(type: "uuid", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_properties_administrativeentities_administrativeentityid",
                        column: x => x.administrativeentityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "administrativeentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "staffs",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    administrativeentityid = table.Column<Guid>(type: "uuid", nullable: false),
                    mainworkforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    workingweekhourcount = table.Column<int>(type: "integer", nullable: false),
                    doctorateextrafeed = table.Column<float>(type: "real", nullable: false),
                    masteryextrafeed = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_staffs", x => x.id);
                    table.ForeignKey(
                        name: "fk_staffs_administrativeentities_administrativeentityid",
                        column: x => x.administrativeentityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "administrativeentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_staffs_workforces_mainworkforceid",
                        column: x => x.mainworkforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
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
                    administrativeentityid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "fk_vehicles_administrativeentities_administrativeentityid",
                        column: x => x.administrativeentityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "administrativeentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "fk_decisionmakinggroupcontactbridges_decisionmakinggroups_prow~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "decisionmakinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "fk_decisionmakinggroupemployeebridges_decisionmakinggroups_pro~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "decisionmakinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_decisionmakinggroupemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
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
                    table.ForeignKey(
                        name: "fk_staffworkforcebridges_workforces_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
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
                        name: "fk_agreements_meetings_meetingid",
                        column: x => x.meetingid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "meetings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_agreements_personcontacts_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id");
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
                name: "productions",
                schema: "decisorframework_production",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    orderid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productions", x => x.id);
                    table.ForeignKey(
                        name: "fk_productions_productionorders_orderid",
                        column: x => x.orderid,
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
                name: "receptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    warehouseid = table.Column<Guid>(type: "uuid", nullable: true),
                    productionid = table.Column<Guid>(type: "uuid", nullable: true)
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
                        name: "fk_receptions_warehouses_warehouseid",
                        column: x => x.warehouseid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "warehouses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "samples",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    observation = table.Column<string>(type: "text", nullable: true),
                    pickedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    handledat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    assessmentat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    featureimageid = table.Column<Guid>(type: "uuid", nullable: true),
                    samplekindid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    productionid = table.Column<Guid>(type: "uuid", nullable: true),
                    projectid = table.Column<Guid>(type: "uuid", nullable: true),
                    researcherid = table.Column<Guid>(type: "uuid", nullable: true),
                    serviceorderid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_samples", x => x.id);
                    table.ForeignKey(
                        name: "fk_samples_images_featureimageid",
                        column: x => x.featureimageid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_samples_productions_productionid",
                        column: x => x.productionid,
                        principalSchema: "decisorframework_production",
                        principalTable: "productions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_samples_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_samples_samplekinds_samplekindid",
                        column: x => x.samplekindid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "samplekinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_samples_serviceorders_serviceorderid",
                        column: x => x.serviceorderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_samples_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
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
                        name: "fk_batches_costcenters_costcenterid",
                        column: x => x.costcenterid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "costcenters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "analysises",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    workplanid = table.Column<Guid>(type: "uuid", nullable: true),
                    sampleid = table.Column<Guid>(type: "uuid", nullable: false),
                    techniqueid = table.Column<Guid>(type: "uuid", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_analysises", x => x.id);
                    table.ForeignKey(
                        name: "fk_analysises_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analysises_samples_sampleid",
                        column: x => x.sampleid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analysises_techniques_techniqueid",
                        column: x => x.techniqueid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analysises_workplans_workplanid",
                        column: x => x.workplanid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workplans",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "assessments",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    sampleid = table.Column<Guid>(type: "uuid", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assessments", x => x.id);
                    table.ForeignKey(
                        name: "fk_assessments_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assessments_samples_sampleid",
                        column: x => x.sampleid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workplanproductionsamplebridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workplanproductionsamplebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workplanproductionsamplebridges_samples_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workplanproductionsamplebridges_workplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workplanresearchsamplebridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workplanresearchsamplebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workplanresearchsamplebridges_samples_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workplanresearchsamplebridges_workplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workplanserviceordersamplebridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workplanserviceordersamplebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workplanserviceordersamplebridges_samples_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workplanserviceordersamplebridges_workplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "workplans",
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
                name: "sampleanalysisreports",
                schema: "decisoriscamaguey_reporting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    analysisid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisreports", x => x.id);
                    table.ForeignKey(
                        name: "fk_sampleanalysisreports_analysises_analysisid",
                        column: x => x.analysisid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "analysises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisreports_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_sampleanalysisreports_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sampleanalysisservicereports",
                schema: "decisoriscamaguey_reporting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: false),
                    sampleanalysisreportid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisservicereports", x => x.id);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicereports_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicereports_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicereports_sampleanalysisreports_samplean~",
                        column: x => x.sampleanalysisreportid,
                        principalSchema: "decisoriscamaguey_reporting",
                        principalTable: "sampleanalysisreports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicereports_serviceorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
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
                    table.ForeignKey(
                        name: "fk_admitionpropousals_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    designationresolutionid = table.Column<Guid>(type: "uuid", nullable: true),
                    namingresolutionid = table.Column<Guid>(type: "uuid", nullable: true),
                    interviewat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
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
                        name: "fk_employmentcontracts_staffs_staffid",
                        column: x => x.staffid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "staffs",
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
                    table.ForeignKey(
                        name: "fk_ocupations_staffs_staffid",
                        column: x => x.staffid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "staffs",
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
                    summary = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: true),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: true),
                    staffid = table.Column<Guid>(type: "uuid", nullable: true),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: true),
                    concretedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    admitionpropousalid = table.Column<Guid>(type: "uuid", nullable: true),
                    ocupationid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_resolutions", x => x.id);
                    table.ForeignKey(
                        name: "fk_resolutions_admitionpropousals_admitionpropousalid",
                        column: x => x.admitionpropousalid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "admitionpropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_resolutions_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_resolutions_staffs_staffid",
                        column: x => x.staffid,
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
                    educationlevel = table.Column<int>(type: "integer", nullable: false),
                    ultimateeducationinstitution = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    titulationtitle = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    maleparentname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    femaleparentname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    alignment = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    responsabilitycommitment = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
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
                    salarystandardid = table.Column<Guid>(type: "uuid", nullable: false),
                    workforceorganizationalunitid = table.Column<Guid>(type: "uuid", nullable: true)
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
                name: "workforceorganizationalunits",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationalstructuringunitid = table.Column<Guid>(type: "uuid", nullable: false),
                    chiefvacantid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunits", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunits_organizationalstructuringunits~",
                        column: x => x.organizationalstructuringunitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructuringunits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunits_vacants_chiefvacantid",
                        column: x => x.chiefvacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunits_workforces_workforceid",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_academicachievementknowledgeareabridges_sternid",
                schema: "decisorframework_domain",
                table: "academicachievementknowledgeareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_academicachievements_contactid",
                schema: "decisorframework_domain",
                table: "academicachievements",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_academicachievements_mainknowledgeareaid",
                schema: "decisorframework_domain",
                table: "academicachievements",
                column: "mainknowledgeareaid");

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
                name: "ix_administrativeentities_organizationalstructureid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "organizationalstructureid");

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
                name: "ix_analysises_authorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_analysises_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "sampleid");

            migrationBuilder.CreateIndex(
                name: "ix_analysises_techniqueid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "techniqueid");

            migrationBuilder.CreateIndex(
                name: "ix_analysises_workplanid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "workplanid");

            migrationBuilder.CreateIndex(
                name: "ix_assessments_authorid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_assessments_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "assessments",
                column: "sampleid");

            migrationBuilder.CreateIndex(
                name: "ix_awardresults_kindid",
                schema: "decisoriscamaguey_idi",
                table: "awardresults",
                column: "kindid");

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
                name: "ix_callforproposaldocumentbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "callforproposaldocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_callforproposalknowledgeareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "callforproposalknowledgeareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_callforproposals_financierid",
                schema: "decisoriscamaguey_idi",
                table: "callforproposals",
                column: "financierid");

            migrationBuilder.CreateIndex(
                name: "ix_centralstatestructures_identityid",
                schema: "decisorframework_domain",
                table: "centralstatestructures",
                column: "identityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_certificationcubanstandardbridges_sternid",
                schema: "decisoriscamaguey_quality",
                table: "certificationcubanstandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_certificationisostandardbridges_sternid",
                schema: "decisoriscamaguey_quality",
                table: "certificationisostandardbridges",
                column: "sternid");

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
                name: "ix_collects_orderid",
                schema: "decisorframework_finantial",
                table: "collects",
                column: "orderid");

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
                name: "ix_cubanstandards_index",
                schema: "decisoriscamaguey_quality",
                table: "cubanstandards",
                column: "index",
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
                name: "ix_decisionmakinggroups_administrativeentityid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                column: "administrativeentityid");

            migrationBuilder.CreateIndex(
                name: "ix_decisionmakinggroups_leaderid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                column: "leaderid");

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
                name: "ix_employmentcontracts_designationresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "designationresolutionid");

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
                name: "ix_employmentcontracts_namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "namingresolutionid");

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
                name: "ix_extensions_projectid",
                schema: "decisoriscamaguey_idi",
                table: "extensions",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearcherprojectparticipations_projectid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearcherprojectparticipations",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearcherprojectparticipations_researcherid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearcherprojectparticipations",
                column: "researcherid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearchers_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearchers",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearchers_contactid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearchers",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearchers_participatingorganizationid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearchers",
                column: "participatingorganizationid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearchers_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearchers",
                column: "teachingcategoryid");

            migrationBuilder.CreateIndex(
                name: "ix_families_parentid",
                schema: "decisorframework_inventory",
                table: "families",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_financierdocumentbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "financierdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_financierknowledgeareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "financierknowledgeareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_financiers_contactid",
                schema: "decisoriscamaguey_idi",
                table: "financiers",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintegralstudyservicedocumentbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintegralstudyservicedocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintegralstudyserviceemployeebridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintegralstudyserviceemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintegralstudyservices_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintegralstudyservices",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintstudyservsteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintstudyservsteps",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintstudyservsteps_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintstudyservsteps",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintstudyservstepworkposbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintstudyservstepworkposbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_images_thumbnailid",
                schema: "guamaframework_media",
                table: "images",
                column: "thumbnailid");

            migrationBuilder.CreateIndex(
                name: "ix_internalresearcherprojectparticipations_projectid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearcherprojectparticipations",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_internalresearcherprojectparticipations_researcherid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearcherprojectparticipations",
                column: "researcherid");

            migrationBuilder.CreateIndex(
                name: "ix_internalresearchers_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_internalresearchers_employeeid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_internalresearchers_teachingcategoryid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearchers",
                column: "teachingcategoryid");

            migrationBuilder.CreateIndex(
                name: "ix_isostandards_index",
                schema: "decisoriscamaguey_quality",
                table: "isostandards",
                column: "index",
                unique: true);

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
                name: "ix_newtechniqueresults_predecessortechniqueid",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults",
                column: "predecessortechniqueid");

            migrationBuilder.CreateIndex(
                name: "ix_newtechniqueresults_resultingtechniqueid",
                schema: "decisoriscamaguey_idi",
                table: "newtechniqueresults",
                column: "resultingtechniqueid");

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
                name: "ix_oppositionreports_authorid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_oppositionreports_documentid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_oppositionreports_reportid",
                schema: "decisoriscamaguey_idi",
                table: "oppositionreports",
                column: "reportid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructures_rootstructuringunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "rootstructuringunitid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructuringunits_organizationalunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunits",
                column: "organizationalunitid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructuringunits_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunits",
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
                name: "ix_participatingorganizationknowledgeareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "participatingorganizationknowledgeareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_participatingorganizations_contactid",
                schema: "decisoriscamaguey_idi",
                table: "participatingorganizations",
                column: "contactid");

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
                name: "ix_productions_orderid",
                schema: "decisorframework_production",
                table: "productions",
                column: "orderid",
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
                name: "ix_programexpectresults_index",
                schema: "decisoriscamaguey_idi",
                table: "programexpectresults",
                column: "index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_programexpectresults_programid",
                schema: "decisoriscamaguey_idi",
                table: "programexpectresults",
                column: "programid");

            migrationBuilder.CreateIndex(
                name: "ix_programs_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                column: "chiefid");

            migrationBuilder.CreateIndex(
                name: "ix_programs_kindid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_programs_managerid",
                schema: "decisoriscamaguey_idi",
                table: "programs",
                column: "managerid");

            migrationBuilder.CreateIndex(
                name: "ix_projectbudgetfunancings_currencyid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "ix_projectbudgetfunancings_financierid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                column: "financierid");

            migrationBuilder.CreateIndex(
                name: "ix_projectbudgetfunancings_projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectbudgetfunancings",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_projectimpacts_dimensionid",
                schema: "decisoriscamaguey_idi",
                table: "projectimpacts",
                column: "dimensionid");

            migrationBuilder.CreateIndex(
                name: "ix_projectimpacts_projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectimpacts",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_projectparticipatingorganizationbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectparticipatingorganizationbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_projectprogramexpectresultbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectprogramexpectresultbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_projectproposals_callforpropousalid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "callforpropousalid");

            migrationBuilder.CreateIndex(
                name: "ix_projectproposals_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_projectproposals_programid",
                schema: "decisoriscamaguey_idi",
                table: "projectproposals",
                column: "programid");

            migrationBuilder.CreateIndex(
                name: "ix_projectreports_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projectreports",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_categoryid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_chiefid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "chiefid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_documentid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_predecessorid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "predecessorid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_programid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "programid");

            migrationBuilder.CreateIndex(
                name: "ix_projects_proposalid",
                schema: "decisoriscamaguey_idi",
                table: "projects",
                column: "proposalid");

            migrationBuilder.CreateIndex(
                name: "ix_projectspecificobjectives_projectid",
                schema: "decisoriscamaguey_idi",
                table: "projectspecificobjectives",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_properties_administrativeentityid",
                schema: "decisorframework_domain",
                table: "properties",
                column: "administrativeentityid");

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
                name: "ix_publicationresultexternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresultexternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_publicationresultinternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresultinternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_publicationresults_documentid",
                schema: "decisoriscamaguey_idi",
                table: "publicationresults",
                column: "documentid");

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
                name: "ix_resolutions_admitionpropousalid",
                table: "resolutions",
                column: "admitionpropousalid");

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_agreementid",
                table: "resolutions",
                column: "agreementid");

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
                name: "ix_sampanalservsteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservsteps",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_sampanalservsteps_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservsteps",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_sampanalservstepworkposbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservstepworkposbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisreports_analysisid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisreports",
                column: "analysisid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisreports_authorid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisreports",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisreports_documentid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisreports",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicedocumentbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicedocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisserviceemployeebridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisserviceemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicereports_authorid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicereports_documentid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicereports_orderid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicereports_sampleanalysisreportid",
                schema: "decisoriscamaguey_reporting",
                table: "sampleanalysisservicereports",
                column: "sampleanalysisreportid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservices_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservices_samplekindid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices",
                column: "samplekindid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_index_year",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                columns: new[] { "index", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_samples_productionid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "productionid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_projectid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_samplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "samplekindid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_serviceorderid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "serviceorderid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_unitmeasurementid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_scientifictechnicalresultintroductions_resultid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresultintroductions",
                column: "resultid");

            migrationBuilder.CreateIndex(
                name: "ix_scientifictechnicalresults_kindid",
                schema: "decisoriscamaguey_idi",
                table: "scientifictechnicalresults",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_sections_parentid",
                schema: "decisorframework_legal",
                table: "sections",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_groundintegralstudylegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudylegalclientcontractid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_groundintegralstudynaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudynaturalclientcontractid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_groundintegralstudyserviceid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudyserviceid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_requestedtechniqueid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "requestedtechniqueid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_sampleanalysislegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysislegalclientcontractid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_sampleanalysisnaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysisnaturalclientcontractid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_sampleanalysisserviceid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysisserviceid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_traininglegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "traininglegalclientcontractid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_trainingnaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "trainingnaturalclientcontractid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_trainingserviceid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "trainingserviceid");

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
                name: "ix_servicingcontractgroundintegralstudyservicebridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "servicingcontractgroundintegralstudyservicebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_servicingcontracts_bankaccountid",
                schema: "decisoriscamaguey_servicing",
                table: "servicingcontracts",
                column: "bankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_servicingcontracts_documentid",
                schema: "decisoriscamaguey_servicing",
                table: "servicingcontracts",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_servicingcontracts_paymenttermid",
                schema: "decisoriscamaguey_servicing",
                table: "servicingcontracts",
                column: "paymenttermid");

            migrationBuilder.CreateIndex(
                name: "ix_servicingcontracts_servicinglegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "servicingcontracts",
                column: "servicinglegalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_servicingcontracts_servicingnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "servicingcontracts",
                column: "servicingnaturalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_servicingcontractsampleanalysisservicebridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "servicingcontractsampleanalysisservicebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_servicingcontracttrainingservicebridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "servicingcontracttrainingservicebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_staffs_administrativeentityid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "administrativeentityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_staffs_mainworkforceid",
                schema: "decisorframework_humanresources",
                table: "staffs",
                column: "mainworkforceid");

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
                name: "ix_techniquecubanstandardbridges_sternid",
                schema: "decisoriscamaguey_domain",
                table: "techniquecubanstandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_techniqueisostandardbridges_sternid",
                schema: "decisoriscamaguey_domain",
                table: "techniqueisostandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_thesisresultexternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresultexternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_thesisresultinternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "thesisresultinternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingresultexternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresultexternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingresultinternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "trainingresultinternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingservicedocumentbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicedocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingserviceemployeebridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingserviceemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingservices_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservices",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingservsteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservsteps",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingservsteps_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservsteps",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingservstepworkposbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservstepworkposbridges",
                column: "sternid");

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
                name: "ix_vacants_workforceorganizationalunitid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceorganizationalunitid");

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
                name: "ix_vehicles_administrativeentityid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "administrativeentityid");

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
                name: "ix_workforceorganizationalunits_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunits",
                column: "chiefvacantid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunits_organizationalstructuringunitid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunits",
                column: "organizationalstructuringunitid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunits_workforceid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunits",
                column: "workforceid");

            migrationBuilder.CreateIndex(
                name: "ix_workforces_organizationalstructureid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "organizationalstructureid");

            migrationBuilder.CreateIndex(
                name: "ix_workinggroupemployeebridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "workinggroupemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_workinggroups_chiefid",
                schema: "decisoriscamaguey_lab",
                table: "workinggroups",
                column: "chiefid");

            migrationBuilder.CreateIndex(
                name: "ix_workinggroups_qualityspecialistid",
                schema: "decisoriscamaguey_lab",
                table: "workinggroups",
                column: "qualityspecialistid");

            migrationBuilder.CreateIndex(
                name: "ix_workinggrouptechniquebridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "workinggrouptechniquebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_workplanproductionsamplebridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "workplanproductionsamplebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_workplanresearchsamplebridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "workplanresearchsamplebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_workplans_workinggroupid",
                schema: "decisoriscamaguey_lab",
                table: "workplans",
                column: "workinggroupid");

            migrationBuilder.CreateIndex(
                name: "ix_workplanserviceordersamplebridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "workplanserviceordersamplebridges",
                column: "sternid");

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

            migrationBuilder.AddForeignKey(
                name: "fk_administrativeentities_properties_socialpropertyid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "socialpropertyid",
                principalSchema: "decisorframework_domain",
                principalTable: "properties",
                principalColumn: "id");

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
                name: "fk_employmentcontracts_resolutions_designationresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "designationresolutionid",
                principalTable: "resolutions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_resolutions_namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "namingresolutionid",
                principalTable: "resolutions",
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
                name: "fk_ocupationcandidates_vacantpostulations_postulationid",
                schema: "decisorframework_humanresources",
                table: "ocupationcandidates",
                column: "postulationid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacantpostulations",
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
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
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
                name: "fk_vacants_workforceorganizationalunits_workforceorganizationa~",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceorganizationalunitid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforceorganizationalunits",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_agreements_personcontacts_responsibleid",
                schema: "decisorframework_governance",
                table: "agreements");

            migrationBuilder.DropForeignKey(
                name: "fk_decisionmakinggroups_personcontacts_leaderid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups");

            migrationBuilder.DropForeignKey(
                name: "fk_employees_personcontacts_contactid",
                schema: "decisorframework_domain",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "fk_meetings_personcontacts_authorid",
                schema: "decisorframework_governance",
                table: "meetings");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_vacantpostulations_personcontacts_contactid",
                schema: "decisorframework_humanresources",
                table: "vacantpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_administrativeentities_administrativeentitykinds_kindid",
                schema: "decisorframework_domain",
                table: "administrativeentities");

            migrationBuilder.DropForeignKey(
                name: "fk_administrativeentities_organizationalstructures_organizatio~",
                schema: "decisorframework_domain",
                table: "administrativeentities");

            migrationBuilder.DropForeignKey(
                name: "fk_workforces_organizationalstructures_organizationalstructure~",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropForeignKey(
                name: "fk_administrativeentities_organizationidentities_identityid",
                schema: "decisorframework_domain",
                table: "administrativeentities");

            migrationBuilder.DropForeignKey(
                name: "fk_administrativeentities_properties_socialpropertyid",
                schema: "decisorframework_domain",
                table: "administrativeentities");

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
                name: "fk_employmentcontracts_employees_employeeid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_documents_documentid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_staffs_administrativeentities_administrativeentityid",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.DropForeignKey(
                name: "fk_vacants_workpositions_workpositionid",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_admitionpropousals_admitionpropousalid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_admitionpropousals_admitionpropousalid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_resolutions_designationresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_resolutions_namingresolutionid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_workforceorganizationalunits_vacants_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunits");

            migrationBuilder.DropTable(
                name: "academicachievementknowledgeareabridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "assessments",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "awardresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "bankdebitcards",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "callforproposaldocumentbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "callforproposalknowledgeareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "certificationcubanstandardbridges",
                schema: "decisoriscamaguey_quality");

            migrationBuilder.DropTable(
                name: "certificationisostandardbridges",
                schema: "decisoriscamaguey_quality");

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
                name: "dispositiontagbridges",
                schema: "decisorframework_legal");

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
                name: "extensions",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "externalresearcherprojectparticipations",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "financierdocumentbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "financierknowledgeareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "groundintegralstudyservicedocumentbridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "groundintegralstudyserviceemployeebridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "groundintstudyservstepworkposbridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "internalresearcherprojectparticipations",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "legalclientbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalclientdocumentbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalclientsalecontracts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalproviderbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalproviderdocumentbridges",
                schema: "decisorframework_commercial");

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
                name: "naturalclientsalecontracts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderdocumentbridge",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderpurchasingcontracts",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "newtechniqueresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "oppositionreports",
                schema: "decisoriscamaguey_idi");

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
                name: "participatingorganizationknowledgeareabridges",
                schema: "decisoriscamaguey_idi");

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
                name: "projectbudgetfunancings",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectimpacts",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectparticipatingorganizationbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectprogramexpectresultbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectspecificobjectives",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "propertyimagebridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "propertyspaces",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "provisionableservices",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "publicationresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "publicationresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "receptionbatchbridges",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "rolepermissionbridges",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "sampanalservstepworkposbridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "sampleanalysisservicedocumentbridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "sampleanalysisserviceemployeebridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "sampleanalysisservicereports",
                schema: "decisoriscamaguey_reporting");

            migrationBuilder.DropTable(
                name: "scientifictechnicalresultintroductions",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "servicevaluepropositionimagebridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "servicevaluepropositionrates",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "servicingcontractgroundintegralstudyservicebridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "servicingcontractsampleanalysisservicebridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "servicingcontracttrainingservicebridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "staffworkforcebridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "statements",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "techniquecubanstandardbridges",
                schema: "decisoriscamaguey_domain");

            migrationBuilder.DropTable(
                name: "techniqueisostandardbridges",
                schema: "decisoriscamaguey_domain");

            migrationBuilder.DropTable(
                name: "thesisresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "thesisresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "traces");

            migrationBuilder.DropTable(
                name: "trainingresultexternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "trainingresultinternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "trainingservicedocumentbridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "trainingserviceemployeebridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "trainingservstepworkposbridges",
                schema: "decisoriscamaguey_servicing");

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
                name: "videos",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "workinggroupemployeebridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workinggrouptechniquebridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workplanproductionsamplebridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workplanresearchsamplebridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workplanserviceordersamplebridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workpositionresponsabilities",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "academicachievements",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "awardkinds",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "certifications",
                schema: "decisoriscamaguey_quality");

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
                name: "groundintstudyservsteps",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "legalproviders",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviders",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "projectreports",
                schema: "decisoriscamaguey_idi");

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
                name: "colaborators",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "elaborationsteps",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "productvaluepropositions",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "clauses",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "proformas",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "sections",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "impactdimensions",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "programexpectresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "publicationresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "batches",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "sampanalservsteps",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "sampleanalysisreports",
                schema: "decisoriscamaguey_reporting");

            migrationBuilder.DropTable(
                name: "scientifictechnicalresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "servicevaluepropositions",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "cubanstandards",
                schema: "decisoriscamaguey_quality");

            migrationBuilder.DropTable(
                name: "isostandards",
                schema: "decisoriscamaguey_quality");

            migrationBuilder.DropTable(
                name: "thesisresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "externalresearchers",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "trainingresults",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "trainingservsteps",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "guamaframework_core_security_common");

            migrationBuilder.DropTable(
                name: "vehicles",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "knowledgeareas",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "regulations",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "costcenters",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "receptions");

            migrationBuilder.DropTable(
                name: "warehousingareas",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "analysises",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "scientifictechnicalresultkinds",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "requestableservices",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "participatingorganizations",
                schema: "decisoriscamaguey_idi");

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
                name: "proclamations",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "regulationkinds",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "warehouses",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "samples",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "workplans",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "proclamationkinds",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "productions",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "projects",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "serviceorders",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "workinggroups",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "productionorders",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "internalresearchers",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectcategories",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectproposals",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "groundintegralstudyservices",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "sampleanalysisservices",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "servicingcontracts",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "techniques",
                schema: "decisoriscamaguey_domain");

            migrationBuilder.DropTable(
                name: "trainingservices",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "elaborations",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "researchercategories",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "teachingcategories",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "callforproposals",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "programs",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "samplekinds",
                schema: "decisoriscamaguey_domain");

            migrationBuilder.DropTable(
                name: "bankaccounts",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "legalclients",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalclients",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "classifications",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "financiers",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "programkinds",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "bankbranches",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "currencies",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "paymentterms",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "products",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "organizationcontacts",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "bankagencies",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "families",
                schema: "decisorframework_inventory");

            migrationBuilder.DropTable(
                name: "unitmeasurements",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "centralstatestructures",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "legalbusinesskinds",
                schema: "decisorframework_domain");

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
                name: "personidentities",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "administrativeentitykinds",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "organizationalstructures",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "organizationidentities",
                schema: "guamaframework_identity");

            migrationBuilder.DropTable(
                name: "properties",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "images",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "propertykinds",
                schema: "decisorframework_domain");

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
                name: "employees",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "documents",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "thumbnails",
                schema: "guamaframework_media");

            migrationBuilder.DropTable(
                name: "administrativeentities",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "workpositions",
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
                name: "workforceorganizationalunits",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "organizationalstructuringunits",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "workforces",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "organizationalunits",
                schema: "decisorframework_domain");
        }
    }
}
