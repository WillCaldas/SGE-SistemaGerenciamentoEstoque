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
        public DbSet<Product> Products{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasData(
                new Inventory { InventoryId = 1, InventoryName = "Motor", Price = 1000, Quantity = 1},
                new Inventory { InventoryId = 2, InventoryName = "Chasis", Price = 400, Quantity = 1},
                new Inventory { InventoryId = 3, InventoryName = "Roda", Price = 150, Quantity = 4},
                new Inventory { InventoryId = 4, InventoryName = "Motor Eletrico", Price = 1600, Quantity = 1 },
                new Inventory { InventoryId = 5, InventoryName = "Baterias", Price = 1000, Quantity = 10 }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { ProductId = 1, ProductName = "Carro Combustão", Price = 1000, Quantity = 1 },
                new Product { ProductId = 2, ProductName = "Carro Eletrico", Price = 400, Quantity = 1 }
                );
        }
    }
}


