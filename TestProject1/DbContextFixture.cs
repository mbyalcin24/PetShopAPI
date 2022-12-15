using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class DbContextFixture : IAsyncLifetime
    {
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            using var context = TestUtils.CreateContext(); // greift auf die klasse zu in der die connection zur db hergestellt wird
            context.Orders.RemoveRange(context.Orders);
            await context.SaveChangesAsync();
           
             context.Products.RemoveRange(context.Products); // damit das löschen vorgenommen werden kann
            await context.SaveChangesAsync();
        }
    }
}
