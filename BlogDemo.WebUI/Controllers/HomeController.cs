using BlogDemo.Business.Abstract;
using BlogDemo.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BlogDemo.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IBlogService _blogService;
        public HomeController(IUserService userService,IBlogService blogService)
        {
            _userService = userService;
            _blogService = blogService;
        }
        public ActionResult Index()
        {
            return View(new IndexViewModel { Users=_userService.GetList()});
        }

        public ActionResult Detail(int id)
        {
            DetailViewModel model = new DetailViewModel
            {
                User = _userService.GetByUserForId(id),
                Blogs = _blogService.GetList(id)
            };

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}