using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class Order : MyObject
    {
        [Required]
        public virtual Member Member { get; set; }

        [Required]
        public virtual List<Product> Products { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public virtual int Amount { get; set; }

        /// <summary>
        /// 订单状态,0已创建，1已付款，2已审核，3已发货，4成功，5失败
        /// </summary>
        public virtual int Status { get; set; }

        public Order()
        {
            Products.ForEach(p => Amount += p.UnitPrice);            
        }
    }
}