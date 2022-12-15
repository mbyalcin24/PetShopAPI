using System;
using System.Collections.Generic;

namespace PetShopAPI.DataDB
{
    public partial class Order
    {
        public Order()
        {
           // ProductOrders = new HashSet<ProductOrder>();
           // Customers = new HashSet<Customer>();
           ProductOrders = new List<ProductOrder>();
            
        }

        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }

        //public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        // public virtual ICollection<Customer> Customers { get; set; }

    }
}
