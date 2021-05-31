//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryMgmt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public Nullable<int> InventoryId { get; set; }
        public int TotalAmount { get; set; }
        public Nullable<double> TotalPrice { get; set; }

        public virtual Inventory Inventory { get; set; }

        public Nullable<double> TotalBayar { get { return TotalAmount * Inventory.Harga; } }
    }
}
