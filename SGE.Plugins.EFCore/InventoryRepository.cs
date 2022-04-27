using SGE.CoreBusiness;
using SGE.UseCases.PluginInterfaces;

namespace SGE.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        public Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}


