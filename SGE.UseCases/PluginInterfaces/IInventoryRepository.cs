using SGE.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task UpdateInventoryAsync(Inventory inventory);
        Task AddInventoryAsync(Inventory inventory);
        Task<Inventory?> GetInventoryByIdAsync(int inventoryId);
        Task<IEnumerable<Inventory>> GetInventoriesByName(string name);
    }
}

