using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HHRRExtend2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "workingdaycount",
                schema: "decisorframework_humanresources",
                table: "staffs",
                newName: "workingweekhourcount");

            migrationBuilder.AddColumn<decimal>(
                name: "doctorateextrafeed",
                schema: "decisorframework_humanresources",
                table: "staffs",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "masteryextrafeed",
                schema: "decisorframework_humanresources",
                table: "staffs",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "doctorateextrafeed",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.DropColumn(
                name: "masteryextrafeed",
                schema: "decisorframework_humanresources",
                table: "staffs");

            migrationBuilder.RenameColumn(
                name: "workingweekhourcount",
                schema: "decisorframework_humanresources",
                table: "staffs",
                newName: "workingdaycount");
        }
    }
}
