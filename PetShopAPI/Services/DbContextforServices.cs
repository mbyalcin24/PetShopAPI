using PetShopAPI.DataDB;

namespace PetShopAPI.Services
{
    public class DbContextforServices
    {
        public static PetShopDbContext CreateContext()
        {
            return new PetShopDbContext("Server=.\\sqlexpress;Database=PetShopDB_Test3;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}


