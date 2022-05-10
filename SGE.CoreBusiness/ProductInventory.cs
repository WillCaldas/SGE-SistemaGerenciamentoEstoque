using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.CoreBusiness
{
    public class ProductInventory
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

        public int InventoryQuantity { get; set; }
    }
}


 