using EstChe.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using Common.DTO;
using AutoMapper;
using BLL.Infrastructure;
using EstChe.Models;

namespace EstChe.Controllers
{
    public class HomeController : Controller
    {
        //ExceptContext db2 = new ExceptContext();
        //ItemContext db = new ItemContext();

        IOrderService orderService;
        public HomeController(IOrderService service)
        {
            orderService = service;
        }


        public ActionResult Error ()
        {
            return View();
        }

        //[CustAuthorize(false)]
        public ActionResult Index ()
        {
            IEnumerable<ItemDTO> itemDTOs = orderService.GetItems();
            if (itemDTOs.Count()==0)
                throw new Exception ();
            var mapper = new MapperConfiguration(cf => cf.CreateMap<ItemDTO, ItemViewModel>()).CreateMapper();
            var items = mapper.Map<IEnumerable<ItemDTO>, List<ItemViewModel>>(itemDTOs);
            return View(items);
            //return View(db.Items);
        }

        [CustAuthorize(true)]
        public ActionResult MakeOrder(int? id)
        {
            try
            {
                ItemDTO item = orderService.GetItem(id);
                var order = new OrderViewModel { ItemId = item.Id };
                return View(order);
            }
            catch (ValidationException ex) 
            {
                return Content(ex.Message);
            }
            //if (id == null)
            //    return HttpNotFound();
            //Item item = db.Items.Find(id);
            //if (item == null)
            //    return HttpNotFound();
            //OrderViewModel orderModel = new OrderViewModel { ItemId = item.Id };
            //return View(orderModel);
        }
        [HttpPost]
       [CustAuthorize(true)]
        public ActionResult MakeOrder(OrderViewModel orderModel)
        {
           
            try
            {
                var orderDTO = new OrderDTO { Id = orderModel.ItemId, Address = orderModel.Address, PhoneNumber = orderModel.PhoneNumber };
                orderService.MakeOrder(orderDTO);
                return Content("Ваш заказ успешно оформлен");

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(orderModel);
            //if (ModelState.IsValid)
            //{
            //    Item item = db.Items.Find(orderModel.ItemId);
            //    if (item == null)
            //        return HttpNotFound();
            //    decimal sum = item.Price;

            //    // если сегодня первое число месяца, тогда скидка в 10% 
            //    if (DateTime.Now.Day == 1)
            //        sum = sum - sum * 0.1m;

            //    Order order = new Order
            //    {
            //        ItemId = item.Id,
            //        PhoneNumber = orderModel.PhoneNumber,
            //        Address = orderModel.Address,
            //        Date = DateTime.Now,
            //        Sum = sum
            //    };
            //    db.Orders.Add(order);
            //    db.SaveChanges();
            //    return Content("<h2>Ваш заказ успешно оформлен</h2>");
            //}
            //return View(orderModel);
        }

        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }

    //[CustAuthorize(Users ="sa")]
    //public ActionResult Edit()
    //{
    //    return View();
    //}

}
