using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class ShipAddress : MyObject
    {
        public virtual string ReceivePerson { get; set; }

        public virtual string CellPhone { get; set; }

        public virtual StandardAddress StandardAddress { get; set; }

        public virtual string LastAddress { get; set; }

        public virtual string OtherDesc { get; set; }

        public virtual Member Member { get; set; }
    }
}