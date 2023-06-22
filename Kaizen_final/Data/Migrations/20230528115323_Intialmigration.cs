using Microsoft.EntityFrameworkCore.Migrations;

namespace Kaizen_final.Data.Migrations
{
    public partial class Intialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    farmerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    farmerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    farmerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    farmerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.farmerId);
                });

            migrationBuilder.CreateTable(
                name: "Teas",
                columns: table => new
                {
                    TeaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tea_Stock = table.Column<int>(type: "int", nullable: false),
                    picURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    farmerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teas", x => x.TeaId);
                    table.ForeignKey(
                        name: "FK_Teas_Farmers_farmerid",
                        column: x => x.farmerid,
                        principalTable: "Farmers",
                        principalColumn: "farmerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "farmerId", "farmerEmail", "farmerName", "farmerPhoneNumber" },
                values: new object[] { 1, "jhon@gmail.com", "Jhon", "1234567890" });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "farmerId", "farmerEmail", "farmerName", "farmerPhoneNumber" },
                values: new object[] { 2, "Tyreece@gmail.com", "tyreece", "1234567899" });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "farmerId", "farmerEmail", "farmerName", "farmerPhoneNumber" },
                values: new object[] { 3, "Hella@gmail.com", "Hella", "1234567888" });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "TeaId", "Price", "TeaDescription", "TeaName", "Tea_Stock", "farmerid", "picURL" },
                values: new object[,]
                {
                    { 1, 50.99m, "Simple Green tea", "Sencha", 15, 1, "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup01.png" },
                    { 3, 60.99m, "covered culture for approximately 20 days prior to picking.", "Gyokuro", 10, 1, "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup03.png" },
                    { 4, 60.99m, "reed screen or cloth placed over them to block out most sunlight.", "Kabusecha", 20, 2, "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup04.png" },
                    { 6, 70.99m, "Screen Culture but after steaming, the leaves are dried without being rolled", "Tencha", 20, 2, "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup06.png" },
                    { 2, 55.99m, " steamed approximately twice as long as regular Sencha", "Fukamushi Sencha", 10, 3, "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup02.png" },
                    { 5, 70.99m, "Tencha that is stoneground immediately before shipping", "Matcha", 20, 3, "https://www.itoen-global.com/allabout_greentea/img/varieties_lineup05.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teas_farmerid",
                table: "Teas",
                column: "farmerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teas");

            migrationBuilder.DropTable(
                name: "Farmers");
        }
    }
}
