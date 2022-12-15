using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopAPI.Tests
{
    public class DbContextFixturePetShop : IAsyncLifetime
    {
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            using var context = TestUtilsPetShop.CreateContext();

            context.Products.RemoveRange(context.Products);
            await context.SaveChangesAsync();

        }
    }
}