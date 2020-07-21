
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Entities
{
    public class Item /*: IAllItems*/
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Descr { get; set; }
        public Category Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}