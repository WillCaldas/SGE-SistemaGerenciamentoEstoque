using Microsoft.EntityFrameworkCore;
using SGE.CoreBusiness;
using SGE.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Plugins.EFCore
{
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private readonly SGEContext dbContext;
        private readonly IProductRepository prodRed;

        public ProductTransactionRepository(SGEContext dbContext, IProductRepository prodRed)
        {
            this.dbContext = dbContext;
            this.prodRed = prodRed;
        }
        public async Task ProduceAsync(string prodNumber, Product prod, int quantity, double price, string doneBy)
        {
            var product = this.prodRed.GetProductByIdAsync(prod.ProductId);

            if (product != null)
            {
                foreach (var prodInv in prod.ProductInventories)
                {
                    prodInv.Inventory.Quantity -= quantity * prodInv.InventoryQuantity;
                }
            }

            this.dbContext.ProductTransactions.Add(new ProductTransaction
            {
                ProductionNumber = prodNumber,
                ProductId = prod.ProductId,
                QuantityBefore = prod.Quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                QuantityAfter = quantity + prod.Quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });
            await this.dbContext.SaveChangesAsync();
        }
    }
}



