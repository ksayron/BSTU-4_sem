using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KNP_Library.Migrations
{
    /// <inheritdoc />
    public partial class AddedProfilePicImageToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicImage",
                table: "Users",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicImage",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ProfilePicId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
