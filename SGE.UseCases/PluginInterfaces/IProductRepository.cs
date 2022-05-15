﻿using SGE.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases.PluginInterfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<List<Product>> GetProductsByNameAsync(string name);
        Task<Product> GetProductByIdAsync(int id);
        Task UpdateProductAsync(Product prod);
        Task DeleteProductAsync(int prodId);
    }
}

