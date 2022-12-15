using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using PetShopAPI.DataDB;

namespace PetShopAPI.Tests
{
    public static class TestUtilsPetShop
    {
        public static PetShopDbContext CreateContext()
        {

            return new PetShopDbContext("Server=.\\sqlexpress;Database=PetShopDB_test3;Trusted_Connection=True;TrustServerCertificate=True;"); 
        }
    }
}
