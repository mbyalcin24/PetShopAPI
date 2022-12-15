using PetShopAPI.DataDB;

namespace TestProject1
{
    public static class TestUtils // dies ist die klasse in der die verbindung zur db hergestellt wird
    {
        public static PetShopDbContext CreateContext() 
        {
            return new PetShopDbContext("Server=.\\sqlexpress;Database=PetShopDB_Test3;Trusted_Connection=True;TrustServerCertificate=True;");
        }    
    }
}