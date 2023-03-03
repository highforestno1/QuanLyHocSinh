using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLHS.Migrations
{
    /// <inheritdoc />
    public partial class QLHS333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AppTeachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AppTeachers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AppTeachers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AppTeachers");
        }
    }
}
