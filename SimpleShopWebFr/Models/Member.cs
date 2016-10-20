using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class Member : User
    {
        /// <summary>
        /// 会员等级
        /// </summary>
        public virtual int Level { get; set; }
    }
}