using SklepUKW.DAL;
using SklepUKW.Models;
using SklepUKW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepUKW.Controllers
{
    public class HomeController : Controller
    {
        FilmsContext db = new FilmsContext();

        // GET: Home
        public ActionResult Index()
        {
            /*
            Category category = new Category()
            {
                CategoryID = 1,
                Name = "Horror",
                Desc = "Filmy od lat 18."
            };
            db.Categories.Add(category); // dodanie utworzonego obiektu
             db.SaveChanges();// zapisanie zmian
            var categories = db.Categories.ToList();
            IndexViewModel ivm = new IndexViewModel();
            ivm.Categories = categories;
             return View(ivm);
            */
            IndexViewModel model = new IndexViewModel();
            var najdluzsze = db.Films.OrderByDescending(f => f.FilmLength).Take(3);
            model.Top3LongestFilms = najdluzsze;
            return View(model);
            //return View();
        }

        public ActionResult StaticSite(string name)
        {
            return View(name);
        }
    }
}