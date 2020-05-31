using BlogDemo.Business.Abstract;
using BlogDemo.Business.Constant;
using BlogDemo.DataAccess.Abstract;
using BlogDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using DemoFramework.Core.Aspects.PostSharp.AuthAspects;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Business.Concrete
{
   
    public class BlogManager : IBlogService
    {
        private IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        [SecuredOperation(Roles = "Editor,Admin")]
        public Blog Add(Blog blog)
        {
            return _blogDal.Add(blog);
        }
        [SecuredOperation(Roles = "Editor,Admin")]
        public string Delete(Blog blog)
        {
            try
            {
                _blogDal.Delete(blog);
                return Messages.DeleteMessage;
            }
            catch(Exception ex) {
                return string.Format("{0} {1}", Messages.DeleteMessageError, ex.Message);
            }
        }

        public List<Blog> GetById(int id)
        {
            return _blogDal.GetList(b => b.Id == id).ToList();
        }

        public List<Blog> GetList(int UserId)
        {
            return _blogDal.GetList(b=>b.UserId==UserId);
        }
        [SecuredOperation(Roles = "Editor,Admin")]
        public Blog Update(Blog blog)
        {
            return _blogDal.Update(blog);
        }
    }
}
