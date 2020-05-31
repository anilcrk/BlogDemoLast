using BlogDemo.Admin.WebUI.Models;
using BlogDemo.Business.Abstract;
using BlogDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace BlogDemo.Admin.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private IBlogService _blogService;
        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public ActionResult Index()
        {
            try
            {
                var result = _blogService.GetList(_BaseUser.Id);
                BlogViewModel model = new BlogViewModel
                {
                    Blogs = _blogService.GetList(_BaseUser.Id)
                };
                return View(model);
            }
            catch(Exception ex)
            {
                ViewBag.ErrMessage = ex.Message;
                return View(new BlogViewModel());
            }
        }

       [HttpPost]
       public ActionResult Index(BlogViewModel data)
        {
            try
            {
                data.Blog.UserId = _BaseUser.Id;
                data.Blog.InsDate = DateTime.Now;
                data.Blog.EditDate = DateTime.Now;
                if (data.Blog.Id <= 0)
                {
                    _blogService.Add(data.Blog);
                    ViewBag.ErrMessage = "Added";
                }
                else
                {
                    _blogService.Update(data.Blog);
                    ViewBag.ErrMessage = "Updated";
                }
                data.Blogs = _blogService.GetList(_BaseUser.Id);
                return View(data);
            }
           catch(Exception ex)
            {
                ViewBag.ErrMessage = ex.Message;
                return View(new BlogViewModel());
            }
        }

        public ActionResult BlogDelete(int id)
        {
            _blogService.Delete(new Blog { Id = id });
            ViewBag.ErrMessage = "Deleted";
            return RedirectToAction("Index");
        }
    }
}