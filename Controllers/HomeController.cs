using EstChe.Filters;
using EstChe.Models;
using EstChe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EstChe.Controllers
{
    public class HomeController : Controller
    {
        ExceptContext db2 = new ExceptContext();
        ItemContext db = new ItemContext();

       // [Except]
        //public ActionResult Index()
        //{
            //var i = new Random();
            //int j = i.Next(0, 10);
            //if (j == 5)
            //    return View(db2.Items);
            //if (j < 5)
            //{

            //    throw new Exception("Uncorrect value, j<5");
            //}    
            //else if (j>5)
            //    throw new Exception("Uncorrect value, j>5");
            //return RedirectToAction("Error");
       // }

        public ActionResult Error ()
        {
            return View();
        }

        //[CustAuthorize(false)]
        public ActionResult Index ()
        {
            return View(db.Items);
        }


        public ActionResult MakeOrder(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Item item = db.Items.Find(id);
            if (item == null)
                return HttpNotFound();
            OrderViewModel orderModel = new OrderViewModel { ItemId = item.Id };
            return View(orderModel);
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel orderModel)
        {
            if (ModelState.IsValid)
            {
                Item item = db.Items.Find(orderModel.ItemId);
                if (item == null)
                    return HttpNotFound();
                decimal sum = item.Price;

                // если сегодня первое число месяца, тогда скидка в 10% 
                if (DateTime.Now.Day == 1)
                    sum = sum - sum * 0.1m;

                Order order = new Order
                {
                    ItemId = item.Id,
                    PhoneNumber = orderModel.PhoneNumber,
                    Address = orderModel.Address,
                    Date = DateTime.Now,
                    Sum = sum
                };
                db.Orders.Add(order);
                db.SaveChanges();
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            return View(orderModel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

    //[CustAuthorize(Users ="sa")]
    //public ActionResult Edit()
    //{
    //    return View();
    //}

}
