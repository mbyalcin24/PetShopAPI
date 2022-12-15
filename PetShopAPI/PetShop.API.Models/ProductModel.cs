namespace PetShopAPI.PetShop.API.Models
{
    public class ProductModel
    {

        public int ID { get; set; }
        // public int ProductId { get; set; }
        public string Name { get; set; } //= null!;
        public string Category { get; set; } //= null!;
        public double Price { get; set; }
    }
}
