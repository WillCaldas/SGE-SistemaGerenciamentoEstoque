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
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly SGEContext dbContext;

        public InventoryTransactionRepository(SGEContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionsAsync(
            string invName, 
            DateTime? dateFrom, 
            DateTime? dateTo, 
            InventoryTransactionType? transType)
        {
            var query = from it in dbContext.InventoryTransactions
                        join inv in dbContext.Inventories on it.InventoryId equals inv.InventoryId
                        where
                            (string.IsNullOrWhiteSpace(invName) || inv.InventoryName.Contains(invName, StringComparison.OrdinalIgnoreCase)) &&
                            (!dateFrom.HasValue || it.TransactionDate >= dateFrom.Value.Date) &&
                            (!dateTo.HasValue || it.TransactionDate <= dateTo.Value.Date) &&
                            (!transType.HasValue || it.ActivityType == transType)
                        select it;

            return await query.Include(x => x.Inventory).ToListAsync();
        }

        public async Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, double price, string doneBy)
        {
            this.dbContext.InventoryTransactions.Add(new InventoryTransaction
            {
                PONumber = poNumber,
                InventoryId = inventory.InventoryId,
                QuantityBefore = inventory.Quantity,
                ActivityType = InventoryTransactionType.PurchaseInventory,
                QuantityAfter = inventory.Quantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price * quantity
            });
            await this.dbContext.SaveChangesAsync();
        }
    }
}

