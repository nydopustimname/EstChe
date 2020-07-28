using BLL.Interfaces;
using Common.Models;
using EstChe.Models;
using log4net.Core;
using AutoMapper;

using System.Web.Mvc;
using System.Collections.Generic;
using BLL.Services;
using NPOI.SS.Format;

namespace EstChe.Controllers
{
    public class CartController : Controller
    {

        

        private readonly CartService _cartService = new CartService();

        //заменить на UOW
        private IItemRepository repository;
        public CartController(IItemRepository cr)
        {
            repository = cr;
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


        //    //MAP
        //}

        // GET: Cart
        //public ActionResult Index(string returnUrl)
        //{
        //    return View(
        //        new CartViewModel
        //        {
        //            Cart = GetCart(),
        //            ReturnUrl = returnUrl
        //        }
        //        );

        //    //var config = new MapperConfiguration(cf => cf.CreateMap<Cart, CartViewModel>());
        //    //var mapper = new Mapper(config);


        //}

        [ChildActionOnly]
        public PartialViewResult Summary()
        {
            var cart = _cartService.GetBySessionId(HttpContext.Session.SessionID);

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
                _cartService.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}