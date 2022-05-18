using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.CoreBusiness
{
    public class ProductTransaction
    {
        public int ProductTransactionId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int QuantityBefore { get; set; }

        //esta é a ação realizada (compra ou produzir produto)
        [Required]
        public ProductTransactionType ActivityType { get; set; }

        [Required]
        public int QuantityAfter { get; set; }
        public string? ProductionNumber { get; set; }
        public string? SalesOrderNumber { get; set; }

        public double? UnitPrice { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public string DoneBy { get; set; }

        //Propriedades de navegação
        public Product Product { get; set; }
    }
}
