using Microsoft.EntityFrameworkCore;
using SGE.CoreBusiness;
using SGE.UseCases.PluginInterfaces;

namespace SGE.Plugins.EFCore
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly SGEContext dbContext;

        public InventoryRepository(SGEContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            return await this.dbContext
                .Inventories
                .Where(db => 
                db.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase) || 
                string.IsNullOrWhiteSpace(name)).ToListAsync();
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            this.dbContext.Inventories.Add(inventory);
            await this.dbContext.SaveChangesAsync();
        }
    }
}


