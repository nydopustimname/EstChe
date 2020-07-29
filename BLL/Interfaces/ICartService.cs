using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICartService:IDisposable
    {
        Cart GetByCartIdAndBookId(int cartId, int Id);
        Cart GetBySessionId(string sessionId);


    }
}
