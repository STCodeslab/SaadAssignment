using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ekka_Shopping.Migrations
{
    public partial class Again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Gender_Gender_id",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Order_OrderId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Product_ProductId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Order_OrderId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Subcategory_Subcategory_id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategory_Category_category_id",
                table: "Subcategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subcategory",
                table: "Subcategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                table: "Gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Subcategory",
                newName: "Subcategories");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "Gender",
                newName: "Genders");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategory_category_id",
                table: "Subcategories",
                newName: "IX_Subcategories_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Subcategory_id",
                table: "Products",
                newName: "IX_Products_Subcategory_id");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_OrderId",
                table: "Payments",
                newName: "IX_Payments_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ProductId",
                table: "Invoices",
                newName: "IX_Invoices_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_OrderId",
                table: "Invoices",
                newName: "IX_Invoices_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_Gender_id",
                table: "Categories",
                newName: "IX_Categories_Gender_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subcategories",
                table: "Subcategories",
                column: "subcategory_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Pro_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Order_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Invoice_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                table: "Genders",
                column: "gender_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Genders_Gender_id",
                table: "Categories",
                column: "Gender_id",
                principalTable: "Genders",
                principalColumn: "gender_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Products_ProductId",
                table: "Invoices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Pro_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Subcategories_Subcategory_id",
                table: "Products",
                column: "Subcategory_id",
                principalTable: "Subcategories",
                principalColumn: "subcategory_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Categories_category_id",
                table: "Subcategories",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "Category_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Genders_Gender_id",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Products_ProductId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Subcategories_Subcategory_id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Categories_category_id",
                table: "Subcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subcategories",
                table: "Subcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                table: "Genders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Subcategories",
                newName: "Subcategory");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "Gender");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_category_id",
                table: "Subcategory",
                newName: "IX_Subcategory_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Subcategory_id",
                table: "Product",
                newName: "IX_Product_Subcategory_id");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_OrderId",
                table: "Payment",
                newName: "IX_Payment_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ProductId",
                table: "Invoice",
                newName: "IX_Invoice_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoice",
                newName: "IX_Invoice_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Gender_id",
                table: "Category",
                newName: "IX_Category_Gender_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subcategory",
                table: "Subcategory",
                column: "subcategory_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Pro_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Order_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Invoice_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                table: "Gender",
                column: "gender_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Gender_Gender_id",
                table: "Category",
                column: "Gender_id",
                principalTable: "Gender",
                principalColumn: "gender_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Order_OrderId",
                table: "Invoice",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Product_ProductId",
                table: "Invoice",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Pro_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Order_OrderId",
                table: "Payment",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Subcategory_Subcategory_id",
                table: "Product",
                column: "Subcategory_id",
                principalTable: "Subcategory",
                principalColumn: "subcategory_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategory_Category_category_id",
                table: "Subcategory",
                column: "category_id",
                principalTable: "Category",
                principalColumn: "Category_Id");
        }
    }
}
