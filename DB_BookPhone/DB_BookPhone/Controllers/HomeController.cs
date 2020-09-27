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
            if (abonent.Name!=null&& abonent.SurName != null&& abonent.Number != null)
            {
                using (DatabaseContext ctx = new DatabaseContext())
                {
                    Abonent addedAbonent = new Abonent
                    {
                        Name = abonent.Name,
                        SurName = abonent.SurName,
                        Number = abonent.Number
                    };
                    if (file != null)
                    {
                        //формирование пути для сохранения нового файла
                        string path = Server.MapPath($"~/Images/{file.FileName}");
                        file.SaveAs(path);
                        addedAbonent.Image = file.FileName;
                    }
                    else addedAbonent.Image = "standart.png";

                    ctx.Abonents.Add(addedAbonent);
                    ctx.SaveChanges();
                    abonents = ctx.Abonents.ToList();
                }
            }

            return View("Index",abonents);
        }

        public ActionResult SerchAbonent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SerchAbonent(string from)
        {
            if (from is null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var srchResult = abonents.Where(p => p.Name == from).ToList();
            return View("Index", srchResult);
        }

        public ActionResult DetailAbonent(int? id)
        {
            if (id is null)
            {
                return new HttpNotFoundResult();
            }
            var abonent = abonents.FirstOrDefault(p => p.Id == id);
            if (abonent is null)
            {
                return new HttpNotFoundResult();
            }
            return View(abonent);
        }

        public ActionResult Edit(int? id)
        {
            if (id is null)
            {
                return new HttpNotFoundResult();
            }
            var abonent = abonents.FirstOrDefault(p => p.Id == id);
            if (abonent is null)
            {
                return new HttpNotFoundResult();
            }
            return View(abonent);
        }
        [HttpPost]
        public ActionResult Edit(Abonent abonent, HttpPostedFileBase file)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                var editAbonent = ctx.Abonents.FirstOrDefault(p => p.Id == abonent.Id);
                if (editAbonent != null)
                {
                    editAbonent.Name = abonent.Name;
                    editAbonent.SurName = abonent.SurName;
                    editAbonent.Number = abonent.Number;
                    if (file != null && abonent.Image != file.FileName)
                    {
                        string path = Server.MapPath($"~/Images/{file.FileName}");
                        file.SaveAs(path);
                        editAbonent.Image = $"{file.FileName}";
                    }
                }
                ctx.SaveChanges();
                abonents = ctx.Abonents.ToList();
            }
                
            return RedirectToAction("Index",abonents);
        }
        public ActionResult Delete(int? id)
        {
            if (id is null)
            {
                return new HttpNotFoundResult();
            }
            using (DatabaseContext ctx = new DatabaseContext())
            {
                var abonent = ctx.Abonents.FirstOrDefault(p => p.Id == id);
                if (abonent is null)
                {
                    return new HttpNotFoundResult();
                }
                ctx.Abonents.Remove(abonent);
                ctx.SaveChanges();
                abonents = ctx.Abonents.ToList();
            }
               
            return RedirectToAction("Index",abonents);
        }
    }
}