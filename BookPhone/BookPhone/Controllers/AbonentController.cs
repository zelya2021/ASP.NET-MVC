using BookPhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookPhone.Controllers
{
    public class AbonentController : Controller
    {
        static List<Abonent> abonents = new List<Abonent>();
        static AbonentController()
        {
            abonents.Add(new Abonent
            {
                Id = 1,
                Name= "Vovchik",
                SurName="Bro",
                Number="+380662795813",
                Image = "https://www.meme-arsenal.com/memes/d79efba0311568213b72260eb2c68b4f.jpg"
            });
        }
        public ActionResult Index()
        {
            ViewData["abonents"] = abonents;
            return View();
        }
        public ActionResult Detail(int? id)
        {
            if (id is null)
            {
                return new HttpNotFoundResult();
            }
            var abonent = abonents.FirstOrDefault(a => a.Id == id);
            if (abonent is null)
            {
                return new HttpNotFoundResult();
            }
            //ViewData["abonent"] = abonent;
            //ViewBag.Abonent = abonent;
            return View(abonent);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Abonent abonent)
        {
            var lastAbonent = abonents.LastOrDefault();
            abonent.Id = lastAbonent is null ? 1 : lastAbonent.Id + 1;
            abonents.Add(abonent);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id is null)
            {
                return new HttpNotFoundResult();
            }
            var abonent = abonents.FirstOrDefault(a => a.Id == id);
            if (abonent is null)
            {
                return new HttpNotFoundResult();
            }
            abonents.Remove(abonent);
            return RedirectToAction("Index");
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
            ViewBag.Abonent = abonent;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Abonent abonent)
        {
            var editAbonent = abonents.FirstOrDefault(p => p.Id == abonent.Id);
            if (editAbonent != null)
            {
                editAbonent.Name = abonent.Name;
                editAbonent.SurName = abonent.SurName;
                editAbonent.Number = abonent.Number;
                editAbonent.Image = abonent.Image;
            }
            return RedirectToAction("Index");
        }
    }
}