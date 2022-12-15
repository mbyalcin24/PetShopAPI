using System;
using System.Collections.Generic;

namespace PetShopAPI.DataDB
{
    public partial class Product
    {
        public Product()
        {
            ProductOrders = new List<ProductOrder>();
            //ProductOrders = new HashSet<ProductOrder>();
        }

        public int ID { get; set; }
       // public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public double Price { get; set; }

        //public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public List<ProductOrder> ProductOrders { get; }
    }
}
