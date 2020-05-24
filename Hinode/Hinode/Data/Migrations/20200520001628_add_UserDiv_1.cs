using Microsoft.EntityFrameworkCore.Migrations;

namespace Hinode.Data.Migrations
{
    public partial class add_UserDiv_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "UserConfig",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserDiv",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserConfigId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiv", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDiv");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "UserConfig");
        }
    }
}
