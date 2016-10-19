using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public class User: MyObject
    {
        public virtual string Name { get; set; }

        public virtual string Passwd { get; set; }

        public virtual string QQ { get; set; }

        public virtual string TelPhone { get; set; }

        public virtual string CellPhone { get; set; }

        public virtual bool Sex { get; set; }        
    }
}