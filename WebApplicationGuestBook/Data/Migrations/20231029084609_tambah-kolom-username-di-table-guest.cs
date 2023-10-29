using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationGuestBook.Data.Migrations
{
    public partial class tambahkolomusernameditableguest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Guests");
        }
    }
}
