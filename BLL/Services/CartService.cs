using Common.Models;
using DALL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web;
using Common.Entities;
using DALL.Interfaces;
using Common.DTO;
using BLL.Interfaces;

namespace BLL.Services
{
    public class CartService : ICartService
    {
        public string ShoppingCartId { get; set; }


        IUnitOfWork db { get; set; }

        public CartService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public Cart GetByCartIdAndBookId(int cartId, int Id)
        {
            return db.ShoppingCart.Find(ci => ci.CartId == cartId &&
              ci.ItemId == Id).SingleOrDefault();
          
        }

        public Cart GetBySessionId(string sessionId)
        {
            var cart = db.ShoppingCart.Find(c => c.SessionId == sessionId).SingleOrDefault();
              //Include("CartItems").
              //Where(c => c.SessionId == sessionId).
              //SingleOrDefault();

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
                db.ShoppingCart.Create(cart);
                db.Save();
            }

            return cart;
        }

        public IEnumerable<CartLineDTO> GetItems()
        {
            var mapper = new MapperConfiguration(cf => cf.CreateMap<Cart, CartLineDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Cart>, List<CartLineDTO>>(db.ShoppingCart.GetAll());
        }


        public void Dispose()
        {
            db.Dispose();
        }

    }

   
}
