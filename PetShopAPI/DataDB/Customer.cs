using System;
using System.Collections.Generic;

namespace PetShopAPI.DataDB
{
    public partial class Customer
    {
        public Customer()
        {
           // ProductOrders = new List<ProductOrder>();
            Order = new List<Order>();
        }
        public int ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Adress { get; set; }
        public int? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Mail { get; set; }
       // public List<ProductOrder> ProductOrders { get; set; }
        public List<Order> Order { get; }
    }
}
