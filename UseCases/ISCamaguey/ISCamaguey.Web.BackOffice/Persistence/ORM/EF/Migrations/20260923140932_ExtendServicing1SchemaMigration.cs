using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendServicing1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "legalclientgroundintegralstudyserviceexecutions",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientgroundintegralstudyserviceexecutions", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclientgroundintegralstudyserviceexecutions_documents_d~",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientgroundintegralstudyserviceexecutions_employees_a~",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientgroundintegralstudyserviceexecutions_serviceorde~",
                        column: x => x.orderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientsampleanalysisserviceexecutions",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientsampleanalysisserviceexecutions", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclientsampleanalysisserviceexecutions_documents_docume~",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientsampleanalysisserviceexecutions_employees_author~",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientsampleanalysisserviceexecutions_serviceorders_or~",
                        column: x => x.orderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclienttrainingserviceexecutions",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclienttrainingserviceexecutions", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalclienttrainingserviceexecutions_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclienttrainingserviceexecutions_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclienttrainingserviceexecutions_serviceorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientgroundintegralstudyserviceexecutions",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientgroundintegralstudyserviceexecutions", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclientgroundintegralstudyserviceexecutions_documents~",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientgroundintegralstudyserviceexecutions_employees~",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientgroundintegralstudyserviceexecutions_serviceor~",
                        column: x => x.orderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientsampleanalysisserviceexecutions",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientsampleanalysisserviceexecutions", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclientsampleanalysisserviceexecutions_documents_docu~",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientsampleanalysisserviceexecutions_employees_auth~",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientsampleanalysisserviceexecutions_serviceorders_~",
                        column: x => x.orderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclienttrainingserviceexecutions",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclienttrainingserviceexecutions", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalclienttrainingserviceexecutions_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclienttrainingserviceexecutions_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclienttrainingserviceexecutions_serviceorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_legalclientgroundintegralstudyserviceexecutions_authorid",
                schema: "decisoriscamaguey_servicing",
                table: "legalclientgroundintegralstudyserviceexecutions",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientgroundintegralstudyserviceexecutions_documentid",
                schema: "decisoriscamaguey_servicing",
                table: "legalclientgroundintegralstudyserviceexecutions",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientgroundintegralstudyserviceexecutions_orderid",
                schema: "decisoriscamaguey_servicing",
                table: "legalclientgroundintegralstudyserviceexecutions",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientsampleanalysisserviceexecutions_authorid",
                schema: "decisoriscamaguey_servicing",
                table: "legalclientsampleanalysisserviceexecutions",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientsampleanalysisserviceexecutions_documentid",
                schema: "decisoriscamaguey_servicing",
                table: "legalclientsampleanalysisserviceexecutions",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientsampleanalysisserviceexecutions_orderid",
                schema: "decisoriscamaguey_servicing",
                table: "legalclientsampleanalysisserviceexecutions",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclienttrainingserviceexecutions_authorid",
                schema: "decisoriscamaguey_servicing",
                table: "legalclienttrainingserviceexecutions",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclienttrainingserviceexecutions_documentid",
                schema: "decisoriscamaguey_servicing",
                table: "legalclienttrainingserviceexecutions",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclienttrainingserviceexecutions_orderid",
                schema: "decisoriscamaguey_servicing",
                table: "legalclienttrainingserviceexecutions",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientgroundintegralstudyserviceexecutions_authorid",
                schema: "decisoriscamaguey_servicing",
                table: "naturalclientgroundintegralstudyserviceexecutions",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientgroundintegralstudyserviceexecutions_documentid",
                schema: "decisoriscamaguey_servicing",
                table: "naturalclientgroundintegralstudyserviceexecutions",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientgroundintegralstudyserviceexecutions_orderid",
                schema: "decisoriscamaguey_servicing",
                table: "naturalclientgroundintegralstudyserviceexecutions",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientsampleanalysisserviceexecutions_authorid",
                schema: "decisoriscamaguey_servicing",
                table: "naturalclientsampleanalysisserviceexecutions",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientsampleanalysisserviceexecutions_documentid",
                schema: "decisoriscamaguey_servicing",
                table: "naturalclientsampleanalysisserviceexecutions",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientsampleanalysisserviceexecutions_orderid",
                schema: "decisoriscamaguey_servicing",
                table: "naturalclientsampleanalysisserviceexecutions",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclienttrainingserviceexecutions_authorid",
                schema: "decisoriscamaguey_servicing",
                table: "naturalclienttrainingserviceexecutions",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclienttrainingserviceexecutions_documentid",
                schema: "decisoriscamaguey_servicing",
                table: "naturalclienttrainingserviceexecutions",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclienttrainingserviceexecutions_orderid",
                schema: "decisoriscamaguey_servicing",
                table: "naturalclienttrainingserviceexecutions",
                column: "orderid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "legalclientgroundintegralstudyserviceexecutions",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "legalclientsampleanalysisserviceexecutions",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "legalclienttrainingserviceexecutions",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "naturalclientgroundintegralstudyserviceexecutions",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "naturalclientsampleanalysisserviceexecutions",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "naturalclienttrainingserviceexecutions",
                schema: "decisoriscamaguey_servicing");
        }
    }
}
