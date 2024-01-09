using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAPI.Migrations
{
    /// <inheritdoc />
    public partial class options : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Option4",
                table: "Questions",
                newName: "QnOptions_Option4");

            migrationBuilder.RenameColumn(
                name: "Option3",
                table: "Questions",
                newName: "QnOptions_Option3");

            migrationBuilder.RenameColumn(
                name: "Option2",
                table: "Questions",
                newName: "QnOptions_Option2");

            migrationBuilder.RenameColumn(
                name: "Option1",
                table: "Questions",
                newName: "QnOptions_Option1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "QnOptions_Option4",
                table: "Questions",
                newName: "Option4");

            migrationBuilder.RenameColumn(
                name: "QnOptions_Option3",
                table: "Questions",
                newName: "Option3");

            migrationBuilder.RenameColumn(
                name: "QnOptions_Option2",
                table: "Questions",
                newName: "Option2");

            migrationBuilder.RenameColumn(
                name: "QnOptions_Option1",
                table: "Questions",
                newName: "Option1");
        }
    }
}
