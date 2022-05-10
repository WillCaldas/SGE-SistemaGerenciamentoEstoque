using SGE.CoreBusiness;
using SGE.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository productInventory;

        public async Task ExecuteAsync(Product prod)
        {
            if (prod == null)
            {
                return;
            }

            await productInventory.AddProductAsync(prod);
        }
    }
}
