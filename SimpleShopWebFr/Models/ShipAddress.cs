using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class ShipAddress : MyObject
    {
        [Required]
        public virtual string ReceivePerson { get; set; }

        [Required]
        public virtual string CellPhone { get; set; }

        [Required]
        public virtual StandardAddress StandardAddress { get; set; }

        [Required]
        public virtual string LastAddress { get; set; }

        public virtual string OtherDesc { get; set; }

        [Required]
        public virtual Member Member { get; set; }
    }
}