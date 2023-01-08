using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerCafe.Data.Migrations
{
    public partial class add_InventoryTransactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InventoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Quatity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryTransaction_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransaction_InventoryId",
                table: "InventoryTransaction",
                column: "InventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryTransaction");
        }
    }
}
