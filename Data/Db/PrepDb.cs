using System;
using System.IO;
using System.Xml.Linq;

namespace Warehouse.Data.Db
{
    public static class PrepDb
    {
        public static void PrepPopular(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<WarehouseDbContext>());
            }
        }

        private static void SeedData(WarehouseDbContext context)
        {

                Console.WriteLine("--> Seeding Data..");
            //Category
                context.Categories.AddRange(
                    new Entity.CategoryEntity() { Name = "Дом" },
                    new Entity.CategoryEntity() { Name = "Животные" },
                    new Entity.CategoryEntity() { Name = "Электроника" }
                    );
            //Address
            context.Addresses.AddRange(
                new Entity.AddressEntity() { Country = "Russia", City = "Pskow", Street = "Lenina"},
                new Entity.AddressEntity() { Country = "Italy", City = "Rim", Street = "Losia"},
                new Entity.AddressEntity() { Country = "Russia", City = "Moscow", Street = "Ligov" }
                );

            //Supplier
            context.Suppliers.AddRange(
                new Entity.SupplierEntity() { Name = "Llama", AddressId = 2, PhoneNumber = "6514654698786"},
                new Entity.SupplierEntity() { Name = "VOLCHAROV", AddressId = 1, PhoneNumber = "1116965"},
                new Entity.SupplierEntity() { Name = "MV", AddressId = 3, PhoneNumber = "8979843246"}
                );
            //Product
            context.Products.AddRange(
                new Entity.ProductEntity() { Name = "Телевизор", CategoryId = 3, 
                    Price = 400000, AvailableStock = 100, 
                    LastUpdateDate =  DateTime.Now, ValidUntile = DateTime.Now , SupplierId = 1},
                new Entity.ProductEntity() { Name = "Телевизор", CategoryId = 3, 
                    Price = 400000, AvailableStock = 100, 
                    LastUpdateDate =  DateTime.Now, ValidUntile = DateTime.Now , SupplierId = 1},
                new Entity.ProductEntity() { Name = "Телевизор", CategoryId = 3, 
                    Price = 400000, AvailableStock = 100, 
                    LastUpdateDate =  DateTime.Now, ValidUntile = DateTime.Now , SupplierId = 1}
                );
            context.SaveChanges();
        }
    }
}
