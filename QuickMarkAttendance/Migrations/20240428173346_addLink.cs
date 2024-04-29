using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickMarkAttendance.Migrations
{
    /// <inheritdoc />
    public partial class addLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "courses",
                newName: "Link");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "courses");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "courses",
                newName: "Code");
        }
    }
}
