using SGE.CoreBusiness;
using SGE.UseCases.Interfaces;
using SGE.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases.Activities
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
            await prodTransRep.SellProductAsync(salesOrderNumber, product, quantity, product.Price, doneBy);

            product.Quantity = product.Quantity - quantity;
            await prodRep.UpdateProductAsync(product);
        }
    }
}

