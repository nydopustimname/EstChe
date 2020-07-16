using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Models
{
  public  class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public decimal Price { get; set; }
    }
}
