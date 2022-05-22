using SGE.CoreBusiness;
using SGE.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductTransactionRepository prodTransRep;
        private readonly IProductRepository prodRep;

        public SellProductUseCase(
            IProductTransactionRepository prodTransRep,
            IProductRepository prodRep)
        {
            this.prodTransRep = prodTransRep;
            this.prodRep = prodRep;
        }

        public async Task ExecuteAsync(string salesOrderNumber, Product product, int quantity, string doneBy)
        {
            await this.prodTransRep.SellProductAsync(salesOrderNumber, product, quantity, product.Price, doneBy);

            product.Quantity -= quantity;
            await this.prodRep.UpdateProductAsync(product);
        }
    }
}

