using Ninject.Modules;
using BLL.Services;
using BLL.Interfaces;

namespace EstChe.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
            Bind<ICartService>().To<CartService>();
        }
    }
}