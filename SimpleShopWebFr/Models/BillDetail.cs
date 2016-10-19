using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class BillDetail
    {
        public virtual int Id { get; set; }

        public virtual Member Member { get; set; }

        /// <summary>
        /// 收支标志
        /// </summary>
        public virtual bool Flag { get; set; }

        public virtual int Amount { get; set; }

        public virtual string BillDescription { get; set; }

        public virtual DateTime CreateDate { get; set; }
    }
}