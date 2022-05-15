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
    public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
    {
        private readonly IProductRepository prodRepo;

        public ViewProductsByNameUseCase(IProductRepository prodRepo)
        {
            this.prodRepo = prodRepo;
        }

        public async Task<List<Product>> ExecuteAsync(string name = "")
        {
            return await prodRepo.GetProductsByNameAsync(name);
        }
    }
}
