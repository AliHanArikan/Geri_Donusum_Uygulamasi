using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class update_material : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "RecycableMaterials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isStatus",
                table: "RecycableMaterials",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "materialAmount",
                table: "RecycableMaterials",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "RecycableMaterials");

            migrationBuilder.DropColumn(
                name: "isStatus",
                table: "RecycableMaterials");

            migrationBuilder.DropColumn(
                name: "materialAmount",
                table: "RecycableMaterials");
        }
    }
}
