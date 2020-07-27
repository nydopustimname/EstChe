using Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Common.Models
{
    public class CartLine
    {
        [Key]
        public int CartId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
