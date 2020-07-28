using Common.Models;
using DALL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web;
using Common.Entities;

namespace BLL.Services
{
    public class CartService : IDisposable
    {
        public string ShoppingCartId { get; set; }

        private ApContext db = new ApContext();

        public Cart GetByCartIdAndBookId(int cartId, int Id)
        {
            return db.ShoppingCart.SingleOrDefault(ci => ci.CartId == cartId &&
                ci.ItemId == Id);
        }

        public Cart GetBySessionId(string sessionId)
        {
            var cart = db.ShoppingCart.
              Include("CartItems").
              Where(c => c.SessionId == sessionId).
              SingleOrDefault();

            cart = CreateCartIfItDoesntExist(sessionId, cart);
            return cart;
        }

       
            private Cart CreateCartIfItDoesntExist(string sessionId, Cart cart)
            {
                if (null == cart)
                {
                    cart = new Cart
                    {
                        SessionId = sessionId,
                        CartItems = new List<CartItem>()
                    };
                    db.ShoppingCart.Add(cart);
                    db.SaveChanges();
                }

                return cart;
            }

        //public IEnumerable<Cart> GetCarts()
        //{
        //    var mapper = new MapperConfiguration(cf => cf.CreateMap<Cart, CartViewModel>()).CreateMapper();
        //    return mapper.Map<IEnumerable<Item>, List<ItemDTO>>(DB.Itemss.GetAll());
        //}

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    //    public void AddToCart(Item item)
    //    {
    //       var existingCartItem = GetByCartIdAndBookId(item.)
    //        if (cartItem == null)
    //        {
    //            cartItem = new Cart
    //            {
    //                ItemId = Guid.NewGuid().ToString(),
    //                ProductId = id,
    //                CartId = ShoppingCartId,
    //                Item = db.Items.SingleOrDefault(
    //               p => p.Id == id),
    //                Quantity = 1,
    //                DateCreated = DateTime.Now
    //            };

    //            db.ShoppingCart.Add(cartItem);
    //        }
    //        else
    //        {
    //            cartItem.Quantity++;
    //        }
    //        db.SaveChanges();
    //    }

    //    public string GetCartId()
    //    {
    //        if (HttpContext.Current.Session[CartSessionKey] == null)
    //        {
    //            if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
    //            {
    //                HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
    //            }
    //            else
    //            {
    //                Guid tempCartId = Guid.NewGuid();
    //                HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
    //            }
    //        }
    //        return HttpContext.Current.Session[CartSessionKey].ToString();
    //    }

    //    public List<Cart> GetCartItems()
    //    {
    //        ShoppingCartId = GetCartId();

    //        return db.ShoppingCart.Where(
    //            c => c.CartId == ShoppingCartId).ToList();
    //    }

    //    public void Dispose()
    //    {
    //        db.Dispose();
    //    }
    //}
}
