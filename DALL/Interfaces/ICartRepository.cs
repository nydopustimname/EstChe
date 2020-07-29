using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.Interfaces
{
    public interface ICartRepository :IRepository<Cart>
    {
         void AddToCart(int itemId);
    }
}
