using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationGuestBook.Data.Migrations
{
    public partial class addnokendaraan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoKendaraan",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoKendaraan",
                table: "Guests");
        }
    }
}
