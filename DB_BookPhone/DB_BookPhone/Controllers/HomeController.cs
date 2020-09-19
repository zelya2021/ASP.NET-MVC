using DB_BookPhone.Models;
using DB_BookPhone.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_BookPhone.Controllers
{
    public class HomeController : Controller
    {
        static List<Abonent> abonents = new List<Abonent>();
        static HomeController()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        public ActionResult Index()
        {
            using (DatabaseContext ctx=new DatabaseContext())
            {
                abonents = ctx.Abonents.ToList();
            }
            return View(abonents);
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