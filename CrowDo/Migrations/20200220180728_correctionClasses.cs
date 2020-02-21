using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowDo.Migrations
{
    public partial class correctionClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirthDay",
                schema: "core",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateOfBirthMonth",
                schema: "core",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateOfBirthYear",
                schema: "core",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "core",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOfBirth",
                schema: "core",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionGift",
                schema: "core",
                table: "Funding",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "core",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                schema: "core",
                table: "User");

            migrationBuilder.DropColumn(
                name: "YearOfBirth",
                schema: "core",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DescriptionGift",
                schema: "core",
                table: "Funding");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "core",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateOfBirthDay",
                schema: "core",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateOfBirthMonth",
                schema: "core",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateOfBirthYear",
                schema: "core",
                table: "User",
                type: "int",
                nullable: true);
        }
    }
}
