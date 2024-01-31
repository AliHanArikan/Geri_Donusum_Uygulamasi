using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class offernew_added3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    offerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecyableMaterialId = table.Column<int>(type: "int", nullable: false),
                    RecycableMaterialID = table.Column<int>(type: "int", nullable: false),
                    SenderUserId = table.Column<int>(type: "int", nullable: true),
                    ReceiverUserId = table.Column<int>(type: "int", nullable: true),
                    offersPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isAccepted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.offerId);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_ReceiverUserId",
                        column: x => x.ReceiverUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_SenderUserId",
                        column: x => x.SenderUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_RecycableMaterials_RecycableMaterialID",
                        column: x => x.RecycableMaterialID,
                        principalTable: "RecycableMaterials",
                        principalColumn: "RecycableMaterialID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ReceiverUserId",
                table: "Offers",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_RecycableMaterialID",
                table: "Offers",
                column: "RecycableMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SenderUserId",
                table: "Offers",
                column: "SenderUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
