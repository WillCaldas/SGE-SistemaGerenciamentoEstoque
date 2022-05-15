using SGE.CoreBusiness;
using SGE.UseCases.Interfaces;
using SGE.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository productInventory;

        public AddProductUseCase(IProductRepository productInventory)
        {
            this.productInventory = productInventory;
        }

        public async Task ExecuteAsync(Product prod)
        {
            if (prod == null) return;

            await productInventory.AddProductAsync(prod);
        }
    }
}

