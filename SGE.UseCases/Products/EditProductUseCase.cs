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
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository prodRep;

        public EditProductUseCase(IProductRepository prodRep)
        {
            this.prodRep = prodRep;
        }

        public async Task ExecuteAsync(Product prod)
        {
            await prodRep.UpdateProductAsync(prod);
        }
    }
}

