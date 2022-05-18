using SGE.CoreBusiness;
using System.ComponentModel.DataAnnotations;

namespace SGE.WebApp.ViewModels
{
    public class PurchaseViewModel
    {
        [Required]
        public string PurchaseOrder { get; set; }

        [Required]
        public int InventoryId { get; set; }
        
        [Required]
        public string InventoryName { get; set; }

        [Required]
        [Range(minimum:1, maximum:int.MaxValue, ErrorMessage="A quantidade precisa ser maior que 1")]
        public int QuantityToPurchase { get; set; }

        public double InventoryPrice { get; set; }
    }
}


