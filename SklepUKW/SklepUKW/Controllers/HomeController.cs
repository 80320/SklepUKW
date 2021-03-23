using SklepUKW.DAL;
using SklepUKW.Models;
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
            Category category = new Category()
            {
                CategoryID = 1,
                Name = "Horror",
                Desc = "Filmy od lat 18."
            };
            db.Categories.Add(category); // dodanie utworzonego obiektu
             db.SaveChanges();// zapisanie zmian
            return View();
        }
    }
}