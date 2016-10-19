using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class Photo : MyObject
    {
        public virtual string PhotoUrl { get; set; }

        public virtual int SortNum { get; set; }

        public virtual string ThumbPhotoUrl { get; set; }
    }
}