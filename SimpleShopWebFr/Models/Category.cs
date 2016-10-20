using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class Category : MyObject
    {
        [Required]
        public virtual string CategoryName { get; set; }

        public virtual string Description { get; set; }

        public virtual int ParentId { get; set; }
    }
}