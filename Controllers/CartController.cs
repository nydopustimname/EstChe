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

        //public string ShoppingCartId { get; set; }

        //private ApContext db = new ApContext();

        //public const string CartSessionKey = "CartId";

        //public void AddToCart(int id)
        //{
        //    var cartItem = db.ShoppingCart.SingleOrDefault(
        //  c => c.CartId == ShoppingCartId
        //  && c.ProductId == id);
        //    if (cartItem == null)
        //    {
        //        cartItem = new Cart
        //        {
        //            ItemId = Guid.NewGuid().ToString(),
        //            ProductId = id,
        //            CartId = ShoppingCartId,
        //            Item = db.Items.SingleOrDefault(
        //           p => p.Id == id),
        //            Quantity = 1,
        //            DateCreated = DateTime.Now
        //        };

        //        db.ShoppingCart.Add(cartItem);
        //    }
        //    else
        //    {
        //        cartItem.Quantity++;
        //    }
        //    db.SaveChanges();
        //}

        //public string GetCartId()
        //{
        //    if (HttpContext.Current.Session[CartSessionKey] == null)
        //    {
        //        if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
        //        {
        //            HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
        //        }
        //        else
        //        {
        //            Guid tempCartId = Guid.NewGuid();
        //            HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
        //        }
        //    }
        //    return HttpContext.Current.Session[CartSessionKey].ToString();
        //}

        //public List<Cart> GetCartItems()
        //{
        //    ShoppingCartId = GetCartId();

        //    return db.ShoppingCart.Where(
        //        c => c.CartId == ShoppingCartId).ToList();
        //}

        //public void Dispose()
        //{
        //    db.Dispose();
        //}
        private IItemRepository repository;
        public CartController(IItemRepository cr)
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