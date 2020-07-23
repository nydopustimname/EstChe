using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstChe.Models
{
    public class OrderViewModel
    {
        public int ItemId { get; set; } 
        public string Name { get; set; }
        public string Address { get; set; }  
        public string PhoneNumber { get; set; } 
    }
}