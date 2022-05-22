using System.ComponentModel.DataAnnotations;

namespace SGE.WebApp.ViewModels
{
    public class SellViewModel
    {
        [Required]
        public string SalesOrderNumber { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "A quantidade precisa ser maior que 1")]
        public int QuantityToSell { get; set; }

        [Required]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "O Preço precisa ser maior que 0")]
        public double ProductPrice { get; set; }
    }
}

