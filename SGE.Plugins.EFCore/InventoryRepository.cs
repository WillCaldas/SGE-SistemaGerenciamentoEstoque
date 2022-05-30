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
                db.InventoryName.ToLower().IndexOf(name.ToLower()) >= 0).ToListAsync();

            //return await this.dbContext
            //    .Inventories
            //    .Where(db =>
            //    db.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
            //    string.IsNullOrWhiteSpace(name)).ToListAsync();
        }

        public async Task AddInventoryAsync(Inventory inventory)
        {
            //Para evitar que diferentes itens de estoque tenham o mesmo nome
            if (dbContext.Inventories.Any(db => db.InventoryName.ToLower() == inventory.InventoryName.ToLower()))
            {
                return;
            }

            this.dbContext.Inventories.Add(inventory);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task UpdateInventoryAsync(Inventory inventory)
        {
            //Para evitar que diferentes itens de estoque tenham o mesmo nome

            if (dbContext.Inventories.Any(x => x.InventoryId != inventory.InventoryId && 
                                           x.InventoryName.ToLower() == inventory.InventoryName.ToLower()))
            {
                return;
            }



            var invFind = await this.dbContext.Inventories.FindAsync(inventory.InventoryId);
            if (invFind != null)
            {
                invFind.InventoryName = inventory.InventoryName;
                invFind.Quantity = inventory.Quantity;
                invFind.Price = inventory.Price;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
        {
            return await this.dbContext.Inventories.FindAsync(inventoryId);
        }
    }
}


