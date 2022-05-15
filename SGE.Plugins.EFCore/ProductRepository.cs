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

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await dbContext.Products
                .Include(x => x.ProductInventories)
                .ThenInclude(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            return await this.dbContext
                .Products
                .Where(db =>
                db.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrWhiteSpace(name)).ToListAsync();
        }

        public async Task UpdateProductAsync(Product prod)
        {
            if (dbContext.Products.Any(x => x.ProductName.Equals(prod.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }
            
            var product = await dbContext.Products.FindAsync(prod.ProductId);
            if (product != null)
            {
                product.ProductName = prod.ProductName;
                product.Price = prod.Price;
                product.Quantity = prod.Quantity;
                product.ProductInventories = prod.ProductInventories;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}

