using BLL.Interfaces;
using Common.Models;

using log4net.Core;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc;
using System.Collections.Generic;
using BLL.Services;
using NPOI.SS.Format;
using System.Web;

namespace EstChe.Controllers
{
    public class CartController : Controller
    {

        private ICartService CartService;


        public CartController(ICartService cr)
        {
            CartService = cr;
        }

        //public CartsController()
        //{

        //    var config = new MapperConfiguration(cfg =>
        //      {
        //          cfg.CreateMap<Cart, CartItemViewModel>();
        //      });
        //    IMapper mapper = config.CreateMapper();

        //    AutoMapper.Mapper.CreateMap<CartItem, CartItemViewModel>();
        //    AutoMapper.Mapper.CreateMap<Book, BookViewModel>();
        //    AutoMapper.Mapper.CreateMap<Author, AuthorViewModel>();
        //    AutoMapper.Mapper.CreateMap<Category, CategoryViewModel>();


        public ActionResult Index()
        {
            var cart = CartService.GetBySessionId(HttpContext.Session.SessionID);
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cart, CartViewModel>();
            });
            IMapper mapper1 = mapper.CreateMapper();
            var source = new Cart();
            return View(
             mapper1.Map<Cart, CartViewModel>(cart)
            );
        }

        [ChildActionOnly]
        public PartialViewResult Summary()
        {
            var cart = CartService.GetBySessionId(HttpContext.Session.SessionID);

            var mapper = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<Cart, CartViewModel>();
              });
            IMapper mapper1 = mapper.CreateMapper();
            var source = new Cart();
            return PartialView(
             mapper1.Map<Cart, CartViewModel>(source)
            ) ;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                CartService.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}