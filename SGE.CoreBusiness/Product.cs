using SGE.CoreBusiness.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "A Quantidade deve ser maior ou igual a {0}")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O Preço deve ser maior ou igual a {0}")]
        [Product_EnsurePriceIsGreaterThanInventoriesPrice]
        public double Price { get; set; }

        public bool IsActive { get; set; } = true;

        public List<ProductInventory>? ProductInventories { get; set; }

        public double TotalInventoryCost()
        {
            return this.ProductInventories.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
        }

        public bool ValidatePricing()
        {
            //não estamos validando o objeto do produto quando os estoques de produtos não estão carregados
            if (ProductInventories == null || ProductInventories.Count <= 0)
            {
                return true;
            }

            if (this.TotalInventoryCost() > Price) return false;

            return true;
        }
    }
}

