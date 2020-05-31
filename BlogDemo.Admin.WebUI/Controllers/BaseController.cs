using BlogDemo.Admin.WebUI.Models;
using BlogDemo.Business.Abstract;
using BlogDemo.Business.DependencyResolves.Ninject;
using BlogDemo.Entities.Concrete;
using DemoFramework.Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace BlogDemo.Admin.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public User _BaseUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // ... log stuff before execution     
            if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated == false)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    { "controller", "Account" },
                    { "action", "Index" } });
                return;
            }
            try
            {
                var authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }

                var encTicket = authCookie.Value;
                if (string.IsNullOrEmpty(encTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);

                var securityUtilies = new SecurityUtilities();
                var identity = securityUtilies.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);

                if (!string.IsNullOrEmpty(identity.Name) && !string.IsNullOrEmpty(identity.Email))
                {
                    IUserService userService = IstanceFactory.GetIstance<IUserService>();
                    var result = userService.GetByUserForId(identity.Id);
                    if (result != null)
                    {
                        _BaseUser = new User
                        {
                            FirstName = result.FirstName,
                            LastName = result.LastName,
                            Email = identity.Email,
                            Id= result.Id
                        };

                        ViewBag.UserFirstName = _BaseUser.FirstName;
                        ViewBag.UserLastName = _BaseUser.LastName;
                    }

                }
            }
            catch (Exception)
            {
            }

        }
    }
}