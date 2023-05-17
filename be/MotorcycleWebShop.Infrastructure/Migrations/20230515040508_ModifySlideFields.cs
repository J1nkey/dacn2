using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorcycleWebShop.Infrastructure.Migrations
{
    public partial class ModifySlideFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Slides",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Slides",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Slides");
        }
    }
}
