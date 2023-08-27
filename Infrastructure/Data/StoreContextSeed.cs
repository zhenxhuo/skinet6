using System.Text.Json;
using Core.Entities;


namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        
        public static async Task SeedAsync(StoreContext context)
        {
            if(!context.ProductBrand.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrand.AddRange(brands);
            }

            if(!context.ProductType.Any())
            {
                var TypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                context.ProductType.AddRange(Types);
            }

            if(!context.Products.Any())
            {
                var ProductData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var Product = JsonSerializer.Deserialize<List<Product>>(ProductData);
                context.Products.AddRange(Product);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }


    }
}