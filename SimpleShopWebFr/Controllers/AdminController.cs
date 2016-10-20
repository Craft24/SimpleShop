using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleShopWebFr.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginDeal(string username,string passwd)
        {
            
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterDeal()
        {
            return View();
        }
    }
}