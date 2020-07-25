﻿
using Common.Entities;
using System.ComponentModel.DataAnnotations;


namespace Common.Models
{

    public class Cart
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int ProductId { get; set; }

        public virtual Item Item { get; set; }

    }
    //public class Cart
    //{
    //    private List<CartLine> lineCollection = new List<CartLine>();

    //    public void AddItem(Item item, int quantity)
    //    {
    //        CartLine cartLine = lineCollection.Where(i => i.Item.Id == item.Id).FirstOrDefault();
    //        if (cartLine == null)
    //        {
    //            lineCollection.Add(new CartLine
    //            {
    //                Item = item,
    //                Quantity = quantity
    //            });

    //        }
    //        else
    //        {
    //            cartLine.Quantity += quantity;
    //        }
    //    }

    //    public void RemoveFromCart(Item item)
    //    {
    //        lineCollection.RemoveAll(i => i.Item.Id == item.Id);
    //    }

    //    public decimal ComputeSum ()
    //    {
    //        return lineCollection.Sum(i => i.Item.Price * i.Quantity);
    //    }

    //    public void Clear()
    //    {
    //        lineCollection.Clear();
    //    }

    //    public IEnumerable<CartLine> Lines => lineCollection;
    //}

    //public class CartLine
    //{
    //    public Item Item { get; set; }
    //    public int Quantity { get; set; }
    //}


}