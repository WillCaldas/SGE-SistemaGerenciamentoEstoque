using SGE.CoreBusiness;
using SGE.UseCases.Interfaces;
using SGE.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases.Validations
{
    public class ValidateEnoughInventoriesForProducingUseCase : IValidateEnoughInventoriesForProducingUseCase
    {
        private readonly IProductRepository prodRep;

        public ValidateEnoughInventoriesForProducingUseCase(IProductRepository prodRep)
        {
            this.prodRep = prodRep;
        }
        public async Task<bool> ExecuteAsync(Product prod, int quantity)
        {
            var produ = await prodRep.GetProductByIdAsync(prod.ProductId);
            foreach (var prodInv in produ.ProductInventories)
            {
                if (prodInv.InventoryQuantity * quantity > prodInv.Inventory.Quantity)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
