using Microsoft.EntityFrameworkCore.Migrations;

namespace Hinode.Data.Migrations
{
    public partial class add_UserCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserCategoryId",
                table: "UserConfig",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCategoryId",
                table: "UserConfig");
        }
    }
}
