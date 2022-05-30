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

        public async Task<IEnumerable<ProductTransaction>> GetProductTransactionsAsync(
            string prodName, 
            DateTime? dateFrom, 
            DateTime? dateTo, 
            ProductTransactionType? transType)
        {
            if (dateTo.HasValue) dateTo.Value.AddDays(1);

            var query = from pt in dbContext.ProductTransactions
                        join prod in dbContext.Products on pt.ProductId equals prod.ProductId
                        where
                            (string.IsNullOrWhiteSpace(prodName) || prod.ProductName.ToLower().IndexOf(prodName.ToLower()) >= 0) &&
                            (!dateFrom.HasValue || pt.TransactionDate >= dateFrom.Value.Date) &&
                            (!dateTo.HasValue || pt.TransactionDate <= dateTo.Value.Date) &&
                            (!transType.HasValue || pt.ActivityType == transType)
                        select pt;

            return await query.Include(x => x.Product).ToListAsync();
        }

        public async Task ProduceAsync(string prodNumber, Product prod, int quantity, double price, string doneBy)
        {
            var product = this.prodRed.GetProductByIdAsync(prod.ProductId);

            if (product != null)
            {
                foreach (var prodInv in prod.ProductInventories)
                {
                    int qtyBefore = prodInv.Inventory.Quantity;
                    prodInv.Inventory.Quantity -= quantity * prodInv.InventoryQuantity;

                    this.dbContext.InventoryTransactions.Add(new InventoryTransaction
                    {
                        ProductionNumber = prodNumber,
                        InventoryId = prodInv.Inventory.InventoryId,
                        QuantityBefore = qtyBefore,
                        ActivityType = InventoryTransactionType.ProduceProduct,
                        QuantityAfter = prodInv.Inventory.Quantity,
                        TransactionDate = DateTime.Now,
                        DoneBy = doneBy,
                        UnitPrice = price * quantity
                    });
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

        public async Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double price, string doneBy)
        {
            this.dbContext.ProductTransactions.Add(new ProductTransaction
            {
                SalesOrderNumber = salesOrderNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.SellProduct,
                QuantityAfter = product.Quantity -= quantity,
                TransactionDate= DateTime.Now,
                DoneBy= doneBy,
                UnitPrice= price
            });
            await this.dbContext.SaveChangesAsync();
        }
    }
}



