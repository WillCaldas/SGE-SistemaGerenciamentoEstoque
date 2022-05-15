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
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        private readonly IProductRepository prodRep;

        public ViewProductByIdUseCase(IProductRepository prodRep)
        {
            this.prodRep = prodRep;
        }

        public async Task<Product> ExecuteAsync(int prodId)
        {
            return await prodRep.GetProductByIdAsync(prodId);
        }
    }
}

