using SimpleShopWebFr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleShopWebFr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SimpleShopDbContext db = new SimpleShopDbContext();
            Admin admin = new Admin();
            admin.CellPhone = "13283888062";
            admin.Name = "admin";
            admin.Passwd = "admin";
            db.Admins.Add(admin);
            db.SaveChanges();
            var adminobj = db.Admins.FirstOrDefault();
            return View(adminobj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}