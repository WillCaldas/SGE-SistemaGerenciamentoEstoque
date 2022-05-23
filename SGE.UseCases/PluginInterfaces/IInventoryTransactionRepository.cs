using SGE.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases.PluginInterfaces
{
    public interface IInventoryTransactionRepository
    {
        Task PurchaseAsync(string poNumber, Inventory inventory, int quantity, double price, string doneBy);
        Task<IEnumerable<InventoryTransaction>> GetInventoryTransactionsAsync(string invName, DateTime? dateFrom, DateTime? dateTo, InventoryTransactionType? transType);
    }
}

