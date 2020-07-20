using BLL.Interfaces;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstChe.Controllers
{
    public class CartController : Controller
    {
        private IItemRepository repository;
        public CartController (IItemRepository cr)
        {
            repository = cr;
        }

        //public RedirectToRouteResult AddToCart (int itemId, string returnUrl)
        //{
            
        //}

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
    }
}