using SklepUKW.DAL;
using SklepUKW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepUKW.Controllers
{
    public class FilmsController : Controller
    {
        FilmsContext db = new FilmsContext();

        // GET: Films
        public ActionResult Index()
        {
            return View();
        }

        // lista filmów do danej kategorii
        public ActionResult List(string categoryName)
        {
            var category = db.Categories.Include("Films").Where(c => c.Name.ToLower() == categoryName.ToLower()).Single();

            IndexViewModel model = new IndexViewModel();
            model.Categories = category;
            model.FilmsFromCategory = category.Films.ToList();
            var nowosci = db.Films.OrderByDescending(f => f.AddDate).Take(3);
            model.Top3NewestFilms = nowosci;
            return View(model); //category.Films.ToList()
        }

        [ChildActionOnly] //zabezpieczenie, ze mozna ja wywolac tylko z poziomu innej akcji
        public ActionResult CategoriesMenu()
        {
            var categoryList = db.Categories.ToList();
            return PartialView("_CategoriesMenu", categoryList); //zwróc widok czastkowy
        }
    }
}