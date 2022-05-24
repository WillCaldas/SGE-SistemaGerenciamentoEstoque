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
    public class SearchProductTransactionUseCase : ISearchProductTransactionUseCase
    {
        private readonly IProductTransactionRepository prodTransProd;

        public SearchProductTransactionUseCase(IProductTransactionRepository ProdTransProd)
        {
            prodTransProd = ProdTransProd;
        }
        public async Task<IEnumerable<ProductTransaction>> ExecuteAsync(
            string prodName,
            DateTime? dateFrom,
            DateTime? dateTo,
            ProductTransactionType? transType
            )
        {
            return await this.prodTransProd.GetProductTransactionsAsync(
                prodName,
                dateFrom,
                dateTo,
                transType);
        }
    }
}


