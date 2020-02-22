using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowDo.Migrations
{
    public partial class deletePojFunToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFundingPackage_User_UserId",
                schema: "core",
                table: "ProjectFundingPackage");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "core",
                table: "ProjectFundingPackage",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFundingPackage_User_UserId",
                schema: "core",
                table: "ProjectFundingPackage",
                column: "UserId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFundingPackage_User_UserId",
                schema: "core",
                table: "ProjectFundingPackage");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "core",
                table: "ProjectFundingPackage",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFundingPackage_User_UserId",
                schema: "core",
                table: "ProjectFundingPackage",
                column: "UserId",
                principalSchema: "core",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
