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
            modelBuilder.Entity<ProductInventory>()
                .HasKey(pi => new { pi.ProductId, pi.InventoryId });

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductInventories)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductInventory>()
                .HasOne(pi => pi.Inventory)
                .WithMany(i => i.ProductInventories)
                .HasForeignKey(pi => pi.InventoryId);


            //Informações Adicionadas

            modelBuilder.Entity<Inventory>()
                .HasData(
                new Inventory { InventoryId = 1, InventoryName = "Motor", Price = 1000, Quantity = 1},
                new Inventory { InventoryId = 2, InventoryName = "Chasis", Price = 400, Quantity = 1},
                new Inventory { InventoryId = 3, InventoryName = "Roda", Price = 150, Quantity = 4},
                new Inventory { InventoryId = 4, InventoryName = "Motor Eletrico", Price = 1600, Quantity = 1 },
                new Inventory { InventoryId = 5, InventoryName = "Banco", Price = 1000, Quantity = 10 }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { ProductId = 1, ProductName = "Carro Combustão", Price = 1000, Quantity = 1 },
                new Product { ProductId = 2, ProductName = "Carro Eletrico", Price = 400, Quantity = 1 }
                );

            modelBuilder.Entity<ProductInventory>()
                .HasData(
                    new ProductInventory { ProductId = 1, InventoryId = 1, InventoryQuantity = 1 },
                    new ProductInventory { ProductId = 1, InventoryId = 2, InventoryQuantity = 1 },
                    new ProductInventory { ProductId = 1, InventoryId = 3, InventoryQuantity = 4 },
                    new ProductInventory { ProductId = 1, InventoryId = 5, InventoryQuantity = 5 }
                );

            modelBuilder.Entity<ProductInventory>()
                .HasData(
                    new ProductInventory { ProductId = 2, InventoryId = 4, InventoryQuantity = 1 },
                    new ProductInventory { ProductId = 2, InventoryId = 2, InventoryQuantity = 1 },
                    new ProductInventory { ProductId = 2, InventoryId = 3, InventoryQuantity = 4 },
                    new ProductInventory { ProductId = 2, InventoryId = 5, InventoryQuantity = 5 }
                );

        }
    }
}


