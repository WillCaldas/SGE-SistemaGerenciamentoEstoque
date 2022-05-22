using SGE.CoreBusiness;
using SGE.UseCases.Interfaces;
using SGE.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases
{
    public class ProduceProductUseCase : IProduceProductUseCase
    {
        private readonly IInventoryRepository invRep;
        private readonly IProductRepository prodRep;
        private readonly IInventoryTransactionRepository invTransRep;
        private readonly IProductTransactionRepository prodTransRep;

        public ProduceProductUseCase(
            IInventoryRepository invRep,
            IProductRepository prodRep,
            IInventoryTransactionRepository invTransRep,
            IProductTransactionRepository prodTransRep)
        {
            this.invRep = invRep;
            this.prodRep = prodRep;
            this.invTransRep = invTransRep;
            this.prodTransRep = prodTransRep;
        }
        public async Task ExecuteAsync(string prodOrder, Product product, int quantity, string doneBy)
        {
            await this.prodTransRep.ProduceAsync(prodOrder, product, quantity, product.Price, doneBy);

            product.Quantity += quantity;
            await this.prodRep.UpdateProductAsync(product);
        }
    }
}

