using BlogDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Business.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetList(int UserId);
        List<Blog> GetById(int id);
        Blog Add(Blog blog);
        Blog Update(Blog blog);
        string Delete(Blog blog);

    }
}
