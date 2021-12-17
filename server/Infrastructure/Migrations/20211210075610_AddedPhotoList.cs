namespace Infrastructure.Migrations
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedPhotoList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "Photos",
                table: "Products",
                type: "text[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photos",
                table: "Products");
        }
    }
}
