﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class Product : MyObject
    {
        [Required]
        public virtual string ProductName { get; set; }

        /// <summary>
        /// 单价，单位为分
        /// </summary>
        public virtual int UnitPrice { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public virtual string ProductDescription { get; set; }

        public virtual List<Photo> Photos { get; set; }
    }
}