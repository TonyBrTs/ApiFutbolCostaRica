using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiFutbolCostaRica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLogoAndPhotoFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StadiumImage",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StadiumImage",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Players");
        }
    }
}
