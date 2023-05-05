using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IkostProjeMVC.Migrations
{
    public partial class BayiAdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BayiAd",
                table: "Siparislers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BayiAd",
                table: "Siparislers");
        }
    }
}
