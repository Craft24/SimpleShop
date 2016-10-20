using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class Photo : MyObject
    {
        [Required]
        public virtual string PhotoUrl { get; set; }
        
        public virtual int SortNum { get; set; }

        [Required]
        public virtual string ThumbPhotoUrl { get; set; }
    }
}