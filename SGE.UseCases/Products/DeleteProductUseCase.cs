using SGE.UseCases.Interfaces;
using SGE.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases.Products
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository prodRep;

        public DeleteProductUseCase(IProductRepository prodRep)
        {
            this.prodRep = prodRep;
        }

        public async Task ExecuteAsync(int prodId)
        {
            await prodRep.DeleteProductAsync(prodId);
        }
    }
}
