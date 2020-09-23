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
        public ActionResult AddAbonent()
        {
             return View();
        }

        [HttpPost]
        public ActionResult AddAbonent(Abonent abonent, HttpPostedFileBase file)
        {
            //формирование пути для сохранения нового файла
            string path = Server.MapPath($"~/Images/{file.FileName}");
            file.SaveAs(path);

            var last = abonents.Last();
            abonent.Id = last is null ? 1 : last.Id + 1;
            abonent.Image = $"{file.FileName}";

            //добавление к общему списку
            abonents.Add(abonent);

            return View("Index", abonents);
        }

        public ActionResult SerchAbonent()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult SerchAbonent(string from)
        {
            if (from is null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var srchResult = abonents.Where(p => p.Name == from).ToList();
            ;
            return View("Index", srchResult);
        }
    }
}