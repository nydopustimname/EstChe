using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstChe.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}