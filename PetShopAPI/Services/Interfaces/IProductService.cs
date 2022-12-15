using PetShopAPI.DataDB;
using PetShopAPI.PetShop.API.Models;

namespace PetShopAPI.Services.Interfaces
{
    public interface IProductService
    {
        //in der interface stehen nur die methoden ohne rumpf, also ohne {}

        Task<Product> PostAsync(ProductModel model);

        Task<Product> ReadProduct(int id);
        //Task<Product> ReadProduct(string Name, string Category, double Price); wäre auch richtig
        Task<Product> UpdateProduct(int id, ProductModel model);
        Task<Product> DeleteProduct(int id);

        //kein public bei interfaces, da es ohnehin implementiert wird
    }
}
//role post model