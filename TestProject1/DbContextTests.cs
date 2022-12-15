using Microsoft.EntityFrameworkCore;
using PetShopAPI.DataDB;

namespace TestProject1
{
    public class DbContextTests : DbContextFixture
    {
        [Fact] //sagt einfach nur aus dass es ein unit test ist
        public async Task TestCustomerCreation()
        {
            var customer = new Customer
            {
                FirstName = "FirstName7",
                LastName = "LastName",
                Adress = "Straﬂe 1", 
                PostalCode = 12345,
                City = "Stadt",
                Mail = "test@mail.com"
            };

            using (var context = TestUtils.CreateContext())
            {
                context.Customers.Add(customer);
                await context.SaveChangesAsync();
            }

            using (var context = TestUtils.CreateContext())
            {
                var customerFromDb = await context.Customers.FirstOrDefaultAsync();
                Assert.NotNull(customerFromDb);
                Assert.Equal(customer.ID, customerFromDb.ID);
                Assert.Equal(customer.FirstName, customerFromDb.FirstName);
                Assert.Equal(customer.LastName, customerFromDb.LastName);
                Assert.Equal(customer.Adress, customerFromDb.Adress);
                Assert.Equal(customer.PostalCode, customerFromDb.PostalCode);
                Assert.Equal(customer.City, customerFromDb.City);
                Assert.Equal(customer.Mail, customerFromDb.Mail);
            }
        }
        [Fact] //sagt einfach nur aus dass es ein unit test ist
        public async Task TestOrderCreation()
        {
            var customer = new Customer
            {
                FirstName = "FirstName7",
                LastName = "LastName",
                Adress = "Straﬂe 1",
                PostalCode = 12345,
                City = "Stadt",
                Mail = "test@mail.com"
            };

            var order = new Order
            {
                OrderDate = System.DateTime.Today,
                //OrderDate = System.DateTime.Now,
               // OrderDate = DateTime.UtcNow,
                Total = 23,
                Customer =  customer
                
            };


           

            using (var context = TestUtils.CreateContext()) //hier wird die verbindung zur db hergestelllt und gespeichert
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();

            }

            using (var context = TestUtils.CreateContext())
            {
                var orderFromDb = await context.Orders.FirstOrDefaultAsync();
                Assert.NotNull(orderFromDb);
                Assert.Equal(order.Total, orderFromDb.Total);
                Assert.Equal(order.OrderDate, orderFromDb.OrderDate);
                Assert.Equal(order.CustomerId, orderFromDb.CustomerId);
            }
        }
        [Fact] //sagt einfach nur aus dass es ein unit test ist
        public async Task TestProductCreation()
        {
            var product = new Product
            {
                Name = "Testhund",
                Category = "dog",
                Price = 12.22,
            };

            using (var context = TestUtils.CreateContext())
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
            }

            using (var context = TestUtils.CreateContext())
            {
                var productFromDb = await context.Products.FirstOrDefaultAsync();
                Assert.NotNull(productFromDb);
                Assert.Equal(product.ID, productFromDb.ID);
                Assert.Equal(product.Name, productFromDb.Name);
                Assert.Equal(product.Category, productFromDb.Category);
                Assert.Equal(product.Price, productFromDb.Price);

            }
        }
    }
}