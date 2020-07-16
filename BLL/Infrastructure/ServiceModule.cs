using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connect)
        {
            connectionString = connect;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<ContextUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
