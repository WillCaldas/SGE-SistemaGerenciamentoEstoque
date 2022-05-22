using System.ComponentModel.DataAnnotations;

namespace SGE.WebApp.ViewModels
{
    public class ProduceViewModel
    {
        [Required]
        public string ProductionNumber { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "A quantidade precisa ser maior que 1")]
        public int QuantityToProduce { get; set; }

        public double ProductPrice { get; set; }
    }
}


