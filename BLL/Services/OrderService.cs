using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using EstChe.Models;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork DB { get; set; }

        public OrderService (IUnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }
        public void Dispose()
        {
            DB.Dispose();
        }

        public ItemDTO GetItem(int? id)
        {
            if (id == null)
                throw new ValidationException("item id = null", "");
            var item = DB.Itemss.Get(id.Value);
            if (item==null)
                throw new ValidationException("404 phone not found", "");
            return new ItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price
            };
        }

        public IEnumerable<ItemDTO> GetItems()
        {
            var mapper = new MapperConfiguration(cf => cf.CreateMap<Item, ItemDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Item>, List<ItemDTO>>(DB.Itemss.GetAll());
        }


        public void MakeOrder(OrderDTO orderDTO)
        {
            Item item = DB.Itemss.Get(orderDTO.Id);
            if (item == null)
                throw new ValidationException("404 item not found", "");
            Order order = new Order
            {
                ItemId = item.Id,
                Address = orderDTO.Address,
                Sum = item.Price,
                PhoneNumber = orderDTO.PhoneNumber,
                Date = DateTime.Now
            };
            DB.Orders.Create(order);
            DB.Save();
        }
    }
}
