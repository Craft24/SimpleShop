using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class BillDetail : MyObject
    {
        [Required]
        public virtual Member Member { get; set; }

        /// <summary>
        /// 收支标志
        /// </summary>
        [Required]
        public virtual bool Flag { get; set; }

        /// <summary>
        /// 收支金额，单位为分
        /// </summary>
        public virtual int Amount { get; set; }

        /// <summary>
        /// 单据描述，主要是指这比费用干什么的
        /// </summary>
        public virtual string BillDescription { get; set; }

    }
}