using System.ComponentModel.DataAnnotations;

namespace SGE.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        public string? InventoryName { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A Quantidade deve ser maior ou igual a {0}")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O Preço deve ser maior ou igual a {0}")]
        public double Price { get; set; }
    }
}

