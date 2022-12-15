using System;
using System.Collections.Generic;

namespace PetShopAPI.DataDB
{
    public partial class ProductOrder
    {
        public int ProductOrderId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public int Quantity { get; set; }

       
       
    }
}
