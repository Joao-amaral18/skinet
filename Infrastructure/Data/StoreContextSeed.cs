using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public static class StoreContextSeed
{
    //insert seedData into db
    public static async Task SeedAsync(StoreContext context)
    {
        //verify if already has data
        if (!context.ProductBrand.Any())
        {
            var brandsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            context.ProductBrand.AddRange(brands);
        }
        if (!context.ProductType.Any())
        {
            var typeData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
            context.ProductType.AddRange(types);
        }
        if (!context.Products.Any())
        {
            var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
            var product = JsonSerializer.Deserialize<List<Product>>(productsData);
            context.Products.AddRange(product);
        }

        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();
    }
}