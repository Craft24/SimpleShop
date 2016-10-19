using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    public enum OrderStatus
    {
        UnPayed,
        IsPayed,
        Failed,
        Success
    }
}