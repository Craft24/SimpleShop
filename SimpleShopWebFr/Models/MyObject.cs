using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class MyObject
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual DateTime CreateDateTime { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual DateTime DeleteDateTime { get; set; }

        public MyObject()
        {
            CreateDateTime = DateTime.Now;
            IsDeleted = false;
        }
    }
}