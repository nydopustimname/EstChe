using Common.Entities;
using Common.Models;
using DAL.Context;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAL.Repositories
{
    public class CartRepository: Repository<Cart>

    {
        private ApContext db { get; set; }
        public CartRepository(ApContext context) : base(context) { }
      

        public void AddToCart (int itemId)
        {
            Item item = db.Items.FirstOrDefault(i => i.Id == itemId);
            if (item!=null)
            {

            }
        }

       
    }
}
