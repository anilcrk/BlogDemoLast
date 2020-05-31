using BlogDemo.DataAccess.Abstract;
using BlogDemo.DataAccess.Concrete.EntityFramework.Contexts;
using BlogDemo.Entities.Concrete;
using DemoFramework.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal:EfEntityRepository<Blog,BlogDemoContext>,IBlogDal
    {
    }
}
