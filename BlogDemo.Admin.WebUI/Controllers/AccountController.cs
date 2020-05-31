using BlogDemo.Admin.WebUI.Models;
using BlogDemo.Business.Abstract;
using DemoFramework.Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BlogDemo.Admin.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            ViewBag.ErrMessage = "";
            var userResult = _userService.GetByUserEmailAndPassword(model.User.Email, model.User.Password);
            if (userResult != null)
            {
                _userService.AutClear();
                AuthenticationHelper.CreateOutCookie(userResult.Id, userResult.Email, DateTime.Now.AddDays(1),
                    _userService.GetUserRoles(userResult).Select(u => u.RoleName).ToArray(), model.RememberMe, userResult.FirstName, userResult.LastName);
                ViewBag.UserName = userResult.FirstName;
                ViewBag.UsrLastName = userResult.LastName;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrMessage = "Username or password is wrong !";
            return View();
        }
    }
}