using EstChe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public  class CartLineDTO
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
