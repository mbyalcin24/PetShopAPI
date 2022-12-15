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
            using (var context = TestUtils.CreateContext()) 
            {
                context.Customers.RemoveRange(context.Customers);
              //  context.Orders.RemoveRange(context.Orders);
                await context.SaveChangesAsync();
            }
        }
    }
}