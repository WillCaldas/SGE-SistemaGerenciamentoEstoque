using Microsoft.EntityFrameworkCore;
using SGE.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Plugins.EFCore
{
    public class SGEContext : DbContext
    {
        public SGEContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Inventory> Inventories{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasData(
                new Inventory { InventoryId = 1, InventoryName = "Motor", Price = 1000, Quantity = 1},
                new Inventory { InventoryId = 2, InventoryName = "Chasis", Price = 400, Quantity = 1},
                new Inventory { InventoryId = 3, InventoryName = "Roda", Price = 150, Quantity = 4}
                );
        }
    }
}


