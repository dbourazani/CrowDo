using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowDo.Migrations
{
    public partial class deletePojFunToUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFundingPackage_User_UserId",
                schema: "core",
                table: "ProjectFundingPackage");

            migrationBuilder.DropIndex(
                name: "IX_ProjectFundingPackage_UserId",
                schema: "core",
                table: "ProjectFundingPackage");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "core",
                table: "ProjectFundingPackage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "core",
                table: "ProjectFundingPackage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundingPackage_UserId",
                schema: "core",
                table: "ProjectFundingPackage",
                column: "UserId");

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
    }
}
