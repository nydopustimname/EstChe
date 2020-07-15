using EstChe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstChe.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> AllCategories { get; }
    }
}