using Microsoft.EntityFrameworkCore;
using SGE.CoreBusiness;
using SGE.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly SGEContext dbContext;

        public ProductRepository(SGEContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddProductAsync(Product product)
        {
            if (dbContext.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductsByName(string name)
        {
            return await this.dbContext
                .Products
                .Where(db =>
                db.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrWhiteSpace(name)).ToListAsync();
        }
    }
}
