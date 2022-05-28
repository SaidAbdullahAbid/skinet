using API.data;
using Core.entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;
// using System.Text.Json;

namespace Infrastructure.data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductsBrand.Any())
                {
                    var brandFullPath = GetFullPathForSeedJonsFile("brands.json");
                    var brands = ConvertFormJasonToObject<IEnumerable<ProductBrand>>(brandFullPath);
                    await context.ProductsBrand.AddRangeAsync(brands);
                    await context.SaveChangesAsync();
                }
                if (!context.ProductsType.Any())
                {

                    var path = GetFullPathForSeedJonsFile("types.json");
                    var types = ConvertFormJasonToObject<IEnumerable<ProductType>>(path);

                    await context.ProductsType.AddRangeAsync(types);
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var path = GetFullPathForSeedJonsFile("products.json");
                    var product = ConvertFormJasonToObject<IEnumerable<Product>>(path);
                    await context.Products.AddRangeAsync(product);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContext>();
                logger.LogError(ex.Message, "An error ocurred during seeding the DB");
            }
        }
        private static T ConvertFormJasonToObject<T>(string fileUrl)
        {
            var fileData = File.ReadAllText(fileUrl);
            return JsonSerializer.Deserialize<T>(fileData);
        }
        private static string GetFullPathForSeedJonsFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("file name is empty");
            }
            string CurrentDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var seedDataFolderPath = "Infrastructure\\data\\SeedData\\";
            var paths = new string[]
            {
                CurrentDirectoryPath,
                seedDataFolderPath,
                fileName
            };
            return Path.Combine(paths);
        }
    }
}