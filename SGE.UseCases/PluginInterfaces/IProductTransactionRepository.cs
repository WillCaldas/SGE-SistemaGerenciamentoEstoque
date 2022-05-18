using SGE.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases.PluginInterfaces
{
    public interface IProductTransactionRepository
    {
        Task ProduceAsync(string prodNumber, Product prod, int quantity, double price, string doneBy);
    }
}

