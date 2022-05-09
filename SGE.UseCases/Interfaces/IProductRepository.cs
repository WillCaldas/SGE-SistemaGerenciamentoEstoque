using SGE.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByName(string name);
    }
}

