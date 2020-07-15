using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstChe.ViewModels
{
    public class OrderViewModel
    {
        public int ItemId { get; set; } // id телефона 
        public string Name { get; set; }
        public string Address { get; set; } // адрес 
        public string PhoneNumber { get; set; } // номер телефона покупателя 
    }
}