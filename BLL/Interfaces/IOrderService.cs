﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDTO);
        ItemDTO GetItem(int? id);
        IEnumerable<ItemDTO> GetItems();
        void Dispose();
    }
}
