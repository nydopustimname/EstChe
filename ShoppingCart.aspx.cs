using Common.Models;
using System;
using System.Collections.Generic;
using BLL.Services

namespace EstChe
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Cart> GetShoppingCartItems()
        {
            CartLogic cart = new CartLogic();
            return cart.GetCartItems();
        }
    }
}