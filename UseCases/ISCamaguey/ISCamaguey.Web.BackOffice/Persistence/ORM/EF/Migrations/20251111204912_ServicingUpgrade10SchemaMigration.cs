using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade10SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_legalclients_groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_legalclients_sampleanalysislegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_legalclients_traininglegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_naturalclients_groundintegralstudynaturalclie~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_naturalclients_sampleanalysisnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_naturalclients_trainingnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_groundintegralstudynaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_sampleanalysislegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_sampleanalysisnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_traininglegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_trainingnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "groundintegralstudynaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "sampleanalysislegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "sampleanalysisnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "traininglegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "trainingnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.AddColumn<int>(
                name: "groundintegralstudylegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "groundintegralstudynaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sampleanalysislegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "sampleanalysisnaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "traininglegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "trainingnaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "servicingcontracts",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    feed = table.Column<double>(type: "double precision", nullable: false),
                    paymenttermid = table.Column<Guid>(type: "uuid", nullable: false),
                    bankaccountid = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    servicinglegalclientid = table.Column<Guid>(type: "uuid", nullable: true),
                    servicingnaturalclientid = table.Column<Guid>(type: "uuid", nullable: true),
                    year = table.Column<int>(type: "integer", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    objective = table.Column<string>(type: "text", nullable: false),
                    starat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    durationunitcount = table.Column<int>(type: "integer", nullable: true),
                    durationunitmeasurekind = table.Column<int>(type: "integer", nullable: true)
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
                name: "servicingcontractgroundintegralstudyservicebridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<int>(type: "integer", nullable: false),
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
                    prowid = table.Column<int>(type: "integer", nullable: false),
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
                    prowid = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_servicingcontracts_groundintegralstudylegalcl~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudylegalclientcontractid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "servicingcontracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_servicingcontracts_groundintegralstudynatural~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudynaturalclientcontractid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "servicingcontracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_servicingcontracts_sampleanalysislegalclientc~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysislegalclientcontractid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "servicingcontracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_servicingcontracts_sampleanalysisnaturalclien~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysisnaturalclientcontractid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "servicingcontracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_servicingcontracts_traininglegalclientcontrac~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "traininglegalclientcontractid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "servicingcontracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_servicingcontracts_trainingnaturalclientcontr~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "trainingnaturalclientcontractid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "servicingcontracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_servicingcontracts_groundintegralstudylegalcl~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_servicingcontracts_groundintegralstudynatural~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_servicingcontracts_sampleanalysislegalclientc~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_servicingcontracts_sampleanalysisnaturalclien~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_servicingcontracts_traininglegalclientcontrac~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_servicingcontracts_trainingnaturalclientcontr~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

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
                name: "servicingcontracts",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_groundintegralstudylegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_groundintegralstudynaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_sampleanalysislegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_sampleanalysisnaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_traininglegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_trainingnaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "groundintegralstudylegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "groundintegralstudynaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "sampleanalysislegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "sampleanalysisnaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "traininglegalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "trainingnaturalclientcontractid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.AddColumn<Guid>(
                name: "groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "groundintegralstudynaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "sampleanalysislegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "sampleanalysisnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "traininglegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "trainingnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudylegalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_groundintegralstudynaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudynaturalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_sampleanalysislegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysislegalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_sampleanalysisnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysisnaturalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_traininglegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "traininglegalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_trainingnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "trainingnaturalclientid");

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_legalclients_groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudylegalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalclients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_legalclients_sampleanalysislegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysislegalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalclients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_legalclients_traininglegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "traininglegalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalclients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_naturalclients_groundintegralstudynaturalclie~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudynaturalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalclients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_naturalclients_sampleanalysisnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysisnaturalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalclients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_naturalclients_trainingnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "trainingnaturalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalclients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
