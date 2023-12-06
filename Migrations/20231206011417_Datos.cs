using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiigoBack.Migrations
{
    public partial class Datos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Datos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Customer_ID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Customer_VAT_ID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    End_Customer_Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Product_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendoReference = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    PriceableItem_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResellerContractID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Billing_Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actual_Charge_Interval = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Days_Billed = table.Column<int>(type: "int", nullable: false),
                    Billing_Interval = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillableParameters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costs = table.Column<int>(type: "int", nullable: false),
                    Sales_Price = table.Column<int>(type: "int", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Product_Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Costs_of_Unit = table.Column<int>(type: "int", nullable: false),
                    Sales_Price_of_Unit = table.Column<int>(type: "int", nullable: true),
                    UDRC_Value = table.Column<int>(type: "int", nullable: false),
                    PriceableItemId = table.Column<int>(type: "int", nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PriceableItemType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sales_Manager = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SecondVendorReference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CompanyAccountid = table.Column<int>(type: "int", nullable: false),
                    InvoiceReference = table.Column<string>(name: "InvoiceReference\r\n", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    InvoiceLineNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    purchase_order_number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datos");
        }
    }
}
