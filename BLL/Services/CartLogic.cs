using Common.Models;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.Services
{
    public class CartLogic : IDisposable
    {
        public string ShoppingCartId { get; set; }

        private ApContext db = new ApContext();

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            var cartItem = db.ShoppingCart.SingleOrDefault(
          c => c.CartId == ShoppingCartId
          && c.ProductId == id);
            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Item = db.Items.SingleOrDefault(
                   p => p.Id == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                db.ShoppingCart.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            db.SaveChanges();
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<Cart> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return db.ShoppingCart.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
