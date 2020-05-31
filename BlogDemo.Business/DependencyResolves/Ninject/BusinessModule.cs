using BlogDemo.Business.Abstract;
using BlogDemo.Business.Concrete;
using BlogDemo.DataAccess.Abstract;
using BlogDemo.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Business.DependencyResolves.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IBlogService>().To<BlogManager>().InSingletonScope();
            Bind<IBlogDal>().To<EfBlogDal>().InSingletonScope();
        }
    }
}
