using Microsoft.EntityFrameworkCore.Migrations;

namespace Banks.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    IFSC = table.Column<string>(nullable: false),
                    ADDRESS = table.Column<string>(nullable: true),
                    CITY = table.Column<string>(nullable: true),
                    BANK = table.Column<string>(nullable: true),
                    BANKCODE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.IFSC);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
