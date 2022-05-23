using SGE.CoreBusiness;
using SGE.UseCases.Interfaces;
using SGE.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases.Reports
{
    public class SearchInventoryTransactionsUseCase : ISearchInventoryTransactionsUseCase
    {
        private readonly IInventoryTransactionRepository invTransRep;

        public SearchInventoryTransactionsUseCase(IInventoryTransactionRepository invTransRep)
        {
            this.invTransRep = invTransRep;
        }

        public async Task<IEnumerable<InventoryTransaction>> ExecuteAsync(
            string invName,
            DateTime? dateFrom,
            DateTime? dateTo,
            InventoryTransactionType? transType
            )
        {
            return await this.invTransRep.GetInventoryTransactionsAsync(invName, dateFrom, dateTo, transType);
        }
    }
}

