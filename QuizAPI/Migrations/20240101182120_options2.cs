using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class options2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Options_Option1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Options_Option2",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Options_Option3",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Options_Option4",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Options_Option1",
                table: "Questions",
                type: "nvarchar(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Options_Option2",
                table: "Questions",
                type: "nvarchar(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Options_Option3",
                table: "Questions",
                type: "nvarchar(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Options_Option4",
                table: "Questions",
                type: "nvarchar(250)",
                nullable: false,
                defaultValue: "");
        }
    }
}
