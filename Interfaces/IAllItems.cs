using EstChe.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstChe.Interfaces
{
    interface IAllItems
    {
        IEnumerable<Item> Items { get; }
        IEnumerable<Item> Chosen { get; }
        Item GetItem(string name);
    }
}
