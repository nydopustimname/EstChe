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
using Microsoft.AspNet.Identity.Owin;
using BLL.Services;
using Common.Models;

namespace EstChe.Controllers
{
    public class HomeController : Controller
    {
        //ExceptContext db2 = new ExceptContext();
        //ItemContext db = new ItemContext();

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        IOrderService orderService;
        CartService cartService;
        public HomeController(IOrderService service, CartService cService)
        {
            orderService = service;
            cartService = cService;
        }




        public ActionResult Error ()
        {
            return View();
        }

        //[CustAuthorize(false)]
        public ActionResult Index ()
        {
            IEnumerable<ItemDTO> itemDTOs = orderService.GetItems();

           
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
        }

        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }

}
