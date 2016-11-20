using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleShopWebFr.Areas.AdminManager.Controllers
{
    public class DefaultController : Controller
    {
        // GET: AdminManager/Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Login()
        {
            string username = Request.Form["username"].ToString();
            string passwd = Request.Form["password"].ToString();
            using (var db = new Models.SimpleShopDbContext())
            {
                var admin = db.Admins.FirstOrDefault(p => p.Name == username);
                if (admin != null)
                {
                    byte[] passwordAndSaltBytes = System.Text.Encoding.UTF8.GetBytes(passwd + admin.Salt);
                    byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordAndSaltBytes);
                    string hashString = Convert.ToBase64String(hashBytes);

                    if (hashString == admin.Passwd)
                    {
                        // user login successfully 
                        Response.Redirect("/AdminManager/Default/Main");
                    }
                    else
                    {
                        throw new ApplicationException("invalid user name and password");
                    }
                }
                else
                {
                    Response.Redirect("/AdminManager/Default/Index");
                }
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void RegisterDeal()
        {
            string username = Request.Form["username"].ToString();
            string passwd = Request.Form["passwd"].ToString();
            string salt = Guid.NewGuid().ToString();
            byte[] passwordAndSaltBytes = System.Text.Encoding.UTF8.GetBytes(passwd + salt);
            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordAndSaltBytes);

            string hashString = Convert.ToBase64String(hashBytes);
            using (var db = new Models.SimpleShopDbContext())
            {
                var admin = db.Admins.Add(new Models.Admin { Name = username, Passwd = hashString, CellPhone = "13283888062", Salt = salt });
                var rs = db.SaveChanges();
                if (rs > 0)
                {
                    Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(admin));
                }
            }
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}