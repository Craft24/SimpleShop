using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class Order : MyObject
    {
        public virtual Member Member { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
    }
}