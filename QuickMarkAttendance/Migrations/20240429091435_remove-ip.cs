using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickMarkAttendance.Migrations
{
    /// <inheritdoc />
    public partial class removeip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "attendances");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "attendances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "attendances",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
