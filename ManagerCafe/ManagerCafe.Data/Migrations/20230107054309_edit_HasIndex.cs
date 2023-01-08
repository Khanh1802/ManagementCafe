using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerCafe.Data.Migrations
{
    public partial class edit_HasIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_IsDeleted",
                table: "WareHouse",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_Name",
                table: "WareHouse",
                column: "Name")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_IsDeleted",
                table: "Product",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                table: "Product",
                column: "Name")
                .Annotation("MySql:FullTextIndex", true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_IsDeleted",
                table: "Inventory",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WareHouse_IsDeleted",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_WareHouse_Name",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_Product_IsDeleted",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Name",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_IsDeleted",
                table: "Inventory");
        }
    }
}
