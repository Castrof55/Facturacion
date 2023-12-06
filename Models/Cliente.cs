using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

public class Cliente
{

    [Key]
    public int id { get; set; }


    [StringLength(50)]
    public string Company { get; set; }

    [StringLength(30)]
    public string? Customer_ID { get; set; }

    [StringLength(30)]
    public string? Customer_VAT_ID { get; set; }

    [StringLength(50)]
    public string End_Customer_Company { get; set; }

    [StringLength(30)]
    public string? DepartmentName { get; set; }

    [StringLength(100)]
    public string Product_Name { get; set; }

    [Required]
    public string Vendor { get; set; } = "NO DATA";

    [StringLength(60)]
    public string VendoReference { get; set; }

    public int AccountID { get; set; }

    [MaxLength]
    public string PriceableItem_description { get; set; }

    [MaxLength]
    public string? Material_Number { get; set; }

    [StringLength(50)]
    public string? ContractID { get; set; }

    public string? ResellerContractID { get; set; }

    public DateTime Billing_Start_Date   { get; set; }

    public DateTime Actual_Charge_Interval { get; set; }

    public int Days_Billed { get; set; }

    public DateTime Billing_Interval { get; set; }

    public string BillableParameters  { get; set; }
    public int  Costs { get; set; }
    public int Sales_Price { get; set; }

    [Column("currency")]
    [StringLength(30)]
    public string Currency { get; set; }

    [StringLength(50)]
    public string? Product_Code { get; set; }

    public int Costs_of_Unit  { get; set; }

    public int? Sales_Price_of_Unit { get; set; }

    public int UDRC_Value { get; set; }

    public int PriceableItemId { get; set; }

    [StringLength(255)]
    public string ProductNumber { get; set; }

    [StringLength(255)]
    public string PriceableItemType { get; set; }

    [StringLength(255)]
    public string? Sales_Manager { get; set; }

    [StringLength(255)]
    public string? SecondVendorReference { get; set; }

    public int CompanyAccountid { get; set; }

    [StringLength(255)]
    [Column("InvoiceReference\r\n")] // Ejemplo de cómo especificar el nombre de la columna
    public string? InvoiceReference { get; set; }

    [StringLength(255)]
    public string? InvoiceLineNumber  { get; set; }

    [StringLength(255)]
    [Column("purchase_order_number")] // Ejemplo de cómo especificar el nombre de la columna
    public string? PurchaseOrderNumber  { get; set; }
}
