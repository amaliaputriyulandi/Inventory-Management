using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace purchasemvc.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        [DisplayName("Supplier Name")]
        public int SupplierId { get; set; }
        [DisplayName("Inventory Name")]
        public int InventoryId { get; set; }
        [DisplayName("Total Amount")]
        public int TotalAmount { get; set; }

    }
}