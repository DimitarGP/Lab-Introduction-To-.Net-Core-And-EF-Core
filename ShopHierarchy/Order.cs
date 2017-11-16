using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHierarchy
{
    public class Order
    {
        public int Id { get; set;}

        public int  CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
