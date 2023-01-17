using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneSystem.Migrations
{
    public partial class _4thUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_ProductId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "ProuctId",
                table: "Stock");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderID",
                table: "Product",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_OrderID",
                table: "Product",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_OrderID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProuctId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "ProuctId");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductProuctId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderID, x.ProductProuctId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Product_ProductProuctId",
                        column: x => x.ProductProuctId,
                        principalTable: "Product",
                        principalColumn: "ProuctId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductProuctId",
                table: "OrderProduct",
                column: "ProductProuctId");
        }
    }
}
