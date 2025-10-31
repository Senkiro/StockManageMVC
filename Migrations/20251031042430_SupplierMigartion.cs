using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManageMVC.Migrations
{
    /// <inheritdoc />
    public partial class SupplierMigartion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Products_ProductId",
                table: "Warehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "WarehouseTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouse_ProductId",
                table: "WarehouseTransactions",
                newName: "IX_WarehouseTransactions_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseTransactions",
                table: "WarehouseTransactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseTransactions_Products_ProductId",
                table: "WarehouseTransactions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseTransactions_Products_ProductId",
                table: "WarehouseTransactions");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseTransactions",
                table: "WarehouseTransactions");

            migrationBuilder.RenameTable(
                name: "WarehouseTransactions",
                newName: "Warehouse");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseTransactions_ProductId",
                table: "Warehouse",
                newName: "IX_Warehouse_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductQuantity",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Products_ProductId",
                table: "Warehouse",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
