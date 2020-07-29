using Common.Entities;
using Common.Models;
using DALL.Context;
using DALL.Interfaces;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DALL.Repositories
{
    public class CartRepository: Repository<Cart>, ICartRepository

    {
        private ApContext db { get; set; }
        public CartRepository(ApContext context) : base(context) { }
      

        public void AddToCart (int itemId)
        {
            Item item = db.Items.FirstOrDefault(i => i.Id == itemId);
            if (item!=null)
            {
                throw new System.Exception("Item doesn't exist");
            }
           // db.ShoppingCart.cart
        }

    }
}
