using SklepUKW.DAL;
using SklepUKW.Infrastructure;
using SklepUKW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepUKW.Controllers
{
    public class CartController : Controller
    {
        CartManager cartManager;
        ISessionManager session;
        FilmsContext db;

        public CartController()
        {
            db = new FilmsContext();
            session = new SessionManager();
            cartManager = new CartManager(db, session);
        }

        // GET: Cart
        public ActionResult Index()
        {
            CartViewModel cvm = new CartViewModel()
            {
                CartItems = cartManager.GetCartItems(),
                TotalPrice = cartManager.GetCartValue()
            };
            return View(cvm);
        }

        public ActionResult AddToCart(int id)
        {
            cartManager.AddToCart(id);

            return RedirectToAction("Index"); //w nawiasie string z nazwą akcji
        }

        public ActionResult RemoveFromCart(int id)
        {
            ItemRemoveViewModel model = new ItemRemoveViewModel()
            {
                ItemID = id,
                ItemQuantity = cartManager.RemoveFromCart(id),
                CartValue = cartManager.GetCartValue(),
                CartQuantity = cartManager.GetCartQuantity()
            };

            return Json(model);
        }

        public int GetCartQuantity()
        {
            return cartManager.GetCartQuantity();
        }
    }
}